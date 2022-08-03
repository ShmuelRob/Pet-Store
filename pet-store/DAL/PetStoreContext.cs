using Microsoft.EntityFrameworkCore;
using pet_store.Models;

namespace pet_store.DAL
{
    public class PetStoreContext: DbContext
    {
        public virtual DbSet<Animal>? Abimals { get; set; }
        public virtual DbSet<Category>? Categories { get; set; }
        public virtual DbSet<Comment>? Comments { get; set; }

        public PetStoreContext(DbContextOptions<PetStoreContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //modelBuilder.Entity<Animal>().HasData(
            //    new Animal{ AnimalID=1, }
            //    )
        }
    }
}
