using Application.Interfaces;
using Application.Models.Identity;
using Identity.Data;
using Identity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Identity;

public class AuthService : IAuthService
{
    private readonly AuthDbContext _context;
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly SignInManager<ApplicationUser> _signInManager;
    private readonly RoleManager<IdentityRole> _roleManager;
    private readonly JwtOptions _jwtOptions;
    private readonly ILogger<AuthService> _logger;

    public AuthService(
            AuthDbContext context,
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            RoleManager<IdentityRole> roleManager,
            IOptions<JwtOptions> jwtOptions,
            ILogger<AuthService> logger
        )
    {
        _context = context;
        _userManager = userManager;
        _signInManager = signInManager;
        _roleManager = roleManager;
        _jwtOptions = jwtOptions.Value;
        _logger = logger;
    }


    public async Task<LoginResponse> LoginAsync(string email, string password)
    {
        var user = await _userManager.FindByEmailAsync(email);

        if (user is null)
            throw new Exception("Not Found");

        var result = await _signInManager.CheckPasswordSignInAsync(user, password, false);

        if (result.Succeeded == false)
            throw new Exception($"Error logging in");

        JwtSecurityToken jwt = await GenerateTokenAsync(user);

        var token = new JwtSecurityTokenHandler().WriteToken(jwt);

        return new LoginResponse(token, user.Id);
    }

    public async Task<RegistrationResponse> RegisterAsync(RegistrationRequest registrationRequest)
    {
        using (var transaction = await _context.Database.BeginTransactionAsync())
        {
            try
            {
                var user = new ApplicationUser
                {
                    Email = registrationRequest.Email,
                    UserName = registrationRequest.Email,
                    EmailConfirmed = true,
                    FirstName = registrationRequest.FirstName,
                    LastName = registrationRequest.LastName,
                    SID = registrationRequest.SID
                };

                var createUserResult = await _userManager.CreateAsync(user, registrationRequest.Password);

                if (!createUserResult.Succeeded)
                {
                    await transaction.RollbackAsync();
                    throw new Exception(BuildErrorMessage(createUserResult.Errors));
                }

                var addRoleResult = await _userManager.AddToRoleAsync(user, "Employee");

                if (!addRoleResult.Succeeded)
                {
                    await transaction.RollbackAsync();
                    throw new Exception(BuildErrorMessage(addRoleResult.Errors));
                }

                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Email, user.Email),
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(ClaimTypes.NameIdentifier, user.Id),
                    new Claim(ClaimTypes.Role, "Employee")
                };

                var addClaimsResult = await _userManager.AddClaimsAsync(user, claims);

                if (!addClaimsResult.Succeeded)
                {
                    await transaction.RollbackAsync();
                    throw new Exception(BuildErrorMessage(addClaimsResult.Errors));
                }

                await transaction.CommitAsync();

                _logger.LogInformation($"{registrationRequest.Email} Has been registered successfully");

                return new RegistrationResponse(user.Id);
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                _logger.LogError($"Exception => Couldn't register user {registrationRequest.Email} => Message: {ex.Message}");
                throw new Exception("Registration failed: " + ex.Message);
            }
        }
    }


    private async Task<JwtSecurityToken> GenerateTokenAsync(ApplicationUser user)
    {
        var claims = await _userManager.GetClaimsAsync(user);

        var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtOptions.Key));

        var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

        var jwtSecurityToken = new JwtSecurityToken(
           issuer: _jwtOptions.Issuer,
           audience: _jwtOptions.Audience,
           claims: claims,
           expires: DateTime.Now.AddMinutes(_jwtOptions.DurationInMinutes),
           signingCredentials: signingCredentials);

        return jwtSecurityToken;

    }

    private string BuildErrorMessage(IEnumerable<IdentityError> errors)
    {
        var stringBuilder = new StringBuilder();
        foreach (var error in errors)
        {
            stringBuilder.AppendLine($"• {error.Description}");
        }
        return stringBuilder.ToString();
    }
}
