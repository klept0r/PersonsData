using System;
using System.Data.Entity;

namespace PersonsDataWebApi.Interface
{
    public interface IRepositoryProvider
    {
        DbContext dbContext { get; set; }

        T GetRepository<T>(Func<DbContext, object> factory = null) where T : class;
    }
}
