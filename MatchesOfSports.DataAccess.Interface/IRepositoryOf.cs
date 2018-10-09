using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MatchesOfSports.DataAccess.Interface
{
    public interface IRepositoryOf<TEntity> : IDisposable where TEntity : class
    {
         IEnumerable<TEntity> Get(
               Expression<Func<TEntity, bool>> filter = null,
               Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
               string includeProperties = "");

        TEntity GetFirst(
               Expression<Func<TEntity, bool>> filter = null,
               Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
               string includeProperties = "");

        void Insert(TEntity entity);

        void Delete(TEntity entity);

        void Update(TEntity entity);
 

        TEntity GetById(Guid id);

        void Save();
    }
}