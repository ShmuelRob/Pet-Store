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
        public IActionResult CreateAnimal() => View();
        public IActionResult AnimalCreated(string animalName,
            string categoryName, int age, string description, string imageSource)
        {
            var categoryId = repository.Categories.Single(c => c.Name == categoryName).CategoryID;
            var animal = new Animal
            {
                AnimalID = repository.Animals.Count() + 1,
                Name = animalName,
                CategoryID = categoryId,
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
            ViewBag.CategoryName = repository.Categories!.Single(c => c.CategoryID == animal.CategoryID).Name;
            ViewBag.Categories = repository.Categories!.Select(c => c.Name);
            return View(animal);
        }

        public IActionResult AnimalEdited(int id, string categoryName, int age, string description, string imageSource)
        {
            var animal = repository.Animals.Single(a => a.AnimalID == id);
            if (repository.Categories.Any(c => c.Name == categoryName))
                animal.CategoryID = repository.Categories.Single(c => c.Name == categoryName).CategoryID;
            if (age >= 0) animal.Age = age;
            if (description is not null) animal.Description = description;
            if (imageSource is not null) animal.ImageSource = imageSource;
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
