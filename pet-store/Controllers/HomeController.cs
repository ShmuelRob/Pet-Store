using Microsoft.AspNetCore.Mvc;
using pet_store.DAL;

namespace pet_store.Controllers
{
    public class HomeController : Controller
    {
        PetStoreContext context;
        public HomeController(PetStoreContext context)
        {
            this.context = context;
        }
        public IActionResult Index()
        {
            
            return View(context.Animals);
        }
    }
}
