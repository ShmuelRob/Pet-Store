using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using pet_store.DAL;

namespace pet_store.Controllers
{
    public class AnimalController : Controller
    {
        readonly PetStoreContext context;
        public AnimalController(PetStoreContext context)
            => this.context = context;

        public IActionResult Index()
        {
            var categories = context.Categories!
                .Include(c => c.Animals!)
                .ThenInclude(a => a.Comments);
            return View(categories);
        }
        public IActionResult AnimalsByCategory(int id)
            => View(context.Categories!.Single(c => c.CategoryID == id).Animals);
    }
}
