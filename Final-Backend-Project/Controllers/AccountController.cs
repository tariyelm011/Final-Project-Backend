using Domain.Entity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Service.Dtos.AccountDto;
using Service.Services.Interface;

namespace Final_Backend_Project.Controllers;

public class AccountController : Controller
{
    private readonly IAccountService _accountService;
    private readonly UserManager<AppUser> _userManager;


    public AccountController(IAccountService accountService, UserManager<AppUser> userManager)
    {
        _accountService = accountService;
        _userManager = userManager;
    }

    public IActionResult Register() => View();

    [HttpPost]
    public async Task<IActionResult> Register(RegisterVM registerDto)
    {
        if (!ModelState.IsValid)
            return View();

        var result = await _accountService.RegisterUserAsync(registerDto);


        if (!result.Succeeded)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }
            return View();
        }


        var user = await _accountService.FindUserByEmailAsync(registerDto.Email);
        var token = await _accountService.GenerateEmailConfirmationTokenAsync(user);

        var confirmationLink = Url.Action("ConfirmEmail", "Account", new { userId = user.Id, token }, Request.Scheme);
        await _accountService.SendEmailAsync(user.Email, "Email Confirmation",
            $"Please confirm your email by clicking <a href='{confirmationLink}'>here</a>.");

        return RedirectToAction("Login");
    }

    public async Task<IActionResult> ConfirmEmail(string userId, string token)
    {
        if (userId == null || token == null)
            return BadRequest("Invalid email confirmation request.");

        var user = await _accountService.FindUserByIdAsync(userId);
        if (user == null)
            return NotFound("User not found.");

        var result = await _accountService.ConfirmEmailAsync(user, token);
        if (result.Succeeded)
            return View("ConfirmEmail");

        return BadRequest("Email confirmation failed.");
    }

    public IActionResult Login() => View();

    [HttpPost]
    public async Task<IActionResult> Login(LoginVM loginDto)
    {
        if (!ModelState.IsValid)
            return View();

        var result = await _accountService.LoginUserAsync(loginDto);
        if (!result.Succeeded)
        {
            var userLogin = await _accountService.FindUserByEmailAsync(loginDto.Email);
            if (userLogin != null)
            {
                ModelState.AddModelError("", "Your account has been disabled. Please contact support.");
            }
            else
            {
                ModelState.AddModelError("", "Username or password is incorrect.");
            }
            return View();
        }

        var user = await _accountService.FindUserByEmailAsync(loginDto.Email);
        var redirectUrl = await _accountService.GetRedirectUrlAfterLogin(user);

        return Redirect(redirectUrl);
    }

    public async Task<IActionResult> Logout()
    {
        await _accountService.LogoutUserAsync();
        return RedirectToAction("Index", "Home");
    }



    public IActionResult ForgotPassword() => View();

    [HttpPost]
    public async Task<IActionResult> ForgotPassword(ForgotPasswordVM forgotPasswordDto)
    {
        if (!ModelState.IsValid)
            return View();

        var user = await _accountService.FindUserByEmailAsync(forgotPasswordDto.Email);

        var token = await _accountService.GeneratePasswordResetTokenAsync(user);

        var resetLink = Url.Action("ResetPassword", "Account", new { token, email = user.Email }, Request.Scheme);

        await _accountService.SendEmailAsync(user.Email, "Password Reset",
            $"Click <a href='{resetLink}'>here</a> to reset your password.");


        return RedirectToAction("Login");
    }

    public IActionResult ResetPassword(string token, string email)
    {
        if (token == null || email == null)
            return BadRequest("Invalid password reset request.");

        var model = new ResetPasswordVM { Token = token, Email = email };
        return View(model);
    }


    [HttpPost]
    public async Task<IActionResult> ResetPassword(ResetPasswordVM resetPasswordDto)
    {
        if (!ModelState.IsValid)
            return View(resetPasswordDto);

        var user = await _userManager.FindByEmailAsync(resetPasswordDto.Email);

        var result = await _accountService.ResetPasswordAsync(user, resetPasswordDto.Token, resetPasswordDto.NewPassword);
        if (!result.Succeeded)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }
            return View(resetPasswordDto);
        }

        return RedirectToAction("Login");
    }

}
