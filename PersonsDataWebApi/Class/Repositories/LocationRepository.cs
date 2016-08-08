namespace PersonsDataWebApi.Class.Repositories
{
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;

    using PersonsDataWebApi.Class.DTO;
    using PersonsDataWebApi.Interface.Repositories;

    public class LocationRepository : EFRepository<City>, ILocationRepository
    {
        public LocationRepository(DbContext context)
            : base(context)
        {
        }

        public List<DTOLocation> GetLocations()
        {
            return (from c in this.SelectAll()
                select
                    new DTOLocation
                    {
                        CountyId = c.CountyId,
                        CountyName = c.County.Name,
                        DistrictId = c.DistrictId,
                        DistrictName = c.District.Name,
                        CityId = c.Id,
                        CityName = c.City1
                    }).ToList();
        }
    }
}