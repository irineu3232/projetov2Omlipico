using Microsoft.AspNetCore.Mvc;

namespace POlimpicos.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
