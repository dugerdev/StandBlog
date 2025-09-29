using Microsoft.AspNetCore.Identity;

namespace StandBlog.Models.Entities
{
    public class ApplicationUser : IdentityUser
    {
        // Kişisel bilgiler
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public DateOnly DateOfBirth { get; set; }

        // Hesap durumu
        public bool IsActive { get; set; }
        public DateTimeOffset LastLogin { get; set; }

        // Zaman damgaları
        public DateTimeOffset CreatedOn { get; set; }
        public DateTimeOffset? ModifiedOn { get; set; }
        public DateTimeOffset? DeletedOn { get; set; }
    }
}
