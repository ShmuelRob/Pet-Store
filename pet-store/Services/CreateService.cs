﻿using pet_store.DAL;
using pet_store.Models;

namespace pet_store.Services
{
    public class CreateService : ICreateService
    {
        readonly PetStoreContext context;
        public CreateService(PetStoreContext context) => this.context = context;
        public void CreateAnimal(Animal animal)
        {
            context.Animals!.Add(animal);
            context.SaveChanges();
        }
    }
}