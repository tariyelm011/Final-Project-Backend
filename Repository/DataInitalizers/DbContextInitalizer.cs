using Domain.Entity;
using Domain.Enum;
using Microsoft.AspNetCore.Identity;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Repository.Data;

namespace Repository.DataInitalizers;

public class DbContextInitalizer
{
    private readonly AppDbContext _context;
    private readonly UserManager<AppUser> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;
    private readonly IConfiguration _configuration;
    private readonly AppUser _admin;

    public DbContextInitalizer(AppDbContext context, UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager, IConfiguration configuration)
    {
        _context = context;
        _userManager = userManager;
        _roleManager = roleManager;
        _configuration = configuration;
        _admin = _configuration.GetSection("AdminSettings").Get<AppUser>() ?? new();
    }

    public async Task InitDatabaseAsync()
    {
        await _context.Database.MigrateAsync();
        await _createRolesAsync();
        await _createAdminAsync();
    }

    private async Task _createRolesAsync()
    {
        foreach (string role in Enum.GetNames(typeof(IdentityRoles)))
        {
            var isExist = await _roleManager.Roles.AnyAsync(x => x.Name == role);
            if (isExist)
                continue;

            IdentityRole identityRole = new() { Name = role };
            await _roleManager.CreateAsync(identityRole);
        }
    }


    private async Task _createAdminAsync()
    {
        var isExist = await _userManager.Users.AnyAsync(x => x.UserName == _admin.UserName);
        if (isExist)
            return;

        var result = await _userManager.CreateAsync(_admin, _configuration["AdminSettings:Password"]!);
        var password = _configuration["AdminSettings:Password"];

        var user = await _userManager.FindByNameAsync(_admin.UserName ?? "");

        if (user is not null)
            await _userManager.AddToRoleAsync(user, IdentityRoles.Admin.ToString());
    }
}
