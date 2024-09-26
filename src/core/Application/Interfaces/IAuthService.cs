using Application.Models.Identity;

namespace Application.Interfaces;

public interface IAuthService
{
    Task<LoginResponse> LoginAsync(string email, string password);
    Task<RegistrationResponse> RegisterAsync(RegistrationRequest registrationRequest);
}
