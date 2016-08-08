namespace PersonsDataWebApi.Class.Repositories
{
    using System.Data.Entity;

    using PersonsDataWebApi.Interface.Repositories;

    public class AddressRepository : EFRepository<Address>, IAddressRepository
    {
        public AddressRepository(DbContext context)
            : base(context)
        {
        }

        public void InsertNewAddress(Address entity)
        {
            this.Insert(entity);
        }
    }
}