﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TopTutor.Models;

namespace TopTutor.DataAcess.Repository.IRepository
{
    public interface ICourseRepository : IRepository<Course>
    {
        void Update(Course obj);

    }
}
