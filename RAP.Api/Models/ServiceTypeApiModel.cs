using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RAP.Api.Models
{
    public class ServiceTypeApiModel
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}