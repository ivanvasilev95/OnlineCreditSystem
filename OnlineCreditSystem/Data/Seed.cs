using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace OnlineCreditSystem.Data
{
    public class Seed
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<Role> _roleManager;

        public Seed(UserManager<User> userManager, RoleManager<Role> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public void SeedUsers()
        {
            var roles = new List<Role>
            {
                new Role{Name = "Member"},
                new Role{Name = "Admin"}
            };

            foreach (var role in roles)
            {
                _roleManager.CreateAsync(role).Wait();
            }

            var adminUser = new User { UserName = "admin" };
            var result = _userManager.CreateAsync(adminUser, "admin1").Result;
            if (result.Succeeded)
            {
                var admin = _userManager.FindByNameAsync("admin").Result;
                _userManager.AddToRoleAsync(admin, "Admin").Wait();
            }
        }
    }
}
