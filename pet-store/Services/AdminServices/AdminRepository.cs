using Microsoft.EntityFrameworkCore;
using pet_store.DAL;
using pet_store.Models;

namespace pet_store.Services.AdminServices
{
    public class AdminRepository : IAdminRepository
    {
        readonly PetStoreContext context;
        public AdminRepository(PetStoreContext context)
            => this.context = context;
        public IEnumerable<Category> Categories => context.Categories!
            .Include(c => c.Animals)!.ThenInclude(a => a.Comments);
        public IEnumerable<Animal> Animals =>
            context.Animals!.Include(a => a.Comments);
        public void AddCategory(Category category)
        {
            context.Categories!.Add(category);
            context.SaveChanges();
        }
        public void AddAnimal(Animal animal)
        {
            context.Animals!.Add(animal);
            context.SaveChanges();
        }
    }
}
