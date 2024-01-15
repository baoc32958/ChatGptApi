using System.Collections.Generic;
using System.Data.Entity;

namespace ChatGptApi.Interfaces
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        DbSet<TEntity> GetDbSet();

        IEnumerable<TEntityDynamic> FromSqlRaw<TEntityDynamic>(string sql, params object[] parameters) where TEntityDynamic : class;
    }
}