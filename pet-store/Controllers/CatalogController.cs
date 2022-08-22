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
        {
            repository.Categories!.ToList().ForEach(c => ViewData.Add(c.Name!, c.CategoryID.ToString()));
            var category = repository.GetCategory(id);
            category ??= repository.GetCategory(1);
            return View(category);
        }
    }
}
