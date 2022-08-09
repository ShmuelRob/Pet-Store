using Microsoft.AspNetCore.Mvc;
using pet_store.Services.CatalogServices;

namespace pet_store.Controllers
{
    public class CatalogController : Controller
    {
        readonly ICatalogRepository repository;
        public CatalogController(ICatalogRepository repository)
            => this.repository = repository;
        public IActionResult Index(int id = 1)
            => View(repository.GetCategory(id));
    }
}
