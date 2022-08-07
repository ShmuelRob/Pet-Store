using Microsoft.AspNetCore.Mvc;
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
        public IActionResult Index() => View(context.Categories);

        public IActionResult AnimalsByCategory(int id = 1)
        {
            return View(context.Categories.Single(c => c.CategoryID == id));
        }
        public IActionResult Create()
        {
            var animal = new Animal { Name = "test", Age = 5, CategoryID = 2, PictureSrc = "none" };

            //createService.CreateAnimal(animal);
            //var categories = context.Categories!
            //    .Include(c => c.Animals!)
            //    .ThenInclude(a => a.Comments);
            return View(animal);
        }
        public IActionResult Update(int id)
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
