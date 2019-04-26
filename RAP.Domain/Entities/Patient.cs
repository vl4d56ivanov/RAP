namespace RAP.Domain.Entities
{
    public class Patient
    {
        public int Id { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }
        public string MName { get; set; }
        public string Phone { get; set; }
        
        public int AddressId { get; set; }
        public Address Address { get; set; }

        //public int Address2Id { get; set; }
        //public Address Address2 { get; set; }
    }
}