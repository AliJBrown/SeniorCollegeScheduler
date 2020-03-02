using Microsoft.AspNetCore.Identity;
using SeniorCollegeScheduler.Models.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SeniorCollegeScheduler
{
    public static class MyIdentityDataInitializer
    {
        public static void SeedData
    (UserManager<MyIdentityUser> userManager,
    RoleManager<UserRole> roleManager)
        {
            SeedRoles(roleManager);
            SeedUsers(userManager);
        }

        public static void SeedUsers
    (UserManager<MyIdentityUser> userManager)
        {
            if (userManager.FindByNameAsync("admin@a.a").Result == null)
            {
                MyIdentityUser user = new MyIdentityUser();
                user.UserName = "admin@a.a";
                user.Email = "admin@a.a";

                IdentityResult result = userManager.CreateAsync
                (user, "Password1").Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user,
                                        "Admin").Wait();
                }
            }


            if (userManager.FindByNameAsync
        ("user@normal.test").Result == null)
            {
                MyIdentityUser user = new MyIdentityUser();
                user.UserName = "user@normal.test";
                user.Email = "user@normal.test";

                IdentityResult result = userManager.CreateAsync
                (user, "Password1").Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user,
                                        "NormalUser").Wait();
                }
            }
        }

        public static void SeedRoles
    (RoleManager<UserRole> roleManager)
        {
            if (!roleManager.RoleExistsAsync("NormalUser").Result)
            {
                UserRole role = new UserRole();
                role.Name = "NormalUser";
                role.Description = "Perform normal operations.";
                IdentityResult roleResult = roleManager.
                CreateAsync(role).Result;
            }


            if (!roleManager.RoleExistsAsync("Admin").Result)
            {
                UserRole role = new UserRole();
                role.Name = "Admin";
                role.Description = "Perform all the operations.";
                IdentityResult roleResult = roleManager.
                CreateAsync(role).Result;
            }
        }
    }
}
