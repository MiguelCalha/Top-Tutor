using Microsoft.EntityFrameworkCore;
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
    //This class is responsible for managing the repositories
    //It implements the IRepository interface
    //It has a private ApplicationDbContext object
    //It has a DbSet object
    //It has a constructor that receives an ApplicationDbContext object
    //It has an Add method that receives an entity and adds it to the DbSet object
    //It has a Get method that receives a filter, includeProperties and tracked and returns the first entity that matches the filter
    //It has a GetAll method that receives a filter and includeProperties and returns all entities that match the filter
    //It has a Remove method that receives an entity and removes it from the DbSet object
    //It has a RemoveRange method that receives a list of entities and removes them from the DbSet object

    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ApplicationDbContext _db;
        internal DbSet<T> dbSet;
        public Repository(ApplicationDbContext db)
        {
            _db = db;
            this.dbSet = _db.Set<T>();
            if (typeof(T) == typeof(Product))
            {
                _db.Products.Include(u => u.Category);
            }
            else if (typeof(T) == typeof(Course))
            {
                _db.Courses.Include(i => i.Category);
            }
        }

        public void Add(T entity)
        {
            dbSet.Add(entity);
        }

        public T Get(Expression<Func<T, bool>> filter, string? includeProperties = null, bool tracked = false)
        {
            IQueryable<T> query;
            if (tracked)
            {
             query = dbSet;
           
            } 
            else {
                query = dbSet.AsNoTracking();
            }
            
                query = query.Where(filter);
                if (!string.IsNullOrEmpty(includeProperties))
                {
                    foreach (var includeProp in includeProperties.
                        Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries)) { 
                    
                        query = query.Include(includeProp);
                    }
                }
                return query.FirstOrDefault();
        }

        public IEnumerable<T> GetAll(Expression<Func<T, bool>>? filter, string? includeProperties = null)
        {


            IQueryable<T> query = dbSet;
            if (filter != null)
            {
                query = query.Where(filter);
            }
            if (!string.IsNullOrEmpty(includeProperties))
            {
                foreach(var includeProp in includeProperties.
                    Split(new char[] {','}, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProp);
                }
            }
            return query.ToList();
        }

        public void Remove(T entity)
        {
            dbSet.Remove(entity);
        }

        public void RemoveRange(IEnumerable<T> entity)
        {
           dbSet.RemoveRange(entity);
        }
    }
}
