using Application.Interfaces;
using Application.Interfaces.Messaging;
using Application.Models.Identity;
using Domain.Shared;

namespace Application.Commands.Auth;

public class LoginCommandHandler : ICommandHandler<LoginCommand, LoginResponse>
{
    private readonly IAuthService _authService;
    public LoginCommandHandler(IAuthService authService)
    {
        _authService = authService;
    }
    public async Task<Result<LoginResponse>> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        var login = await _authService.LoginAsync(request.Email, request.Password);

        return login;
    }
}
