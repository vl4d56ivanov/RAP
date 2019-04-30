using System.Collections.Generic;

namespace RAP.UI.Models
{
    public class AddressViewModel
    {
        public int Id { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string Home { get; set; }
        public string Flat { get; set; }

        ICollection<PatientViewModel> Patients { get; set; }
    }
}