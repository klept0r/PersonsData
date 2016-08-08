using System;
using System.Linq;
using System.Linq.Expressions;

namespace PersonsDataWebApi.Interface
{
    public interface IRepository<T> where T : class
    {
        void Insert(T entity);

        IQueryable<T> Select(Expression<Func<T, bool>> predicate);

        IQueryable<T> SelectAll();
    }
}