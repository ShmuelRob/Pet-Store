using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using pet_store.DAL;
using pet_store.Models;
using pet_store.Services;
using pet_store.Services.AdminServices;

namespace pet_store.Controllers
{
    public class AdminController : Controller
    {

        readonly IAdminContext context;
        public AdminController(IAdminContext context)
            => this.context = context;
        public IActionResult Index()
        {
            ViewData["Categories"] = new SelectList(context.Categories, "Id", "Name");
            return View(context.Categories);
        }

        public IActionResult AnimalsByCategory(int category)
            => View(context.Categories.Single(c => c.CategoryID == category));
        public IActionResult CreateAnimal() => View();
        public IActionResult AnimalCreated(string animalName,
            string categoryName, int age, string description, string imageSource)
        {
            var categoryId = context.Categories.Single(c => c.Name == categoryName).CategoryID;
            var animal = new Animal { AnimalID = context.Animals.Count() + 1, Name = animalName,
                CategoryID = categoryId, Age = age, Description = description, ImageSource = imageSource };
            context.AddAnimal(animal);
            return RedirectToAction("Index");
        }

        public IActionResult CreateCategory() => View();
        public IActionResult CategoryCreated(string categoryName)
        {
            context.AddCategory(new Category { CategoryID = context.Categories.Count() + 1, Name = categoryName });
            return RedirectToAction("Index");
        }

        public IActionResult EditAnimal(int id) =>
            View(context.Animals.Single(a => a.AnimalID == id));

        public IActionResult AnimalEdited(int id)
        {




            return RedirectToAction("animal", "AnimalById", id);
        }

        public IActionResult DeleteAnimal(int id)
        {
            
            return View();
        }

        public IActionResult AnimalDeleted(int id)
        {
            return View();
        }


        //public IActionResult Delete(int id)
        //{
        //    //var animal = context.Animals!
        //        //.ToList()[id];
        //    //deleteService.DeleteAnimal(1);
        //    var categories = context.Categories!
        //        .Include(c => c.Animals!)
        //        .ThenInclude(a => a.Comments);
        //    return View(categories);
        //}

    }
}
