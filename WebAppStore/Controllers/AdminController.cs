using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using WebAppStore.DAL;
using WebAppStore.Models;
using WebAppStore.ViewModels;

namespace WebAppStore.Controllers
{
    public class AdminController : Controller
    {
        private readonly AppDbContext dbContext;
         
        public AdminController(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [Authorize(Roles ="Admin")]
        public async Task<IActionResult> Index()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var usercount = await dbContext.Users.Where(x=>x.Id!=userId).CountAsync();
            var laptopCount = await dbContext.Laptops.CountAsync();
            var brandCount = await dbContext.Brands.CountAsync();

            ViewBag.Usercount = usercount;
            ViewBag.laptopCount = laptopCount;
            ViewBag.brandCount = brandCount;

            return View();
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<IActionResult> UsersLists()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var users = await dbContext.Users.Where(x => x.Id != userId).ToListAsync();

            var usersList = new List<UsersViewListModel>();
            foreach (var user in users)
            {
                UsersViewListModel u = new UsersViewListModel
                {
                    Email = user.Email,
                    UserName = user.UserName,
                    UserId = user.Id
                };

                usersList.Add(u);
            }

            if (users==null || users.Count == 0)
            {
                ViewBag.ErrorMessage = "Users Not Found";
                return View("Error");
            }

            return View(usersList);
        }


        
        

    }
}
