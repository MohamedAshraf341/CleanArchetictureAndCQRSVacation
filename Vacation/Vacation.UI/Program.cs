using Microsoft.AspNetCore.Identity;
using Serilog;
using Vacation.Domain.Entities.Identity;
using Vacation.Persistence.Data.Seeds;

namespace Vacation.UI
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();

            Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(config)
                .CreateLogger();
            var host = CreateHostBuilder(args).Build();
            using var scope = host.Services.CreateScope();
            var services = scope.ServiceProvider;
            try
            {
                var userManager = services.GetRequiredService<UserManager<ApplicationUser>>();
                var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();
                await DefaultRoles.SeedAsync(roleManager);
                await DefaultUsers.SeedNormalUserAsync(userManager);
                await DefaultUsers.SeedAdminUserAsync(userManager,roleManager);
                await host.RunAsync();
            }
            catch (Exception ex)
            {

                Log.Fatal(ex, "The application failed to start!");
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }

}