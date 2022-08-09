using pet_store.Models;

namespace pet_store.Services.HomeServices
{
    public interface IHomeRepository
    {
        IEnumerable<Animal> Animals { get; }
    }
}
