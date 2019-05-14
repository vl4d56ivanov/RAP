using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RAP.UI.Models
{
    public class EmployeeViewModel
    {
        public int Id { get; set; }

        public string Photo { get; set; }

        [Required]
        [Display(Name = "First Name")]
        public string FName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LName { get; set; }

        [Display(Name = "Midddle Name")]
        public string MName { get; set; }

        [Required]
        [Display(Name = "Phone")]
        public string Phone { get; set; }

        public string Position { get; set; }
        public string AccessLevel { get; set; }
    }
}