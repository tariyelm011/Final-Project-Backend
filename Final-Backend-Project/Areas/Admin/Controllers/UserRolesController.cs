using Domain.Entity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Service.ViewModels.User;

namespace Final_Backend_Project.Areas.Admin.Controllers;

[Area("Admin")]
public class UserRolesController : Controller
{
    private readonly UserManager<AppUser> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;

    public UserRolesController(RoleManager<IdentityRole> roleManager, UserManager<AppUser> userManager)
    {
        _roleManager = roleManager;
        _userManager = userManager;
    }
    public async Task<IActionResult> Index()
    {
        var users = _userManager.Users.ToList();
        var userRolesViewModel = new List<UserWithRoleVM>();

        foreach (var user in users)
        {
            var roles = await _userManager.GetRolesAsync(user);

            if (roles.Contains("Admin")) continue;

            userRolesViewModel.Add(new UserWithRoleVM
            {
                Id = user.Id,
                Email = user.Email,
                Role = roles.FirstOrDefault() ?? "None"
            });
        }

        return View(userRolesViewModel);
    }


    public async Task<IActionResult> ChangeRole(string userId)
    {
        var user = await _userManager.FindByIdAsync(userId);
        var roles = _roleManager.Roles
            .Where(r => r.Name != "Admin")
            .Select(r => r.Name)
            .ToList();

        var currentRoles = await _userManager.GetRolesAsync(user);

        var model = new ChangeUserRoleVM
        {
            UserId = user.Id,
            Email = user.Email,
            CurrentRole = currentRoles.FirstOrDefault(),
            AllRoles = roles
        };

        return View(model);
    }


    [HttpPost]
    public async Task<IActionResult> ChangeRole(ChangeUserRoleVM model)
    {
        if (model.SelectedRole == "Admin")
        {
            return BadRequest("Admin roles cant chooese");
        }

        var user = await _userManager.FindByIdAsync(model.UserId);
        var currentRoles = await _userManager.GetRolesAsync(user);

        if (currentRoles.Any())
        {
            await _userManager.RemoveFromRolesAsync(user, currentRoles);
        }

        await _userManager.AddToRoleAsync(user, model.SelectedRole);

        return RedirectToAction(nameof(Index));
    }

}