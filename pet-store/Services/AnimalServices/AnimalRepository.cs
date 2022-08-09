using Microsoft.EntityFrameworkCore;
using pet_store.DAL;
using pet_store.Models;

namespace pet_store.Services.AnimalServices
{
    public class AnimalRepository : IAnimalRepository
    {
        readonly PetStoreContext context;
        public AnimalRepository(PetStoreContext context)
            => this.context = context;
        public virtual IEnumerable<Animal> Animals => context.Animals!.Include(a => a.Comments);
        public virtual IEnumerable<Comment> Comments => context.Comments!;
        public void AddComment(int animalId, Comment comment)
        {
            context.Comments!.Add(comment);
            context.SaveChanges();
        }
        public Animal GetAnimal(int id) => Animals.Single(a => a.AnimalID == id);
    }
}
