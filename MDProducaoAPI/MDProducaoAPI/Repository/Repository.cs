using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System;
using System.Linq;
using System.Linq.Expressions;
using MDProducaoAPI.Repository.Interfaces;
using MDProducaoAPI.Service;

namespace MDProducaoAPI.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected DbSet<T> DbSet;

        public Repository()
        {
    
        }

        public Repository(Context dataContext)
        {
            DbSet = dataContext.Set<T>();
        }

        public void Add(T entity)
        {
            DbSet.Add(entity);
        }

        public void Delete(T entity)
        {
            DbSet.Remove(entity);
        }

        public void Update(T entity)
        {
            DbSet.Update(entity);
        }

        public IQueryable<T> SearchFor(Expression<Func<T, bool>> predicate)
        {
            return DbSet.Where(predicate);
        }

        public IQueryable<T> GetAll()
        {
            return DbSet;
        }

        public T GetById(int id)
        {
            return DbSet.Find(id);
        }

    }

}