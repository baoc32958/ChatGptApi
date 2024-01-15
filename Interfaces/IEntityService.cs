using System.Collections.Generic;

namespace OpeInformation.Services.Interfaces
{
    public interface IEntityService
    {
        IEnumerable<TEntityDynamic> FromSqlRaw<TEntityDynamic>(string sql, params object[] parameters) where TEntityDynamic : class;

        void Dispose();
    }
}