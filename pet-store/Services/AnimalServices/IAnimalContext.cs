using pet_store.Models;

namespace pet_store.Services.AnimalServices
{
    public interface IAnimalContext
    {
        IEnumerable<Animal> Animals { get; }
        IEnumerable<Comment> Comments { get; }
        void AddComment(int animalId, Comment comment);
    }
}
