using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TopTutor.DataAcess.Data;
using TopTutor.DataAcess.Repository.IRepository;

namespace TopTutor.DataAcess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationDbContext _db;
        public ICategoryRepository Category { get; private set; }
        public IProductRepository Product { get; private set; }
        public ICourseRepository Course { get; private set; }
        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            Category = new CategoryRepository(_db);
            Product = new ProductRepository(_db);
            Course = new CourseRepository(_db);

        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
