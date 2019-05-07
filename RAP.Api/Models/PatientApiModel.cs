using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RAP.Api.Models
{
    public class PatientApiModel
    {
        public int Id { get; set; }

        public string FName { get; set; }

        public string LName { get; set; }

        public string MName { get; set; }

        public string Phone { get; set; }

        public int? AddressId { get; set; }

        public AddressApiModel Address { get; set; }

        public int? Address2Id { get; set; }

        public AddressApiModel Address2 { get; set; }
    }
}