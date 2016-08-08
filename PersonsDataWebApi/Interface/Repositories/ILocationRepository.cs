namespace PersonsDataWebApi.Interface.Repositories
{
    using System.Collections.Generic;

    using PersonsDataWebApi.Class.DTO;

    public interface ILocationRepository : IRepository<City>
    {
        List<DTOLocation> GetLocations();
    }
}