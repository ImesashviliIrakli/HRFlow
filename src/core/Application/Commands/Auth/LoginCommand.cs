using Application.Models.Identity;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Application.Commands.Auth;

public class LoginCommand : IRequest<LoginResponse>
{
    [Required]
    public required string Email { get; set; }
    [Required]
    public required string Password { get; set; }
}
