using Microsoft.AspNetCore.Identity;
using Vacation.Application.Helper;

namespace Vacation.Persistence.Data.Seeds
{
    public static class DefaultRoles
    {
        public static async Task SeedAsync(RoleManager<IdentityRole> roleManger)
        {
            if (!roleManger.Roles.Any())
            {
                await roleManger.CreateAsync(new IdentityRole(Roles.Admin.ToString()));
                await roleManger.CreateAsync(new IdentityRole(Roles.NormalUser.ToString()));
            }
        }
    }
}
