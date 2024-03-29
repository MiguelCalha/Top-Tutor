using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TopTutor.Models;

namespace TopTutor.DataAcess.Repository
{
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