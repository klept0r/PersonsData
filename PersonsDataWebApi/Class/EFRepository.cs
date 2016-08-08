namespace PersonsDataWebApi.Class
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using System.Linq.Expressions;

    using PersonsDataWebApi.Interface;

    public class EFRepository<T> : IRepository<T>
        where T : class
    {
        protected readonly PersonsDataDBEntities _context;

        protected readonly IDbSet<T> dbSet;

        public EFRepository(DbContext context)
        {
            this._context = (PersonsDataDBEntities)context;
            this.dbSet = context.Set<T>();
        }

        public IQueryable<T> SelectAll()
        {
            return this.dbSet;
        }

        public IQueryable<T> Select(Expression<Func<T, bool>> predicate)
        {
            return this.dbSet.Where(predicate);
        }

        public void Insert(T entity)
        {
            this.dbSet.Add(entity);
        }

        public void Update(T entity)
        {
            var dbEntityEntry = this._context.Entry(entity);
            if (dbEntityEntry.State == EntityState.Detached)
            {
                this.dbSet.Attach(entity);
            }
            dbEntityEntry.State = EntityState.Modified;
            ;
        }
    }
}