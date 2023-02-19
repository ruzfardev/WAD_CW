using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.DependencyInjection;
using WAD_CW.Models;

namespace WAD_CW.DAL
{
    public class AppDbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using var serviceScope = applicationBuilder.ApplicationServices.CreateScope();
            var context = serviceScope.ServiceProvider.GetService<AppDbContext>();

            context.Database.EnsureCreated();

            if (!context.Users.Any())
            {
                new Users()
                {
                    Email = "jondoe@gmail.com",
                    FirstName = "John",
                    LastName = "Doe",
                    Password = "123456"
                };
            }

            if (!context.Categories.Any())
            {
                new Categories()
                {
                    CategoryName = "Pizza"
                };
            }

            if (!context.Recipes.Any())
            {
                new Recipes()
                {
                    RecipeName = "Italian Cheese Pizza",
                    Description =
                        "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat.",
                    CookingTime = 45,
                    // CategoryId = 1,
                    // UserId = 1,
                    Ingredients = "Tomato, Onion, Cheese, Oil, Mushroom",
                    ServingSize = 2
                };
            }
        }
    }
}
