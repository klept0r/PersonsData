//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PersonsDataWebApi
{
    using System;
    using System.Collections.Generic;
    
    public partial class Address
    {
        public Address()
        {
            this.People = new HashSet<Person>();
            this.People1 = new HashSet<Person>();
        }
    
        public int Id { get; set; }
        public string Street { get; set; }
        public string Number { get; set; }
        public string PostCode { get; set; }
        public int CityId { get; set; }
    
        public virtual City City { get; set; }
        public virtual ICollection<Person> People { get; set; }
        public virtual ICollection<Person> People1 { get; set; }
    }
}
