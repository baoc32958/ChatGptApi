using ChatGptApi.Implementations;
using OpeInformation.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OpeInformation.Services.Implementations
{
    public abstract class EntityService : IDisposable, IEntityService
    {
        protected readonly UnitOfWork _objUnitOfWork;

        public EntityService()
        {
            _objUnitOfWork = new UnitOfWork();
        }

        public EntityService(UnitOfWork unitOfWork)
        {
            _objUnitOfWork = unitOfWork;
        }

        public IEnumerable<TEntityDynamic> FromSqlRaw<TEntityDynamic>(string sql, params object[] parameters) where TEntityDynamic : class
        {
            return _objUnitOfWork.GetDbContext().Database.SqlQuery<TEntityDynamic>(sql, parameters).ToList();
        }
        public void FromSqlRawNonQuery(string sql, params object[] parameters)
        {
            _objUnitOfWork.GetDbContext().Database.ExecuteSqlCommand(sql, parameters);
        }
        public virtual void Dispose()
        {
            _objUnitOfWork.Dispose();
        }
    }
}