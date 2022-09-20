using Microsoft.AspNetCore.Identity;
using WEB_053501_Tatsiana_Shurko.Data;

namespace WEB_053501_Tatsiana_Shurko.Entities {
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
        public static void InitializeBooks(BookContext context) {
            var thrillers = new Category { Title = "Thrillers" };
            var detectives = new Category { Title = "Detectives" };
            var adventures = new Category { Title = "Adventures" };
            var fantasy = new Category { Title = "Fantasy" };

            if (!context.Categories.Any()) {
                context.Categories.AddRange( thrillers, detectives, adventures, fantasy           
                );
                context.SaveChanges();
            }
                if (!context.Books.Any()) {
                context.Books.AddRange(
                    new Book { Title = "Harry potter and the philosopher's stone", Discription = "J. K. Rowling, 1997", Price = 13.45f, ImagePath = "images/books/1.jpg", Category =fantasy },
                    new Book { Title = "Harry potter and the chamber of secrets", Discription = "J. K. Rowling, 1998", Price = 13.45f, ImagePath = "images/books/2.jpg", Category = fantasy },
                    new Book { Title = "Harry potter and the prisoner of azkaban", Discription = "J. K. Rowling, 1999", Price = 13.45f, ImagePath = "images/books/3.jpg", Category = fantasy },
                    new Book { Title = "Harry potter and the goblet of fire", Discription = "J. K. Rowling, 2000", Price = 13.45f, ImagePath = "images/books/4.jpg", Category = fantasy },
                    new Book { Title = "Harry potter and the order of the phoenix", Discription = "J. K. Rowling, 2003", Price = 13.45f, ImagePath = "images/books/5.jpg", Category = fantasy },
                    new Book { Title = "Harry potter and the half-blood prince", Discription = "J. K. Rowling, 2005", Price = 13.45f, ImagePath = "images/books/6.jpg", Category = fantasy },
                    new Book { Title = "Harry potter and the deathly hallows", Discription = "J. K. Rowling, 2007", Price = 13.45f, ImagePath = "images/books/7.jpg", Category = fantasy },
                    new Book { Title = "The Alchemist's Secret", Discription = "Scott Mariani, 2007", Price = 11.99f, ImagePath = "images/books/8.jpg", Category = thrillers },
                    new Book { Title = "The Mozart Conspiracy", Discription = "Scott Mariani, 2008", Price = 11.99f, ImagePath = "images/books/9.jpg", Category = thrillers }
                );
                context.SaveChanges();
            }
        }
    }
}
