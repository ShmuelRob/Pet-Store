using Microsoft.EntityFrameworkCore;
using pet_store.DAL;
using pet_store.Models;

namespace pet_store.Services.CatalogServices
{
    public class CatalogContext : ICatalogContext
    {
        readonly PetStoreContext context;
        public CatalogContext(PetStoreContext context) => this.context = context;
        public virtual IEnumerable<Category> Categories => context.Categories!
            .Include(c => c.Animals)!.ThenInclude(a => a.Comments);
    }
}
