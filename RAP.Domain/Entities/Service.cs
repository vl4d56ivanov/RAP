using System.Collections.Generic;

namespace RAP.Domain.Entities
{
    public class Service
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Logo { get; set; }

        public int ServiceTypeId { get; set; }
        public ServiceType ServiceType { get; set; }

        public ICollection<Appointment> Appointments { get; set; }

        public Service()
        {
            Appointments = new List<Appointment>();
        }
    }
}