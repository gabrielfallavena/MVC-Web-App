using Microsoft.AspNetCore.Mvc;

namespace WebApp1.Controllers
{
    public class SellersController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
