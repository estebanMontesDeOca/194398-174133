using System;
using System.Collections.Generic;

namespace MatchesOfSports.DataAccess.Interface
{
    public interface IRepositoryOf<T> : IDisposable where T : class
    {
        void Add(T entity);

        void Remove(T entity);

        void Update(T entity);

        IEnumerable<T> GetAll();

        T Get(Guid id);

        void Save();
    }
}