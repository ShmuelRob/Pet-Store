using pet_store.Models;

namespace pet_store.Services.AdminServices
{
    public interface IAdminContext
    {
        IEnumerable<Category> Categories { get; }
    }
}
