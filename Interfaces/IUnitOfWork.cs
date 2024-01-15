using System;

namespace ChatGptApi.Interfaces
{
    internal interface IUnitOfWork : IDisposable
    {
        IGenericRepository<TEntity> GetRepository<TEntity>() where TEntity : class;
    }
}