using Microsoft.AspNetCore.Mvc;
using pet_store.Services.HomeServices;

namespace pet_store.Controllers
{
    public class HomeController : Controller
    {
        readonly IHomeContext context;
        public HomeController(IHomeContext context)
            => this.context = context;

        public IActionResult Index() => 
            View(context.Animals
                .OrderByDescending(a => a.Comments!.Count).Take(2));
    }
}
