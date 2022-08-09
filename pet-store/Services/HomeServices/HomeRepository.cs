using Microsoft.EntityFrameworkCore;
using pet_store.DAL;
using pet_store.Models;

namespace pet_store.Services.HomeServices
{
    public class HomeRepository : IHomeRepository
    {
        readonly PetStoreContext context;
        public HomeRepository(PetStoreContext context)
            => this.context = context;
        public virtual IEnumerable<Animal> Animals
            => context.Animals!.Include(a => a.Comments);
    }
}
