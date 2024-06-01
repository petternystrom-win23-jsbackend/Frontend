using Microsoft.AspNetCore.Identity;

namespace Frontend.Data
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string? ProfilePicture { get; set; } = "avatar.svg";
        public string? Bio { get; set; }
        public int? AddressId { get; set; }
        public AddressEntity? Address { get; set; }
    }

    public class AddressEntity
    {
        public int Id { get; set; }
        public string? AddressLine_1 { get; set; }
        public string? AddressLine_2 { get; set; }
        public string? PostalCode { get; set; }
        public string? City { get; set; }

    }
}
