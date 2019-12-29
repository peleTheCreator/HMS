using HotelManagementSystem.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelManagementSystem.Services
{
    public static class ApplicationDbInitializer
    {
        public async static Task SeedRoles(RoleManager<IdentityRole> roleManager)
        {
            if (!roleManager.RoleExistsAsync("Admin").Result)
            {
                var role = new IdentityRole();
                role.Name = "Admin";
                IdentityResult roleResult = await roleManager.CreateAsync(role);
            }
            if (!roleManager.RoleExistsAsync("Desk").Result)
            {
                var role = new IdentityRole();
                role.Name = "Desk";
                IdentityResult roleResult = await roleManager.CreateAsync(role);
            }
            if (!roleManager.RoleExistsAsync("StoreKeeper").Result)
            {
                var role = new IdentityRole();
                role.Name = "StoreKeeper";
                IdentityResult roleResult = await roleManager.CreateAsync(role);
            }
        }

        public async static Task SeedUsers(UserManager<ApplicationUser> userManager)
        {
            if (userManager.FindByEmailAsync("admin@admin.com").Result == null)
            {
                var user = new ApplicationUser();
                user.Email = "admin@admin.com";
                user.EmailConfirmed = true;
                user.LockoutEnabled = true;
                IdentityResult result = await userManager.CreateAsync(user, "Micr0s0ft_");

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, "Admin").Wait();
                }
            }
            if (userManager.FindByEmailAsync("desk@desk.com").Result == null)
            {
                var user = new ApplicationUser();
                user.Email = "desk@desk.com";
                user.EmailConfirmed = true;
                user.LockoutEnabled = true;
                IdentityResult result = await userManager.CreateAsync(user, "Micr0s0ft_");
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, "Desk");
                }
            }
            if (userManager.FindByEmailAsync("skeeper@skeeper.com").Result == null)
            {
                var user = new ApplicationUser();
                user.Email = "skeeper@skeeper.com";
                user.EmailConfirmed = true;
                user.LockoutEnabled = true;
                IdentityResult result = await userManager.CreateAsync(user, "Micr0s0ft_");
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, "StoreKeeper");
                }
            }
        }

        public async static Task SeedData(UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager, AppDbContext context)
        {
            context.Database.EnsureCreated();
            //   await SeedRoles(roleManager);
            await SeedUsers(userManager);
        }


        public static void SeedAppUser(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, IServiceProvider serviceProvider, IConfiguration configuration)
        {
            if (userManager.FindByEmailAsync("admin@gmail.com").Result == null)
            {
                var user = new ApplicationUser();
                user.Email = "admin@gmail.com";
                user.UserName= "admin@gmail.com"; 
                user.EmailConfirmed = true;
                user.LockoutEnabled = true;
                IdentityResult result =  userManager.CreateAsync(user, "Micr0s0ft_").Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, "Admin").Wait();
                }
            }
            if (userManager.FindByEmailAsync("desk@gmail.com").Result == null)
            {
                var user = new ApplicationUser();
                user.Email = "desk@gmail.com";
                user.UserName = "desk@gmail.com";
                user.EmailConfirmed = true;
                user.LockoutEnabled = true;
                IdentityResult result =  userManager.CreateAsync(user, "Micr0s0ft_").Result;
                if (result.Succeeded)
                {
                     userManager.AddToRoleAsync(user, "Desk").Wait();
                }
            }
            if (userManager.FindByEmailAsync("skeeper@gmail.com").Result == null)
            {
                var user = new ApplicationUser();
                user.Email = "skeeper@gmail.com";
                user.UserName = "skeeper@gmail.com";
                user.EmailConfirmed = true;
                user.LockoutEnabled = true;
                IdentityResult result =  userManager.CreateAsync(user, "Micr0s0ft_").Result;
                if (result.Succeeded)
                {
                     userManager.AddToRoleAsync(user, "StoreKeeper").Wait();
                }
            }
        }
    }
}
    
