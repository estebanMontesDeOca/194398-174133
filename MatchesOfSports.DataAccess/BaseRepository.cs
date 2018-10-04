using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore; 
using MatchesOfSports.DataAccess.Interface;
namespace MatchesOfSports.DataAccess
{
    public abstract class BaseRepository<T> : IRepositoryOf<T> where T : class
    {
        protected DbContext Context {get; set;}
        
        public void Add(T entity) 
        {
            Context.Set<T>().Add(entity);
        }

        public void Remove(T entity) 
        {
            Context.Set<T>().Remove(entity);
        }

        public void Update(T entity) 
        {
            Context.Entry(entity).State = EntityState.Modified;
        }

        public abstract IEnumerable<T> GetAll();

        public abstract T Get(Guid id);

        public void Save() 
        {
            Context.SaveChanges();
        }

        private bool disposedValue = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    Context.Dispose();
                }
                disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}