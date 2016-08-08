namespace PersonsDataWebApi.Class
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;

    using PersonsDataWebApi.Interface;

    public class RepositoryProvider : IRepositoryProvider
    {
        private readonly RepositoryFactories repositoryFactories;

        protected Dictionary<Type, object> repositories;

        public RepositoryProvider(RepositoryFactories repositoryFactories)
        {
            this.repositoryFactories = repositoryFactories;
            this.repositories = new Dictionary<Type, object>();
        }

        public DbContext dbContext { get; set; }

        public virtual T GetRepository<T>(Func<DbContext, object> factory = null) where T : class
        {
            object repoObj;
            this.repositories.TryGetValue(typeof(T), out repoObj);
            if (repoObj != null)
            {
                return (T)repoObj;
            }
            return this.MakeRepository<T>(factory, this.dbContext);
        }

        private T MakeRepository<T>(Func<DbContext, object> factory, DbContext _dbContext)
        {
            var f = factory ?? this.repositoryFactories.GetRepositoryFactory<T>();
            if (f == null)
            {
                new ErrorHandling().LogError("No repository for type:" + typeof(T).FullName);
            }

            var repo = (T)f(_dbContext);
            this.repositories[typeof(T)] = repo;
            return repo;
        }
    }
}