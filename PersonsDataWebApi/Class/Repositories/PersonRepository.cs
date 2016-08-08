namespace PersonsDataWebApi.Class.Repositories
{
    using System.Data.Entity;

    using PersonsDataWebApi.Interface.Repositories;

    public class PersonRepository : EFRepository<Person>, IPersonRepository
    {
        public PersonRepository(DbContext context)
            : base(context)
        {
        }

        public void InsertNewPerson(Person entity)
        {
            this.Insert(entity);
        }
    }
}