using Microsoft.AspNetCore.Mvc;
using pet_store.Services.HomeServices;

namespace pet_store.Controllers
{
    public class HomeController : Controller
    {
        readonly IHomeRepository repository;
        public HomeController(IHomeRepository repository)
            => this.repository = repository;

        public IActionResult Index() => 
            View(repository.Animals
                .OrderByDescending(a => a.Comments!.Count).Take(2));
    }
}
