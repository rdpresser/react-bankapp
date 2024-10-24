using ReactBank.Domain.Core.Models;

namespace ReactBank.Domain.Models
{
    public class Customer : BaseEntity
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string StreetAddress { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string IdentityDocument { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
