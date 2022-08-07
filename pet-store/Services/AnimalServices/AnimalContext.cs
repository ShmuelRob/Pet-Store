using Microsoft.EntityFrameworkCore;
using pet_store.DAL;
using pet_store.Models;

namespace pet_store.Services.AnimalServices
{
    public class AnimalContext : IAnimalContext
    {
        readonly PetStoreContext context;
        public AnimalContext(PetStoreContext context)
            => this.context = context;
        public virtual IEnumerable<Animal> Animals => context.Animals!.Include(a => a.Comments);
        public virtual IEnumerable<Comment> Comments => context.Comments!;

        public void AddComment(int animalId, Comment comment)
        {
            context.Comments!.Add(comment);
            context.SaveChanges();
        }

    }
}
