using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Pricero.Core.Db
{
    public class EntityRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private PriceroDBContext dbContext;

        private DbSet<TEntity> entitySet;

        public EntityRepository(PriceroDBContext db)
        {
            this.dbContext = db;
            entitySet = dbContext.Set<TEntity>();
        }

        public void Add(TEntity entity)
        {
            entitySet.Add(entity);
        }

        public void Delete(TEntity entity)
        {
            entitySet.Remove(entity);
        }

        public TEntity GetEntity(Expression<Func<TEntity, bool>> predicate)
        {
            return entitySet.First(predicate);
        }

        public IEnumerable<TEntity> GetEntities(Expression<Func<TEntity, bool>> predicate = null)
        {
            if (predicate != null) {
                return entitySet.Where(predicate);
            }
            return entitySet.AsEnumerable();
        }

        
    }

    /// <summary>
    /// Interface made to store reference to desired repository
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IRepository<TEntity> where TEntity : class
    {
        void Add(TEntity entity);
        void Delete(TEntity entity);
        IEnumerable<TEntity> GetEntities(Expression<Func<TEntity, bool>> predicate = null);
        TEntity GetEntity(Expression<Func<TEntity, bool>> predicate);
    }
}