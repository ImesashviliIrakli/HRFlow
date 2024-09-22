using Microsoft.AspNetCore.Identity;

namespace Identity.Models;

public class ApplicationUser : IdentityUser
{
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public required string SID { get; set; }
}
