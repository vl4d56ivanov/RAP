﻿using System.ComponentModel.DataAnnotations;

namespace RAP.UI.Models
{
    public class ServiceViewModel
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public string Logo { get; set; }

        public int SrviceTypeId { get; set; }

        [Display(Name = "Service type")]
        public ServiceTypeViewModel ServiceType { get; set; }
    }
}