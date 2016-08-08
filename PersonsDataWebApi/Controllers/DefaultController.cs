namespace PersonsDataWebApi.Controllers
{
    using System.Web.Http;
    using System.Web.Http.Cors;

    public class DefaultController : ApiController
    {
        [HttpPost]
        [EnableCors("http://localhost:9345", "*", "*")]
        [ActionName("Default")]
        public void Default()
        {
        }
    }
}