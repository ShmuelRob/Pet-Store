using Microsoft.AspNetCore.Mvc;
using pet_store.Models;
using pet_store.Services.AnimalServices;

namespace pet_store.Controllers
{
    public class AnimalController : Controller
    {
        readonly IAnimalRepository repository;
        public AnimalController(IAnimalRepository repository)
            => this.repository = repository;
        public IActionResult AnimalById(int id)
        {
            var animal = repository.GetAnimal(id);
            if (animal is null) return RedirectToAction("Index", "Home");
            return View(animal);
        }
        public IActionResult Commented(int id, string content, string visitor)
        {
            var animal = repository.GetAnimal(id);
            if (animal is null) return RedirectToAction("AnimalById", new { id });
            if (content is null) return RedirectToAction("AnimalById", new { id });
            var newComment = new Comment { CommentID = repository.Comments!.Count() + 1,
                AnimalID = id, AnimalCommented = animal, Content = content, Visitor = visitor };
            repository.AddComment(id, newComment);
            animal.Comments!.Add(newComment);
            return RedirectToAction("AnimalById", new { id });
        }
    }
}
