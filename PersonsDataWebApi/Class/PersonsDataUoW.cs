namespace PersonsDataWebApi.Class
{
    using System;
    using System.Data.Entity;

    using PersonsDataWebApi.Interface;
    using PersonsDataWebApi.Interface.Repositories;

    public class PersonsDataUoW : IPersonDataUoW, IDisposable
    {
        public PersonsDataUoW(IRepositoryProvider repositoryProvider)
        {
            this.dbContext = new PersonsDataDBEntities();
            repositoryProvider.dbContext = this.dbContext;
            this.RepositoryProvider = repositoryProvider;
        }

        private DbContext dbContext { get; set; }

        protected IRepositoryProvider RepositoryProvider { get; set; }

        public IPersonRepository PersonRep
        {
            get
            {
                return this.GetRepo<IPersonRepository>();
            }
        }

        public ILocationRepository LocationRep
        {
            get
            {
                return this.GetRepo<ILocationRepository>();
            }
        }

        public IAddressRepository AddressRep
        {
            get
            {
                return this.GetRepo<IAddressRepository>();
            }
        }

        public T GetRepo<T>() where T : class
        {
            return this.RepositoryProvider.GetRepository<T>();
        }

        public void Commit()
        {
            this.dbContext.SaveChanges();
        }

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (this.dbContext != null)
                {
                    this.dbContext.Dispose();
                }
            }
        }
    }
}