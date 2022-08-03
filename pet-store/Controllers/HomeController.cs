using Microsoft.AspNetCore.Mvc;

namespace pet_store.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
