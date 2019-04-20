using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
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

            base.Seed(db);
        }
    }
}