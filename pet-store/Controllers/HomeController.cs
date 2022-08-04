using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using pet_store.DAL;

namespace pet_store.Controllers
{
    public class HomeController : Controller
    {
        readonly PetStoreContext context;
        public HomeController(PetStoreContext context) => this.context = context;

        public IActionResult Index()
            => View(context.Animals!.OrderByDescending(a => a.Comments!.Count).Take(2));
    }
}
