using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net.NetworkInformation;
using WEB_053501_Tatsiana_Shurko.Data;
using System.Threading.Tasks;

namespace WEB_053501_Tatsiana_Shurko.Entities {
    [NotMapped]
    public class ApplicationUser : IdentityUser {
        public byte[]? Image { get; set; }
        public string? ContentType { get; set; }
        public void InitializeArray(int length) { 
            Image = new byte[length];
        }
    }
    public class DbInitializer {
        public static async Task InitializeAsync(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager) {
            string adminEmail = "admin123@gmail.com";
            string adminPassword = "123_HelpMe";

            if (await roleManager.FindByIdAsync("user") == null) {
                await roleManager.CreateAsync(new IdentityRole("user"));
            }
            if (await roleManager.FindByIdAsync("admin") == null) {
                await roleManager.CreateAsync(new IdentityRole("admin"));
            }
            if (await userManager.FindByNameAsync(adminEmail) == null) {
                ApplicationUser admin = new ApplicationUser { Email = adminEmail, UserName = adminEmail, EmailConfirmed = true };
                IdentityResult result = await userManager.CreateAsync(admin, adminPassword);
                if (result.Succeeded) {
                    await userManager.AddToRoleAsync(admin, "admin");
                }
            }
        }
        public static async void Initialize(IApplicationBuilder app) {
            var serviceProvider = app.ApplicationServices.CreateScope().ServiceProvider;
            var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            await DbInitializer.InitializeAsync(userManager, roleManager);
        }

    }
}
