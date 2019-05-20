using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RAP.UI.Models
{
    public class AppointmentViewModel
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }
        public string Description { get; set; }

        [Display(Name = "Service")]
        public int ServiceId { get; set; }
        public ServiceViewModel Service { get; set; }

        [Required]
        [Display(Name = "Patient")]
        public int PatientId { get; set; }
        public PatientViewModel Patient { get; set; }

        [Required]
        [Display(Name = "Employee")]
        public int EmployeeId { get; set; }
        public EmployeeViewModel Employee { get; set; }
    }
}