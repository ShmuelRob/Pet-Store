using Microsoft.EntityFrameworkCore;
using pet_store.DAL;
using pet_store.Models;

namespace pet_store.Services.AdminServices
{
    public class AdminContext : IAdminContext
    {
        readonly PetStoreContext context;
        public AdminContext(PetStoreContext context)
        {
            this.context = context;
        }
        public IEnumerable<Category> Categories => context.Categories!
            .Include(c=> c.Animals)!.ThenInclude(a=>a.Comments);
    }
}
