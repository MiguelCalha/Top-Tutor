using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TopTutor.Models;

namespace TopTutor.DataAcess.Repository
{
    //Author: João Dâmaso
    //This class is responsible for managing the repositories
    //It has a public static method that receives a query and returns a query with the related entities included

    public static class RepositoryExtensions
    {
        public static IQueryable<T> IncludeRelatedEntities<T>(this IQueryable<T> query) where T : class
        {
            if (typeof(T) == typeof(Product))
            {
                return query.Include(u => ((Product)(object)u).Category);
            }
            else if (typeof(T) == typeof(Course))
            {
                return query.Include(i => ((Course)(object)i).Category);
            }
            return query;
        }
    }
    }