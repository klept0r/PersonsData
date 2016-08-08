namespace PersonsDataWebApi.Controllers
{
    using System.Collections.Generic;
    using System.Web.Http;
    using System.Web.Http.Cors;

    using PersonsDataWebApi.Class;
    using PersonsDataWebApi.Class.DTO;
    using PersonsDataWebApi.Interface;

    public class LocationController : ApiController
    {
        //public LocationController(IPersonDataUoW uow)
        //{
        //    this.UoW = uow;
        //}

        [HttpPost]
        [EnableCors("http://localhost:9345", "*", "*")]
        [ActionName("GetLocations")]
        public List<DTOLocation> GetLocations()
        {
            var puow = new PersonsDataUoW(new RepositoryProvider(new RepositoryFactories()));
            return new UoWApi(puow).GetLocations();
        }
    }
}