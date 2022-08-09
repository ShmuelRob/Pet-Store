using pet_store.Models;

namespace pet_store.Services.AnimalServices
{
    public interface IAnimalRepository
    {
        IEnumerable<Animal> Animals { get; }
        IEnumerable<Comment> Comments { get; }
        void AddComment(int animalId, Comment comment);
        Animal GetAnimal(int id);
    }
}
