using System;
namespace PersonsDataWebApi.Interface
{
    using PersonsDataWebApi.Interface.Repositories;

    public interface IPersonDataUoW : IDisposable
    {
        IPersonRepository PersonRep { get; }

        ILocationRepository LocationRep { get; }

        IAddressRepository AddressRep { get; }

        T GetRepo<T>() where T : class;

        void Commit();
    }
}
