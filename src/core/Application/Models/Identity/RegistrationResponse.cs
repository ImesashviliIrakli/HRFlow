using System.ComponentModel.DataAnnotations;

namespace Application.Models.Identity;

public class RegistrationResponse
{
    [Required]
    public string UserId { get; set; }

    public RegistrationResponse(string userId)
    {
        UserId = userId;
    }
}
