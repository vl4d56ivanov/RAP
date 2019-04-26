using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RAP.UI.Models
{
    public class PatientViewModel
    {
        public int Id { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }
        public string MName { get; set; }
        public string Phone { get; set; }

        public int AddressId { get; set; }
        public AddressViewModel Address { get; set; }

        public int Address2Id { get; set; }
        public AddressViewModel Address2 { get; set; }
    }
}