using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RAP.Api.Models
{
    public class ServiceApiModel
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public string Logo { get; set; }

        public int ServiceTypeId { get; set; }
        public ServiceTypeApiModel ServiceType { get; set; }
    }
}