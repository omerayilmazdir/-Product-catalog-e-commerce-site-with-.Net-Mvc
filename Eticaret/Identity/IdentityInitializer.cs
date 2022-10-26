using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Eticaret.Identity
{
    public class IdentityInitializer : CreateDatabaseIfNotExists<IdentityDataContext>
    {
        protected override void Seed(IdentityDataContext context)
        {
            // Roller 
            // eğer rol yoksa rol oluştur
            if (!context.Roles.Any(i => i.Name == "admin"))
            {
                var store = new RoleStore<ApplicationRole>(context);
                var manager = new RoleManager<ApplicationRole>(store);
                var role = new ApplicationRole() { Name = "admin", Description = "admin rolü"};
                manager.Create(role);

            }
            if (!context.Roles.Any(i => i.Name == "user"))
            {
                var store = new RoleStore<ApplicationRole>(context);
                var manager = new RoleManager<ApplicationRole>(store);
                var role = new ApplicationRole() { Name = "user", Description = "user rolü" };
                manager.Create(role);

            }
            if (!context.Roles.Any(i => i.Name == "omerayilmaz"))
            {
                var store = new UserStore<ApplicationUser>(context);
                var manager = new UserManager<ApplicationUser>(store);
                var user = new ApplicationUser() { Name = "omer", Surname = "ayılmazdır", UserName="omerayilmaz",Email="omerayilmaz10@gmail.com"};
                manager.Create(user,"1234567");
                manager.AddToRole(user.Id,"admin");


            }

            if (!context.Roles.Any(i => i.Name == "omeray"))
            {
                var store = new UserStore<ApplicationUser>(context);
                var manager = new UserManager<ApplicationUser>(store);
                var user = new ApplicationUser() { Name = "omer", Surname = "ay", UserName = "omeray", Email = "omeray@gmail.com" };
                manager.Create(user, "1234567");
                manager.AddToRole(user.Id, "user");

            }
            base.Seed(context);
        }

      
    }
}