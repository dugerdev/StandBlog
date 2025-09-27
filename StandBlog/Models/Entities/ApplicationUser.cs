using Microsoft.AspNetCore.Identity;

namespace StandBlog.Models.Entities;

public class ApplicationUser
    : IdentityUser
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public DateOnly DateOfBirth { get; set; }
    public DateTimeOffset LastLogin { get; set; }
    public bool IsActive { get; set; }
    public DateTimeOffset CreatedOn { get; set; }
    public DateTimeOffset? ModifiedOn { get; set; }
    public DateTimeOffset? DeletedOn { get; set; }

}
