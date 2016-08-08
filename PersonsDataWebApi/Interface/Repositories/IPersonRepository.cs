namespace PersonsDataWebApi.Interface.Repositories
{
    public interface IPersonRepository : IRepository<Person>
    {
        void InsertNewPerson(Person entity);
    }
}