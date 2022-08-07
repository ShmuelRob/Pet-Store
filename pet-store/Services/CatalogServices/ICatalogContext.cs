using pet_store.Models;

namespace pet_store.Services.CatalogServices
{
    public interface ICatalogContext
    {
        IEnumerable<Category> Categories { get; }
    }
}
