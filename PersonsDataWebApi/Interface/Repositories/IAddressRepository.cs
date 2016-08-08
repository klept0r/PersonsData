namespace PersonsDataWebApi.Interface.Repositories
{
    public interface IAddressRepository : IRepository<Address>
    {
        void InsertNewAddress(Address entity);
    }
}