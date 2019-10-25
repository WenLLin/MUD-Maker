using Microsoft.AspNetCore.Mvc;

namespace Mud_Maker.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Favorite()
        {
            return View();
        }
        public IActionResult MUDs()
        {
            return View();
        }
    }
}