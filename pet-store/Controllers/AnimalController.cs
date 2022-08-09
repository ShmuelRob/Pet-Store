using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using pet_store.DAL;
using pet_store.Models;
using pet_store.Services.AnimalServices;

namespace pet_store.Controllers
{
    public class AnimalController : Controller
    {
        readonly IAnimalRepository repository;
        public AnimalController(IAnimalRepository repository)
            => this.repository = repository;
        public IActionResult AnimalById(int id) => View(repository.GetAnimal(id));
        public IActionResult Commented(int id, string comment)
        {
            var animal = repository.GetAnimal(id);
            if (animal is null) return NotFound(); //View(); //return 404
            var newComment = new Comment { CommentID = repository.Comments!.Count() + 1,
                AnimalID = id, AnimalCommented = animal, Content = comment };
            repository.AddComment(id, newComment);
            animal.Comments!.Add(newComment);
            return RedirectToAction("AnimalById", new { id });
        }
    }
}
