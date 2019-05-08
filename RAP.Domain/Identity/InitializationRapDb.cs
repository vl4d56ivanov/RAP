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
            Address a1 = new Address { City = "London", Street = "Green str.", Home = "8a", Flat = "16" };
            Address a2 = new Address { City = "York", Street = "Ellow str.", Home = "88a", Flat = "16" };
            Address a3 = new Address { City = "New York" };

            db.Address.AddRange(new List<Address> { a1, a2, a3 });
            db.Patients.Add(new Patient { FName = "John", LName = "Snow", Address = a1, Address2 = a2 });

            ServiceType sT1 = new ServiceType { Name = "TypeOne" };
            ServiceType sT2 = new ServiceType { Name = "TypeTwo" };
            db.ServiceTypes.AddRange(new List<ServiceType> { sT1, sT2 });

            db.Services.Add(new Service { Name = "ServiceOne", ServiceType = sT1, Logo = "ServiceOne_08.05.19.jpg" });
            db.Services.Add(new Service { Name = "ServiceTwo", ServiceType = sT2, Logo = "ServiceTwo_08.05.19.jpg" });
            db.Services.Add(new Service { Name = "ServiceThree", ServiceType = sT1, Logo = "ServiceThree_08.05.19.jpg" });

            base.Seed(db);
        }
    }
}