using System.ComponentModel.DataAnnotations;

namespace Application.Models.Identity;

public class LoginResponse
{
    [Required]
    public string Token { get; set; }
    public string UserId { get; set; }

    public LoginResponse(string token, string userId)
    {
        Token = token;
        UserId = userId;
    }
}
