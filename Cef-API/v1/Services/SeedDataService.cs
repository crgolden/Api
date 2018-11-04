namespace Cef_API.v1.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Claims;
    using System.Threading.Tasks;
    using Core.v1.Models;
    using Core.v1.Relationships;
    using Interfaces;
    using Options;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Options;

    public class SeedDataService : ISeedDataService
    {
        private readonly DbContext _context;
        private readonly UsersOptions _usersOptions;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public SeedDataService(DbContext context, IOptions<UsersOptions> usersOptions,
            UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _context = context;
            _usersOptions = usersOptions.Value;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        private static IEnumerable<Claim> Claims =>
            new List<Claim>
            {
            };

        private static IEnumerable<IdentityRole> Roles => new List<IdentityRole>
        {
            new IdentityRole("User"),
            new IdentityRole("Admin")
        };

        public async Task SeedData()
        {
            if (!await _roleManager.Roles.AnyAsync()) await CreateRolesAsync();
            if (!await _userManager.Users.AnyAsync()) await CreateUsersAsync();
        }

        private async Task CreateRolesAsync()
        {
            using (_roleManager)
            {
                foreach (var role in Roles)
                {
                    await _roleManager.CreateAsync(role);
                }
            }
        }

        private async Task CreateUsersAsync()
        {
            using (_userManager)
            {
                foreach (var user in _usersOptions.Users)
                {
                    var identityUser = new IdentityUser
                    {
                        UserName = user.Email,
                        Email = user.Email,
                        SecurityStamp = $"{Guid.NewGuid()}"
                    };
                    await _userManager.CreateAsync(identityUser, user.Password);
                    await _userManager.AddToRolesAsync(identityUser, Roles.Select(role => role.Name));
                    await _userManager.AddClaimsAsync(identityUser, Claims);
                }
            }
        }
    }
}