using Domain.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Database.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private DbContext Context;
        public Repository(DbContext dbContext)
        {
            Context = dbContext;
        }
        public virtual void Add(TEntity entity)
        {
            Context.Set<TEntity>().Add(entity);
            Save();
        }

        public virtual bool Exists(Expression<Func<TEntity, bool>> predicate)
        {
            var obj = Context.Set<TEntity>().Where(predicate).FirstOrDefault();
            if (obj == null)
                return false;
            return true;
        }

        public virtual TEntity Get(int id)
        {
            return Context.Set<TEntity>().Find(id);
        }

        public virtual ICollection<TEntity> Get()
        {
            return Context.Set<TEntity>().ToList();
        }

        public virtual void Remove(TEntity entity)
        {
            Context.Set<TEntity>().Remove(entity);
            Save();
        }

        public virtual int Save()
        {
            return Context.SaveChanges();
        }
    }
}
