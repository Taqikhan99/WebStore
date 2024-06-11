using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebAppStore.ViewModels;

namespace WebAppStore.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;

        public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }


        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var user = await userManager.FindByEmailAsync(model.Email);
                    var password = await userManager.CheckPasswordAsync(user, model.Password);

                    if (password)
                    {
                       await signInManager.SignInAsync(user, false);

                        //var res = await signInManager.PasswordSignInAsync(user.UserName, model.Password, false, false);

                        //if (res.Succeeded)
                        //{
                            if (await userManager.IsInRoleAsync(user, "Admin"))
                            {
                                return RedirectToAction("Index", "Admin");
                            }
                            return RedirectToAction("Index", "Home");
                        //}
                    }
                }


                //add error to modelstate
                ModelState.AddModelError(string.Empty, "Login Failed, Invalid Username or password");
                return View(model);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;  
                return View("Error");
            }
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        //post method for Register
        [HttpPost]
        public async  Task<IActionResult> Register(RegisterViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    // create new user
                    var user = new IdentityUser { UserName = model.Email, Email = model.Email };
                    var res = await userManager.CreateAsync(user, model.Password);

                    //if succeed then signin redirect to home page
                    if (res.Succeeded)
                    {
                        // Assign role to the user
                        var roleResult = await userManager.AddToRoleAsync(user, "User");
                        if (!roleResult.Succeeded)
                        {
                            foreach (var error in roleResult.Errors)
                            {
                                ModelState.AddModelError(string.Empty, error.Description);
                            }
                            // If role assignment fails, delete the user
                            await userManager.DeleteAsync(user);
                            return View(model);
                        }


                        await signInManager.SignInAsync(user, false);
                        return RedirectToAction("Index", "Home");
                    }
                    //if any error then add to modelstate
                    foreach (var error in res.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }

                return View(model);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return View("Error");
            }

        }

        // Logout Action method
        [HttpGet]
        public async Task<IActionResult> Signout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

    }
}
