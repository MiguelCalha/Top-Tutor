using TopTutor.Models;
using Microsoft.EntityFrameworkCore;

//Miguel Calha
namespace TopTutor.DataAcess.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }

       public DbSet<Category> Categories { get; set; }
       public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                               new Category { Id = 1, Name = "Matemática", DisplayOrder = 1 },
                               new Category { Id = 2, Name = "Programação", DisplayOrder = 2 },
                               new Category { Id = 3, Name = "Línguas", DisplayOrder = 3 } 
                               );

            modelBuilder.Entity<Product>().HasData(
                new Product {
                    Id = 1, 
                    Title = "Programming Tutoring", 
                    Description = "Explicações de programação", 
                    TutorName = "Miguel Calha", 
                    ListPrice = 10,
                    CategoryId = 2,
                    ImageUrl=""
                },
                new Product {
                    Id = 2, 
                    Title = "Math Tutoring", 
                    Description = "Explicações de matemática",
                    TutorName = "Miguel Calha", 
                    ListPrice = 10,
                    CategoryId = 2,
                    ImageUrl = ""
                },
                new Product { 
                    Id = 3, 
                    Title = "English Tutoring", 
                    Description = "Explicações de inglês", 
                    TutorName = "Miguel Calha", 
                    ListPrice = 10,
                    CategoryId = 2,
                    ImageUrl = ""
                },
                new Product { 
                    Id = 4, 
                    Title = "French Tutoring", 
                    Description = "Explicações de francês", 
                    TutorName = "Miguel Calha", 
                    ListPrice = 10,
                    CategoryId = 2,
                    ImageUrl = ""
                },
                new Product { 
                    Id = 5, 
                    Title = "Spanish Tutoring", 
                    Description = "Explicações de espanhol", 
                    TutorName = "Miguel Calha", 
                    ListPrice = 10,
                    CategoryId = 2,
                    ImageUrl = ""
                },
                new Product {
                    Id = 6, 
                    Title = "German Tutoring", 
                    Description = "Explicações de alemão", 
                    TutorName = "Miguel Calha", 
                    ListPrice = 10,
                    CategoryId = 2,
                    ImageUrl = ""
                },
                new Product { 
                    Id = 7, 
                    Title = "Italian Tutoring", 
                    Description = "Explicações de italiano", 
                    TutorName = "Miguel Calha", 
                    ListPrice = 10,
                    CategoryId = 2,
                     ImageUrl = ""
                }
                );
        }
    }
}
