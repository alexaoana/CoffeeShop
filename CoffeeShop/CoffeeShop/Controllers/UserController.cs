using Microsoft.AspNetCore.Mvc;

namespace CoffeeShop.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
