using Microsoft.EntityFrameworkCore;
using TopTutor.Models;

//Miguel Calha
namespace TopTutor.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }

       public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                               new Category { Id = 1, Name = "Matemática", DisplayOrder = 1 },
                               new Category { Id = 2, Name = "Programação", DisplayOrder = 2 },
                               new Category { Id = 3, Name = "Línguas", DisplayOrder = 3 } 
                               );
        }
    }
}
