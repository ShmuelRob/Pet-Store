using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using pet_store.DAL;
using pet_store.Models;
using pet_store.Services;

namespace pet_store.Controllers
{
    public class HomeController : Controller
    {
        readonly PetStoreContext context;
        public HomeController(PetStoreContext context)
        {
            this.context = context;
        }

        public IActionResult Index()
        {
            var categories = context.Categories!
               .Include(c => c.Animals!).ThenInclude(a => a.Comments);
            var pets = new List<Animal>();
            categories.ToList().ForEach(c => c.Animals!.ToList().ForEach(a => pets.Add(a)));
            var newPets = pets.OrderByDescending(p => p.Comments!.Count);
            return View(newPets.Take(2));
        }

        public IActionResult AllAnimals()
        {
            var categories = context.Categories!
                .Include(c => c.Animals!)
                .ThenInclude(a => a.Comments);
            return View(categories);
        }
    }
}
