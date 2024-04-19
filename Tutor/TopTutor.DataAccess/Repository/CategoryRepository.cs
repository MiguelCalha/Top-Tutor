using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TopTutor.DataAcess.Data;
using TopTutor.DataAcess.Repository.IRepository;
using TopTutor.Models;

namespace TopTutor.DataAcess.Repository
{
    //Author: Miguel Calha
    //This class is responsible for managing the Category repository
    //It extends the Repository class and implements the ICategoryRepository interface
    //It has a private ApplicationDbContext object
    //It has a constructor that receives an ApplicationDbContext object
    //It has an Update method that receives a Category object and updates it

    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        private ApplicationDbContext _db;

        public CategoryRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }


        public void Update(Category obj)
        {
            _db.Categories.Update(obj);
        }
    }
}
