namespace Cef_API.v1.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Claims;
    using System.Threading.Tasks;
    using Data.Models;
    using Interfaces;
    using Options;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Options;

    public class SeedDataService : ISeedDataService
    {
        private readonly DbContext _context;
        private readonly UsersOptions _usersOptions;
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<Role> _roleManager;

        public SeedDataService(DbContext context, IOptions<UsersOptions> usersOptions,
            UserManager<User> userManager, RoleManager<Role> roleManager)
        {
            _context = context;
            _usersOptions = usersOptions.Value;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task SeedDatabase()
        {
            if (!await _roleManager.Roles.AnyAsync()) await CreateRolesAsync();
            if (!await _userManager.Users.AnyAsync()) await CreateUsersAsync();
        }

        private async Task CreateRolesAsync()
        {
            using (_roleManager)
            {
                foreach (var role in SeedData.Roles)
                {
                    await _roleManager.CreateAsync(role);
                }
            }
        }

        private async Task CreateUsersAsync()
        {
            using (_userManager)
            {
                foreach (var usersOption in _usersOptions.Users)
                {
                    var user = new User
                    {
                        UserName = usersOption.Email,
                        Email = usersOption.Email,
                        FirstName = usersOption.FirstName,
                        LastName = usersOption.LastName,
                        SecurityStamp = $"{Guid.NewGuid()}"
                    };
                    await _userManager.CreateAsync(user, usersOption.Password);
                    await _userManager.AddToRolesAsync(user, SeedData.Roles.Select(role => role.Name));
                    await _userManager.AddClaimsAsync(user, SeedData.Claims);
                }
            }
        }
    }

    public static class SeedData
    {
        public static IEnumerable<Claim> Claims => new List<Claim>
        {
        };

        public static IEnumerable<Role> Roles => new List<Role>
        {
            new Role("User"),
            new Role("Admin")
        };
    }
}