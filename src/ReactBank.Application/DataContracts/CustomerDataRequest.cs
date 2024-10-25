using ReactBank.Application.CustomAttributes;

namespace ReactBank.Application.DataContracts
{
    public class CustomerDataRequest
    {
        [RequiredValidation]
        public string Name { get; set; }
        [RequiredValidation]
        public string Email { get; set; }
        [RequiredValidation]
        public string Phone { get; set; }
        [RequiredValidation]
        public string StreetAddress { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        [RequiredValidation]
        public string ZipCode { get; set; }
        public DateTime DateOfBirth { get; set; }
        [RequiredValidation]
        public string IdentityDocument { get; set; }
    }
}
