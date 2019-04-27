using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using RAP.Domain.Entities;
using System.Collections.Generic;
using System.Data.Entity;

namespace RAP.Domain.Identity
{
    public class InitializationRapDb : DropCreateDatabaseAlways<ApplicationDbContext>
    {
        protected override void Seed(ApplicationDbContext db)
        {
            var userManager = new ApplicationUserManager(new UserStore<ApplicationUser>(db));

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(db));
            var role = new IdentityRole { Name = "admin" };
            roleManager.Create(role);

            //TODO: Added default user with Admin role.
            var admin = new ApplicationUser
            {
                Email = "admin@rap.com",
                UserName = "admin@rap.com",
            };
            admin.EmailConfirmed = true;
            string password = "Qwe_123";
            var result = userManager.Create(admin, password);

            if (result.Succeeded)
            {
                userManager.AddToRole(admin.Id, role.Name);
            }

            //TODO: Deleted after tests.
            Address a1 = new Address { Sity = "London" };
            Address a2 = new Address { Sity = "York" };
            Address a3 = new Address { Sity = "New York" };

            db.Address.AddRange(new List<Address> { a1, a2, a3 });
            db.Patients.Add(new Patient { FName = "John", LName = "Snow", Address = a1 });

            base.Seed(db);
        }
    }
}