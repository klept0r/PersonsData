namespace PersonsDataWebApi.Class.DTO
{
    using System;

    public class DTOPerson
    {
        public string Name { get; set; }

        public string Surname { get; set; }

        public DateTime YearOfBirth { get; set; }

        public DTOAddress ResidenceAddress { get; set; }

        public DTOAddress CorrespondenceAddress { get; set; }
    }
}