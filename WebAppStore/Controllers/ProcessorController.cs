using Microsoft.AspNetCore.Mvc;

namespace WebAppStore.Controllers
{
    public class ProcessorController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
