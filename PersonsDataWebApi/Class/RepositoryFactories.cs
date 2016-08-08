namespace PersonsDataWebApi.Class
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;

    using PersonsDataWebApi.Class.Repositories;
    using PersonsDataWebApi.Interface.Repositories;

    public class RepositoryFactories
    {
        private readonly IDictionary<Type, Func<DbContext, object>> repositoryFactories;

        public RepositoryFactories()
        {
            this.repositoryFactories = this.GetPersonsDataFactories();
        }

        private IDictionary<Type, Func<DbContext, object>> GetPersonsDataFactories()
        {
            return new Dictionary<Type, Func<DbContext, object>>
                   {
                       {
                           typeof(IPersonRepository),
                           dbContext => new PersonRepository(dbContext)
                       },
                       {
                           typeof(ILocationRepository),
                           dbContext => new LocationRepository(dbContext)
                       },
                       {
                           typeof(IAddressRepository),
                           dbContext => new AddressRepository(dbContext)
                       }
                   };
        }

        internal Func<DbContext, object> GetRepositoryFactory<T>()
        {
            Func<DbContext, object> factory;
            this.repositoryFactories.TryGetValue(typeof(T), out factory);
            return factory;
        }
    }
}