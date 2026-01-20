using Microsoft.AspNetCore.Identity;
using Microsoft.Identity.Client;
using WebApplication1.Models;
using WebApplication1.ViewModels.Identity;

namespace WebApplication1.Services.Account;

public class AccountService : IAccountService
{
    private readonly UserManager<User>  _userManager;
    private readonly SignInManager<User> _signInManager;
    
    public AccountService(UserManager<User> userManager, SignInManager<User> signInManager)
    {
        _userManager=userManager;
        _signInManager=signInManager;
    }
    public async Task<IdentityResult> RegisterAsync(RegisterVM model)
    {
        var user = new User{UserName = model.Username, Email = model.Email, Name =  model.Name,Surname =   model.Surname};
        return await _userManager.CreateAsync(user, model.Password);
    }

    public async Task<SignInResult> LoginAsync(LoginVM login)
    {
        return await _signInManager.PasswordSignInAsync(login.Email, login.Password, false, true);
    }

    public async Task LogoutAsync()
    {
         await _signInManager.SignOutAsync();
    }
}