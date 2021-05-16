using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repository
{
    public interface IRepository<TEntity> where TEntity : class
    {
        bool Exists(Expression<Func<TEntity, bool>> predicate);
        TEntity Get(int id);
        ICollection<TEntity> Get();
        void Add(TEntity entity);
        void Remove(TEntity entity);
        int Save();
    }
}
