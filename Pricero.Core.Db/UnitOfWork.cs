using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pricero.Core.Db
{
    /// <summary>
    /// Class 
    /// </summary>
    public class UnitOfWork : IDisposable
    {
        private PriceroDBContext dbContext;

        #region IDisposable Support
        private bool disposedValue = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    dbContext.Dispose();
                }
                disposedValue = true;
            }
        }
        public void Dispose()
        {
            throw new NotImplementedException();
        }
        #endregion
        public UnitOfWork()
        {
            dbContext = new PriceroDBContext();
        }
        public Dictionary<Type, object> repos = new Dictionary<Type, object>();
        public IRepository<T> Repository<T>() where T : class
        {
            if (repos.Keys.Contains(typeof(T)) == true)
                return repos[typeof(T)] as IRepository<T>;

            IRepository<T> repo = new EntityRepository<T>(dbContext);
            repos.Add(typeof(T), repo);
            return repo;
        }
        public void SaveChanges()
        {
            dbContext.SaveChanges();
        }
    }

    
}
