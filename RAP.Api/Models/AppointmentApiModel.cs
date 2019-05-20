namespace RAP.Api.Models
{
    public class AppointmentApiModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public int ServiceId { get; set; }
        public ServiceApiModel Service { get; set; }

        public int PatientId { get; set; }
        public PatientApiModel Patient { get; set; }

        public int EmployeeId { get; set; }
        public EmployeeApiModel Employee { get; set; }
    }
}