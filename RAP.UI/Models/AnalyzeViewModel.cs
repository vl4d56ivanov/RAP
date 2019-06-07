using RAP.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RAP.UI.Models
{
    public class AnalyzeViewModel
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        public string Description { get; set; }

        [Required]
        public string Parameters { get; set; }

        [Required]
        public DateTime DateCreated { get; set; }

        //TODO: Doctor?
        //public int DoctorId { get; set; }
        //public Doctor Doctor { get; set; }

        [Required]
        [Display(Name = "Patient")]
        public int PatientId { get; set; }
        public Patient Patient { get; set; }
    }
}