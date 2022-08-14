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
            animal.AnimalID = context.Animals!.OrderBy(a=> a.AnimalID).Last().AnimalID + 1;
            context.Animals!.Add(animal);
            context.SaveChanges();
        }

        public void EditAnimal(int id, Animal animal)
        {
            var oldAnimal = context.Animals!.SingleOrDefault(a => a.AnimalID == id);
            if (oldAnimal is null) return;
            if (animal.Name is not null) oldAnimal.Name = animal.Name;
            if (animal.Age > 0) oldAnimal.Age = animal.Age;
            if (animal.CategoryID > 0) oldAnimal.CategoryID = animal.CategoryID;
            if (animal.Description is not null) oldAnimal.Description = animal.Description;
            if (animal.ImageSource is not null) oldAnimal.ImageSource = animal.ImageSource;
            context.SaveChanges();
        }

        public bool DeleteAnimal(int id)
        {
            var animal = Animals.SingleOrDefault(a => a.AnimalID == id);
            if (animal is null) return false;
            //Animals.ToList().Remove(Animals.Single(a => a.AnimalID == id));
            context.Remove(animal);
            context.SaveChanges();
            return true;
        }
    }
}
