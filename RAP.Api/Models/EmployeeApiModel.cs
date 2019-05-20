using RAP.Domain.Util;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RAP.Api.Models
{
    public class EmployeeApiModel
    {
        public int Id { get; set; }

        public string Photo { get; set; }

        [Required]
        public string FName { get; set; }

        [Required]
        public string LName { get; set; }
        
        public string MName { get; set; }

        [Required]
        public string Phone { get; set; }
        
        public string Position { get; set; }

        public AccessLevel AccessLevel { get; set; }
    }
}