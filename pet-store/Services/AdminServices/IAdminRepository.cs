using pet_store.Models;

namespace pet_store.Services.AdminServices
{
    public interface IAdminRepository
    {
        IEnumerable<Category> Categories { get; }
        IEnumerable<Animal> Animals { get; }
        void AddCategory(Category category);
        void AddAnimal(Animal animal);
        void EditAnimal(int id, Animal animal);
        bool DeleteAnimal(int id);
    }
}
