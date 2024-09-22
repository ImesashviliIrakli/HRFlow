using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Application.Models.Identity;

public class LoginRequest
{
    [Required]
    public required string Email { get; set; }
    [Required]
    public required string Password { get; set; }
}
