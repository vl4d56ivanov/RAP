using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RAP.UI.Models
{
    public class PatientViewModel
    {
        public int Id { get; set; }

        [Required]
        public string FName { get; set; }

        [Required]
        public string LName { get; set; }
        public string MName { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 2)]
        public string Phone { get; set; }

        [Required]
        public int AddressId { get; set; }
        public AddressViewModel Address { get; set; }

        public int? Address2Id { get; set; }
        public AddressViewModel Address2 { get; set; }
    }
}