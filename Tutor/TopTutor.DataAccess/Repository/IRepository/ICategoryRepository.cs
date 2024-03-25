using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TopTutor.Models;

namespace TopTutor.DataAcess.Repository.IRepository
{
    public interface ICategoryRepository : IRepository<Category>
    {
        //T-Category
     void Update(Category obj);
     void Save();
    }
}
