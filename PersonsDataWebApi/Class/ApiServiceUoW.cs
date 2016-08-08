namespace PersonsDataWebApi.Class
{
    using System.Collections.Generic;

    using PersonsDataWebApi.Class.DTO;
    using PersonsDataWebApi.Interface;

    public class UoWApi
    {
        private readonly IPersonDataUoW UoW;

        public UoWApi(IPersonDataUoW uow)
        {
            this.UoW = uow;
        }

        public void InsertPerson(DTOPerson person)
        {
            Person newPerson;
            var residenceAddress = new Address
                                   {
                                       Street = person.ResidenceAddress.Street,
                                       Number = person.ResidenceAddress.Number,
                                       PostCode = person.ResidenceAddress.PostCode,
                                       CityId = person.ResidenceAddress.CityId
                                   };
            this.UoW.AddressRep.InsertNewAddress(residenceAddress);
            this.UoW.Commit();
            if (person.CorrespondenceAddress != null)
            {
                var correspondenceAddress = new Address
                                            {
                                                Street = person.CorrespondenceAddress.Street,
                                                Number = person.CorrespondenceAddress.Number,
                                                PostCode = person.CorrespondenceAddress.PostCode,
                                                CityId = person.CorrespondenceAddress.CityId
                                            };
                this.UoW.AddressRep.InsertNewAddress(correspondenceAddress);
                this.UoW.Commit();
                newPerson = new Person
                            {
                                Name = person.Name,
                                Surname = person.Surname,
                                YearOfBirth = person.YearOfBirth,
                                ResidenceAddressId = residenceAddress.Id,
                                CorrespondenceAddressId = correspondenceAddress.Id
                            };
            }
            else
            {
                newPerson = new Person
                            {
                                Name = person.Name,
                                Surname = person.Surname,
                                YearOfBirth = person.YearOfBirth,
                                ResidenceAddressId = residenceAddress.Id,
                                CorrespondenceAddressId = residenceAddress.Id
                            };
            }

            this.UoW.PersonRep.InsertNewPerson(newPerson);
            this.UoW.Commit();
        }

        public List<DTOLocation> GetLocations()
        {
            return this.UoW.LocationRep.GetLocations();
        }
    }
}