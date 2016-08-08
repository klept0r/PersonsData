namespace PersonsDataWebApi.Controllers
{
    using PersonsDataWebApi.Interface;

    public class ApiBaseController
    {
        protected IPersonDataUoW UoW { get; set; }
    }
}