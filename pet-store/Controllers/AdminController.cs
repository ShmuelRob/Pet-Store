using Microsoft.AspNetCore.Mvc;

namespace pet_store.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
