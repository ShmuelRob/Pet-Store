using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using pet_store.DAL;
using pet_store.Models;
using pet_store.Services;

namespace pet_store.Controllers
{
    public class AdminController : Controller
    {
        readonly PetStoreContext context;
        readonly ICreateService createService;
        readonly IDeleteService deleteService;
        readonly IUpdateService updateService;
        public AdminController(PetStoreContext context,
            ICreateService createService, IDeleteService deleteService, IUpdateService updateService)
        {
            this.context = context;
            this.createService = createService;
            this.deleteService = deleteService;
            this.updateService = updateService;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            var animal = new Animal { Name = "test", Age = 5, CategoryID = 2, PictureSrc = "none" };
            createService.CreateAnimal(animal);
            //var categories = context.Categories!
            //    .Include(c => c.Animals!)
            //    .ThenInclude(a => a.Comments);
            return View(animal);
        }
        public IActionResult Update()
        //0524230413
        {


            return View();
        }

        public IActionResult Delete()
        {
            deleteService.DeleteAnimal(1);
            var categories = context.Categories!
                .Include(c => c.Animals!)
                .ThenInclude(a => a.Comments);
            return View(categories);
        }

    }
}
