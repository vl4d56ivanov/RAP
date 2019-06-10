using RAP.Domain.Util;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace RAP.Domain.Entities
{
    public class Employee
    {
        public int Id { get; set; }
        public string Photo { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }
        public string MName { get; set; }
        public string Phone { get; set; }
        public string Position { get; set; }
        public AccessLevel AccessLevel { get; set; }

        public ICollection<Appointment> Appointments { get; set; }
        public ICollection<Analyze> Analyzes { get; set; }

        public Employee()
        {
            Appointments = new List<Appointment>();
            Analyzes = new List<Analyze>();
        }
    }
}