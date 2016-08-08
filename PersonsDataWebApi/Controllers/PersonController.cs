namespace PersonsDataWebApi.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Http;
    using System.Web.Http.Cors;

    using PersonsDataWebApi.Class;
    using PersonsDataWebApi.Class.DTO;

    public class PersonController : ApiController
    {
        //public PersonController(IPersonDataUoW uow)
        //{
        //    this.UoW = uow;
        //}

        [HttpPost]
        [EnableCors("http://localhost:9345", "*", "*")]
        [ActionName("SetNewPerson")]
        public void SetNewPerson(IEnumerable<DTOPerson> person)
        {
            var puow = new PersonsDataUoW(new RepositoryProvider(new RepositoryFactories()));
            new UoWApi(puow).InsertPerson(person.FirstOrDefault());
        }
    }
}