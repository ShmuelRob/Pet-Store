using Microsoft.AspNetCore.Mvc;
using pet_store.Services.CatalogServices;

namespace pet_store.Controllers
{
    public class CatalogController : Controller
    {
        readonly ICatalogContext context;
        public CatalogController(ICatalogContext context)
            => this.context = context;
        public IActionResult Index(int id = 1)
            => View(context.Categories.Single(c => c.CategoryID == id));
    }
}
