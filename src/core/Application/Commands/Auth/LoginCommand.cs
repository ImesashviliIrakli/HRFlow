using Application.Interfaces.Messaging;
using Application.Models.Identity;
using System.ComponentModel.DataAnnotations;

namespace Application.Commands.Auth;

public class LoginCommand : ICommand<LoginResponse>
{
    [Required]
    public required string Email { get; set; }
    [Required]
    public required string Password { get; set; }
}
