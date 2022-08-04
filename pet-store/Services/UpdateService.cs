using pet_store.DAL;
using pet_store.Models;

namespace pet_store.Services
{
    public class UpdateService : IUpdateService
    {
        readonly PetStoreContext context;
        public UpdateService(PetStoreContext context)
        {
            this.context = context;
        }
        public void UpdateAnimal(int animalID, Animal details)
        {
            var animal = context.Animals!.Single(a => a.AnimalID == animalID);
            if (details.Name is not null) animal.Name = details.Name;
            if (details.Age != 0) animal.Age = details.Age;
            if (details.CategoryID > 0 && details.CategoryID <= context.Categories!.Count())
                animal.CategoryID = details.CategoryID;
            if (details.PictureSrc is not null) animal.PictureSrc = details.PictureSrc;
            context.Update(animal);
            context.SaveChanges();
        }
    }
}
