using System.Collections.Generic;

namespace RAP.Domain.Entities
{
    public class Address
    {
        public int Id { get; set; }
        public string Sity { get; set; }
        public string Street { get; set; }
        public string Home { get; set; }
        public string Flat { get; set; }

        ICollection<Patient> Patients { get; set; }

        public Address()
        {
            Patients = new List<Patient>();
        }
    }
}