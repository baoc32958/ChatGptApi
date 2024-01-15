using ChatGptApi.Entities;
using ChatGptApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace ChatGptApi.Implementations
{
    public class UnitOfWork : IUnitOfWork
    {
        /// <summary>
        /// The DbContext
        /// </summary>
        private ChatGptApiDBContext _dbContext = new ChatGptApiDBContext();

        /// <summary>
        /// The Repository
        /// </summary>
        private Dictionary<Type, object> repositories;

        /// <summary>
        /// Initializes a new instance of the UnitOfWork class
        /// </summary>
        public UnitOfWork()
        {
        }

        /// <summary>
        /// Get repository
        /// </summary>
        public IGenericRepository<TEntity> GetRepository<TEntity>() where TEntity : class
        {
            if (repositories == null)
            {
                repositories = new Dictionary<Type, object>();
            }

            var type = typeof(TEntity);
            if (!repositories.ContainsKey(type))
            {
                repositories[type] = new GenericRepository<TEntity>(_dbContext);
            }

            return (IGenericRepository<TEntity>)repositories[type];
        }

        /// <summary>
        /// check connection
        /// </summary>
        /// <returns></returns>
        public bool CheckConnection()
        {
            try
            {
                _dbContext.Database.ExecuteSqlCommand("SELECT 1");
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Saves all pending changes
        /// </summary>
        /// <returns>The number of objects in an Added, Modified, or Deleted state</returns>
        public int Save()
        {
            return _dbContext.SaveChanges();
        }

        /// <summary>
        /// Disposes the current object
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private bool disposed = false;

        /// <summary>
        /// Disposes all external resources.
        /// </summary>
        /// <param name="disposing">The dispose indicator.</param>
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _dbContext.Dispose();
                }
            }
            this.disposed = true;
        }

        /// <summary>
        /// Get DbContext
        /// </summary>
        /// <returns></returns>
        public DbContext GetDbContext()
        {
            return _dbContext;
        }
    }
}