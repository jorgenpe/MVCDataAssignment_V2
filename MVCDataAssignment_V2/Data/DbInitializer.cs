using Microsoft.EntityFrameworkCore;
using MVCDataAssignment_V2.Models;
using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCDataAssignment_V2.Data
{
    internal class DbInitializer 
    {
        internal static async Task InitializeAsync(PeopleDbContext context, RoleManager<IdentityRole> roleManager, UserManager<AccountPerson> userManager)
        {

            context.Database.EnsureCreated();

            if (context.Roles.Any())//seed check
            {
                IdentityRole role = new IdentityRole("SuperAdmin");
                IdentityResult result = await roleManager.CreateAsync(role);
                if (!result.Succeeded)
                {
                    ErrorMessages(result);
                }
                AccountPerson accountPerson = new AccountPerson
                {
                    FirstName = "Super",
                    LastName = "SuperAdmin",
                    DateOfBirth = DateTime.Now,
                    UserName = "SuperAdmin",
                    Email = "superadmin@admin.se"
                };
                IdentityResult userResult = await userManager.CreateAsync(accountPerson, "!!aaAA11??");
                if (!userResult.Succeeded)
                {
                    ErrorMessages(userResult);
                }
                userManager.AddToRoleAsync(accountPerson, role.Name).Wait();
            }

            


        }
        
        private static void ErrorMessages(IdentityResult identityResult)
        {
            string errors = "";
            foreach (var error in identityResult.Errors)
            {
                errors += error.Code + ", " + error.Description;
            }
            throw new Exception(errors);

        }

    }
}
