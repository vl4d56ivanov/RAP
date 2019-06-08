using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAP.Domain.Entities
{
    public class Analyze
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Parameters { get; set; }
        public DateTime DateCreated { get; set; }

        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }

        public int PatientId { get; set; }
        public Patient Patient { get; set; }
    }
}
