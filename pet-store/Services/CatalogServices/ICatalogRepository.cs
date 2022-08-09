using pet_store.Models;

namespace pet_store.Services.CatalogServices
{
    public interface ICatalogRepository
    {
        IEnumerable<Category> Categories { get; }
        Category GetCategory(int id);
    }
}
