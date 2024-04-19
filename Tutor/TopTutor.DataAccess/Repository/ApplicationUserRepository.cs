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
    //Author: João Dâmaso
    //This class is responsible for managing the ApplicationUser repository
    //It extends the Repository class and implements the IApplicationUserRepository interface
    //It has a private ApplicationDbContext object
    //It has a constructor that receives an ApplicationDbContext object
    //It has an Update method that receives an ApplicationUser object and updates it
        
    public class ApplicationUserRepository : Repository<ApplicationUser>, IApplicationUserRepository
    {
        private ApplicationDbContext _db;

        public ApplicationUserRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

		public void Update(ApplicationUser applicationUser)
		{
			_db.ApplicationUsers.Update(applicationUser);
		}
	}
}
