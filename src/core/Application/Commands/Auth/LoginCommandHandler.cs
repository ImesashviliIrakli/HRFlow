using Application.Interfaces;
using Application.Models.Identity;
using MediatR;

namespace Application.Commands.Auth;

public class LoginCommandHandler : IRequestHandler<LoginCommand, LoginResponse>
{
    private readonly IAuthService _authService;
    public LoginCommandHandler(IAuthService authService)
    {
        _authService = authService;
    }
    public async Task<LoginResponse> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        var login = await _authService.LoginAsync(request.Email, request.Password);

        return login;
    }
}
