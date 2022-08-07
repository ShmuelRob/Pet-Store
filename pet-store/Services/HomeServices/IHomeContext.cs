using pet_store.Models;

namespace pet_store.Services.HomeServices
{
    public interface IHomeContext
    {
        IEnumerable<Animal> Animals { get; }
    }
}
