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
        [Display(Name = "First Name")]
        public string FName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LName { get; set; }

        [Display(Name = "Middle Name")]
        public string MName { get; set; }

        [Required]
        [Display(Name = "Phone")]
        [StringLength(20, MinimumLength = 2)]
        public string Phone { get; set; }

        public int? AddressId { get; set; }

        [Display(Name = "Address")]
        public AddressViewModel Address { get; set; }

        public int? Address2Id { get; set; }

        [Display(Name = "Address 2")]
        public AddressViewModel Address2 { get; set; }

        public ICollection<AppointmentViewModel> Appointments { get; set; }
    }
}