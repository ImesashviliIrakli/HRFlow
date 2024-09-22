using Application.Models.Identity;

namespace Application.Interfaces;

public interface IAuthService
{
    Task<LoginResponse> LoginAsync(LoginRequest loginRequest);
    Task<RegistrationResponse> RegisterAsync(RegistrationRequest registrationRequest);
}
