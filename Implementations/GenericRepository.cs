using ChatGptApi.Entities;
using ChatGptApi.Interfaces;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace ChatGptApi.Implementations
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity>
      where TEntity : class
    {
        protected DbContext _context;
        protected readonly DbSet<TEntity> _dbset;

        public GenericRepository(ChatGptApiDBContext context)
        {
            _context = context;
            _dbset = context.Set<TEntity>();
        }

        public IEnumerable<TEntityDynamic> FromSqlRaw<TEntityDynamic>(string sql, params object[] parameters) where TEntityDynamic : class
        {
            return _context.Database.SqlQuery<TEntityDynamic>(sql, parameters).ToList();
        }

        public DbSet<TEntity> GetDbSet()
        {
            return _dbset;
        }
    }
}