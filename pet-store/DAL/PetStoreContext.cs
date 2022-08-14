using Microsoft.EntityFrameworkCore;
using pet_store.Models;

namespace pet_store.DAL
{
    public class PetStoreContext : DbContext
    {
        public virtual DbSet<Animal>? Animals { get; set; }
        public virtual DbSet<Category>? Categories { get; set; }
        public virtual DbSet<Comment>? Comments { get; set; }

        public PetStoreContext(DbContextOptions<PetStoreContext> options)
            : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var sources = new string[]
            {
                /*0 - error */"https://www.computerhope.com/jargon/e/error.png",
                /*1 - lion*/"https://upload.wikimedia.org/wikipedia/commons/thumb/7/73/Lion_waiting_in_Namibia.jpg/800px-Lion_waiting_in_Namibia.jpg",
                /*2 - dog*/"https://hips.hearstapps.com/hmg-prod.s3.amazonaws.com/images/golden-retriever-royalty-free-image-506756303-1560962726.jpg",
                /*3 - eagle*/"https://www.birdlife.org/wp-content/uploads/2021/06/Eagle-in-flight-Richard-Lee-Unsplash-1-edited-scaled.jpg",
                /*4 - shark*/"https://upload.wikimedia.org/wikipedia/commons/thumb/5/56/White_shark.jpg/800px-White_shark.jpg",
                /*5 - cat*/"https://upload.wikimedia.org/wikipedia/commons/thumb/3/3a/Cat03.jpg/330px-Cat03.jpg",
                /*6 - chameleon*/"https://cdn.britannica.com/05/203605-050-59F5FB39/chameleon-on-branch.jpg",
                /*7 - whale*/"https://www.imf.org/-/media/Images/IMF/FANDD/article-image/2019/December/chami-index.ashx",
                /*8 - pigeon*/"http://www.dvarhamefarsem.co.il/Hot/20710/Rashit.JPG",
                /*9 - alligator*/"https://whnt.com/wp-content/uploads/sites/20/2022/05/GettyImages-1171368832.jpg?w=960&h=540&crop=1",
                ///*9 - alligator*/"https://whnt.com/wp-content/uploads/sites/20/2022/05/GettyImages-1171368832.jpg",
                /*10 - owl*/"https://img.apmcdn.org/9fe734b0a7596f13b98ccd5152262fe7d590ce4d/widescreen/a6c353-20220405-screech-owl-1000.jpg",
            };

            modelBuilder.Entity<Category>().HasData(
                new { CategoryID = 1, Name = "Mammal" },
                new { CategoryID = 2, Name = "Birds" },
                new { CategoryID = 3, Name = "Fish" },
                new { CategoryID = 4, Name = "Amphibians" },
                new { CategoryID = 5, Name = "reptiles" }
                );


            modelBuilder.Entity<Animal>().HasData(
                new { AnimalID = 1, CategoryID = 1, Age = 5, Name = "Lion", ImageSource = sources[1], Description = "description for lion" },
                new { AnimalID = 2, CategoryID = 1, Age = 2, Name = "Dog", ImageSource = sources[2], Description = "description for dog" },
                new { AnimalID = 3, CategoryID = 2, Age = 12, Name = "Eagle", ImageSource = sources[3], Description = "description for eagle" },
                new { AnimalID = 4, CategoryID = 3, Age = 3, Name = "Shark", ImageSource = sources[4], Description = "description for shark" },
                new { AnimalID = 5, CategoryID = 1, Age = 4, Name = "Cat", ImageSource = sources[5], Description = "description for cat" },
                new { AnimalID = 6, CategoryID = 5, Age = 1, Name = "Chameleon", ImageSource = sources[6], Description = "description for chameleon" },
                new { AnimalID = 7, CategoryID = 3, Age = 15, Name = "Whale", ImageSource = sources[7], Description = "description for whale" },
                new { AnimalID = 8, CategoryID = 2, Age = 2, Name = "Pigeon", ImageSource = sources[8], Description = "description for pigeon" },
                new { AnimalID = 9, CategoryID = 5, Age = 4, Name = "Alligator", ImageSource = sources[9], Description = "description for alligator" },
                new { AnimalID = 10, CategoryID = 2, Age = 9, Name = "Owl", ImageSource = sources[10], Description = "description for owl" }
                );


            modelBuilder.Entity<Comment>().HasData(
                new { CommentID = 1, AnimalID = 1, Content = "king of animals" },
                new { CommentID = 2, AnimalID = 2, Content = "the man's best friend" },
                new { CommentID = 3, AnimalID = 1, Content = "Simba is his brother" },
                new { CommentID = 4, AnimalID = 5, Content = "licks itself" },
                new { CommentID = 5, AnimalID = 6, Content = "can change colors" },
                new { CommentID = 6, AnimalID = 7, Content = "the biggest fish in the world" },
                new { CommentID = 7, AnimalID = 9, Content = "you don't want to mess with this guy..." },
                new { CommentID = 8, AnimalID = 10, Content = "the smartest bird" }
                );
        }
    }
}
