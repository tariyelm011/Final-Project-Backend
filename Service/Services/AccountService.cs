using Domain.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Service.Dtos.AccountDto;
using Service.Helpers.Exceptions;
using Service.Services.Interface;
using System.Security.Claims;

namespace Service.Services;

public class AccountService : IAccountService
{
    private readonly UserManager<AppUser> _userManager;
    private readonly SignInManager<AppUser> _signInManager;
    private readonly IEmailService _emailService;
    private readonly ICloudinaryManager _cloudinaryManager;
    private readonly IHttpContextAccessor _http;

    public AccountService(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, IEmailService emailService, ICloudinaryManager cloudinaryManager, IHttpContextAccessor http)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _emailService = emailService;
        _cloudinaryManager = cloudinaryManager;
        _http = http;
    }


    public async Task<string> GetRedirectUrlAfterLogin(AppUser user)
    {
        if (await _userManager.IsInRoleAsync(user, "Admin"))
        {
            return "/Admin/Dashboard";
        }

        return "/Home/Index";
    }

    public async Task<AppUser> FindUser()
    {
        var userid = _http.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (userid is null)
        {
            throw new NotFoundException("user not found");

        }
        var user = await FindUserByIdAsync(userid);
        if (user == null)
        {
            throw new NotFoundException("user not found");
        }
        return user;
    }

    public async Task<bool> UserHasPasswordAsync(AppUser user)
    {
        return await _userManager.HasPasswordAsync(user);
    }
    public async Task<IdentityResult> RegisterUserAsync(RegisterVM registerDto)
    {
        var user = new AppUser
        {
            UserName = registerDto.UserName,
            Email = registerDto.Email,
            FullName = registerDto.FullName,
            EmailConfirmed = false,
        };

        var result = await _userManager.CreateAsync(user, registerDto.Password);

        if (!result.Succeeded)
            return result;

        await _userManager.AddToRoleAsync(user, "User");

        return result;
    }

    public async Task<string> GenerateEmailConfirmationTokenAsync(AppUser user) =>
        await _userManager.GenerateEmailConfirmationTokenAsync(user);

    public async Task<AppUser> FindUserByEmailAsync(string email)
    {
        if (email == null)
        {
            throw new NotFoundException("not found");
        }

        var user = await _userManager.FindByEmailAsync(email);

        if (user is null)
        {
            throw new NotFoundException("not found");
        }

        return user;
    }

    public async Task<AppUser> FindUserByIdAsync(string userId)
    {
        if (userId == null)
        {
            throw new NotFoundException("not found");
        }
        var user = await _userManager.FindByIdAsync(userId);
        if (user is null)
        {
            throw new NotFoundException("not found");

        }
        return user;
    }

    public async Task<IdentityResult> ConfirmEmailAsync(AppUser user, string token) =>
        await _userManager.ConfirmEmailAsync(user, token);

    public async Task<SignInResult> LoginUserAsync(LoginVM loginDto)
    {
        var user = await _userManager.FindByEmailAsync(loginDto.Email);
        if (user == null || !user.EmailConfirmed )
            return SignInResult.Failed;

        return await _signInManager.PasswordSignInAsync(user, loginDto.Password, true, true);
    }

    public async Task LogoutUserAsync() =>
        await _signInManager.SignOutAsync();



    public string GetId()
    {
        var userid = _http.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (userid is null)
        {
            throw new NotFoundException("user not found");
        }
        return userid;

    }

    public async Task SendEmailAsync(string to, string subject, string body)
    {
        _emailService.SendEmail(to, subject, body);
    }
    public async Task<string> GeneratePasswordResetTokenAsync(AppUser user) =>
    await _userManager.GeneratePasswordResetTokenAsync(user);

    public async Task<IdentityResult> ResetPasswordAsync(AppUser user, string token, string newPassword) =>
        await _userManager.ResetPasswordAsync(user, token, newPassword);

    public async Task<IdentityResult> ChangePasswordAsync(AppUser user, string oldPassword, string newPassword)
    {
        var hasPassword = await UserHasPasswordAsync(user);
        if (hasPassword)
        {
            if (string.IsNullOrEmpty(oldPassword))
            {
                throw new Exception("Old password is required.");
            }

            return await _userManager.ChangePasswordAsync(user, oldPassword, newPassword);
        }
        else
        {

            return await _userManager.AddPasswordAsync(user, newPassword);
        }
    }
}