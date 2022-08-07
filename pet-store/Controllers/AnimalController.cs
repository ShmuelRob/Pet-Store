using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using pet_store.DAL;
using pet_store.Models;
using pet_store.Services.AnimalServices;

namespace pet_store.Controllers
{
    public class AnimalController : Controller
    {
        readonly IAnimalContext context;
        public AnimalController(IAnimalContext context)
            => this.context = context;

        //public IActionResult Index()
        //{
        //TODO: return a 404 Page?
        //var categories = context.Categories!
        //    .Include(c => c.Animals!)
        //    .ThenInclude(a => a.Comments);
        //    return View(categories);
        //}
        public IActionResult AnimalById(int id)
        {
            return View(context.Animals!.Single(c => c.AnimalID == id));
        }
        public IActionResult Commented(int id, string comment)
        {
            var animal = context.Animals!.SingleOrDefault(a => a.AnimalID == id);
            if (animal is null) return View(); //return 404
            var newComment = new Comment { CommentID = context.Comments!.Count() + 1,
                AnimalID = id, AnimalCommented = animal, Content = comment };
            context.AddComment(id, newComment);
            animal.Comments!.Add(newComment);
            return RedirectToAction("AnimalById", new { id });
        }
    }
}
