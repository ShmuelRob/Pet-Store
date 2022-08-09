using Microsoft.EntityFrameworkCore;
using pet_store.DAL;
using pet_store.Models;

namespace pet_store.Services.CatalogServices
{
    public class CatalogRepository : ICatalogRepository
    {
        readonly PetStoreContext context;
        public CatalogRepository(PetStoreContext context) => this.context = context;
        public virtual IEnumerable<Category> Categories => context.Categories!
            .Include(c => c.Animals)!.ThenInclude(a => a.Comments);

        public Category GetCategory(int id) =>
            Categories.Single(c => c.CategoryID == id);
    }
}
