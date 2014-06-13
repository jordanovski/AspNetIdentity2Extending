﻿using Identity.Model;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using System.Data.Entity;
using System.Web;

namespace Identity.DbInitializer
{
    // This is useful if you do not want to tear down the database each time you run the application.
    // public class ApplicationDbInitializer : DropCreateDatabaseAlways<ApplicationDbContext>
    // This example shows you how to create a new database if the Model changes
    public class ApplicationDbInitializer : DropCreateDatabaseIfModelChanges<ApplicationDbContext>
    {
        protected override void Seed(ApplicationDbContext context)
        {
            InitializeIdentityForEF(context);
            base.Seed(context);
        }

        //Create User=Admin@Admin.com with password=Admin@123456 in the Admin role        
        public static void InitializeIdentityForEF(ApplicationDbContext db)
        {
            var userManager = HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var roleManager = HttpContext.Current.GetOwinContext().Get<ApplicationRoleManager>();

            const string Email = "admin@admin.com";
            const string Username = "admin";
            const string Firstname = "admin";
            const string Lastname = "admin";
            const string Password = "Admin@123456";
            const string RoleName = "Admin";
            const string RoleDescription = "Administrator";

            //Create Role Admin if it does not exist
            var role = roleManager.FindByName(RoleName);
            if (role == null)
            {
                role = new ApplicationRole
                {
                    Name = RoleName,
                    Description = RoleDescription
                };
                var roleresult = roleManager.Create(role);
            }

            var user = userManager.FindByName(Username);
            if (user == null)
            {
                user = new ApplicationUser { 
                    UserName = Username, 
                    Email = Email, 
                    FirstName = Firstname, 
                    LastName = Lastname, 
                    CreatedDate = System.DateTime.Now };
                var result = userManager.Create(user, Password);
                result = userManager.SetLockoutEnabled(user.Id, false);
            }

            // Add user admin to Role Admin if not already added
            var rolesForUser = userManager.GetRoles(user.Id);
            if (!rolesForUser.Contains(role.Name))
            {
                var result = userManager.AddToRole(user.Id, role.Name);
            }
        }
    }
}
