namespace RAP.Domain.Entities
{
    public class Appointment
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public int ServiceId { get; set; }
        public Service Service { get; set; }

        public int PatientId { get; set; }
        public Patient Patient { get; set; }

        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
    }
}