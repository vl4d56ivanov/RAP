using System.Collections.Generic;

namespace RAP.Domain.Entities
{
    public class ServiceType
    {
        public int Id { get; set; }
        public string Name { get; set; }

        ICollection<Service> Services { get; set; }

        public ServiceType()
        {
            Services = new List<Service>();
        }
    }
}