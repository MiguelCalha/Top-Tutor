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
    //This class is responsible for managing the Course repository
    //It extends the Repository class and implements the ICourseRepository interface
    //It has a private ApplicationDbContext object
    //It has a constructor that receives an ApplicationDbContext object
    //It has an Update method that receives a Course object and updates it

    public class CourseRepository : Repository<Course>, ICourseRepository
    {
        private ApplicationDbContext _db;

        public CourseRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }


        public void Update(Course obj)
        {
            var objFromDb = _db.Courses.FirstOrDefault(u => u.Id == obj.Id);
            if(objFromDb != null)
            {
                 
                objFromDb.Title = obj.Title;
                objFromDb.TutorName = obj.TutorName;
                objFromDb.CategoryId = obj.CategoryId;
                objFromDb.Description = obj.Description;
               

                if (obj.ImageUrl != null)
                {
                    objFromDb.ImageUrl = obj.ImageUrl;
                }

            }
        }
    }
}
