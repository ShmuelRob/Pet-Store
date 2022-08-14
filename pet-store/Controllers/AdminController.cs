using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
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

        readonly IAdminRepository repository;
        public AdminController(IAdminRepository repository)
            => this.repository = repository;
        public IActionResult Index()
        {
            ViewData["Categories"] = new SelectList(repository.Categories, "Id", "Name");
            return View(repository.Categories);
        }
        public IActionResult AnimalsByCategory(int category)
            => View(repository.Categories.Single(c => c.CategoryID == category));
        public IActionResult CreateAnimal() => View(repository.Categories);
        public IActionResult AnimalCreated(string animalName,
            int categoryID, int age, string description, string imageSource)
        {
            //var categoryId = repository.Categories.Single(c => c.Name == categoryName).CategoryID;
            var animal = new Animal
            {
                Name = animalName,
                CategoryID = categoryID,
                Age = age,
                Description = description,
                ImageSource = imageSource
            };
            repository.AddAnimal(animal);
            return RedirectToAction("Index");
        }
        public IActionResult CreateCategory() => View();
        public IActionResult CategoryCreated(string categoryName)
        {
            repository.AddCategory(new Category { CategoryID = repository.Categories.Count() + 1, Name = categoryName });
            return RedirectToAction("Index");
        }
        public IActionResult EditAnimal(int id)
        {
            var animal = repository.Animals.Single(a => a.AnimalID == id);
            ViewBag.Categories = new Dictionary<string, int>();
            //ViewBag.CategoryName = repository.Categories!.Single(c => c.CategoryID == animal.CategoryID).Name;
            repository.Categories!.ToList().ForEach(c => ViewBag.Categories.Add(c.Name!, c.CategoryID));
            return View(animal);
        }
        public IActionResult AnimalEdited(int id, string name, int categoryID,
            int age, string description, string imageSource)
        {
            var animal = new Animal { CategoryID = categoryID, Age = age,
                Description = description, ImageSource = imageSource, Name = name };
            repository.EditAnimal(id, animal);
            return RedirectToAction("AnimalById", "animal", new { id });
        }
        public IActionResult DeleteAnimal(int id)
        {
            if(!repository.DeleteAnimal(id)) return View();
            return RedirectToAction("Index");
        }
    }
}
