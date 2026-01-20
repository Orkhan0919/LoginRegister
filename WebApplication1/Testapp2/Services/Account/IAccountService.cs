using Microsoft.AspNetCore.Identity;
using WebApplication1.ViewModels.Identity;

namespace WebApplication1.Services.Account;

public interface IAccountService
{
    Task<IdentityResult> RegisterAsync(RegisterVM register);
    Task<SignInResult> LoginAsync(LoginVM login);
    Task LogoutAsync();
}