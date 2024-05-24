using Microsoft.AspNetCore.Mvc;

namespace WebAppStore.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
