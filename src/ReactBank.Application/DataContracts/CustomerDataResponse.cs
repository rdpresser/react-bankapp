namespace ReactBank.Application.DataContracts
{
    public class CustomerDataResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string StreetAddress { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public string DateOfBirth { get; set; }
        public string IdentityDocument { get; set; }
    }
}
