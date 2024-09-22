using Identity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Identity.Configuration;
public class UserConfiguration : IEntityTypeConfiguration<ApplicationUser>
{
    public void Configure(EntityTypeBuilder<ApplicationUser> builder)
    {
        var hasher = new PasswordHasher<ApplicationUser>();
        builder.HasData(
             new ApplicationUser
             {
                 Id = "8e445865-a24d-4543-a6c6-9443d048cdb9",
                 Email = "admin@localhost.com",
                 NormalizedEmail = "ADMIN@LOCALHOST.COM",
                 UserName = "admin@localhost.com",
                 NormalizedUserName = "ADMIN@LOCALHOST.COM",
                 PasswordHash = hasher.HashPassword(null, "Admin123!"),
                 EmailConfirmed = true,
                 FirstName = "Admin",
                 LastName = "Test",
                 SID = "12345678910"
             }
        );
    }
}