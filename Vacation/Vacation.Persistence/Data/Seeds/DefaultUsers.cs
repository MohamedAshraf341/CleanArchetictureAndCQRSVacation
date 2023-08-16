using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using Vacation.Application.Helper;
using Vacation.Domain.Entities.Identity;

namespace Vacation.Persistence.Data.Seeds
{
    public static class DefaultUsers
    {
        public static async Task SeedNormalUserAsync(UserManager<ApplicationUser> userManager)
        {
            var defaultUser = new ApplicationUser
            {
                Name= "normalser",
                UserName = "normalser@domain.com",
                Email = "normalser@domain.com",
                EmailConfirmed = true
            };

            var user = await userManager.FindByEmailAsync(defaultUser.Email);

            if (user == null)
            {
                await userManager.CreateAsync(defaultUser, "P@ssword123");
                await userManager.AddToRoleAsync(defaultUser, Roles.NormalUser.ToString());
            }
        }

        public static async Task SeedAdminUserAsync(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManger)
        {
            var defaultUser = new ApplicationUser
            {
                Name= "admin",
                UserName = "admin@domain.com",
                Email = "admin@domain.com",
                EmailConfirmed = true
            };

            var user = await userManager.FindByEmailAsync(defaultUser.Email);

            if (user == null)
            {
                await userManager.CreateAsync(defaultUser, "P@ssword123");
                await userManager.AddToRolesAsync(defaultUser, new List<string> { Roles.NormalUser.ToString(), Roles.Admin.ToString() });
            }

            await roleManger.SeedClaimsForSuperUser();
        }

        private static async Task SeedClaimsForSuperUser(this RoleManager<IdentityRole> roleManager)
        {
            var adminRole = await roleManager.FindByNameAsync(Roles.Admin.ToString());
            await roleManager.AddPermissionClaims(adminRole, Modules.Vacation.ToString());
        }

        public static async Task AddPermissionClaims(this RoleManager<IdentityRole> roleManager, IdentityRole role, string module)
        {
            var allClaims = await roleManager.GetClaimsAsync(role);
            var allPermissions = Permissions.GeneratePermissionsList(module);

            foreach (var permission in allPermissions)
            {
                if (!allClaims.Any(c => c.Type == "Permission" && c.Value == permission))
                    await roleManager.AddClaimAsync(role, new Claim("Permission", permission));
            }
        }
    }
}
