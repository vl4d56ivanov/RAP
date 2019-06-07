using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using RAP.Domain.Entities;
using System;
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
                Email = "Rapdevelop@gmail.com",
                UserName = "Rapdevelop@gmail.com",
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

            Patient patient1 = new Patient { FName = "John", LName = "Snow", Phone = "+7 121 345 6776", Email = "mail@mail.net",  Address = a1, Address2 = a2 };
            db.Patients.Add(patient1);

            ServiceType sT1 = new ServiceType { Name = "TypeOne" };
            ServiceType sT2 = new ServiceType { Name = "TypeTwo" };
            db.ServiceTypes.AddRange(new List<ServiceType> { sT1, sT2 });

            Service service1 = new Service { Name = "ServiceOne", ServiceType = sT1, Logo = "ServiceOne_08.05.19.jpg" };
            Service service2 = new Service { Name = "ServiceTwo", ServiceType = sT2, Logo = "ServiceTwo_08.05.19.jpg" };
            Service service3 = new Service { Name = "ServiceThree", ServiceType = sT1, Logo = "ServiceThree_08.05.19.jpg" };
            db.Services.AddRange(new List<Service> { service1, service2, service3 });

            Employee employee1 = new Employee { Photo = "EmployeeBob_14.05.2019.jpg", FName = "Bob", LName = "Lee", Phone = "+001 123 456 7890", AccessLevel = Util.AccessLevel.One };
            Employee employee2 = new Employee { FName = "Greg", LName = "White", Phone = "+007 987 456 7890", AccessLevel = Util.AccessLevel.Two };
            db.Employees.AddRange(new List<Employee> { employee1, employee2 });

            db.Appointments.AddRange(new List<Appointment>
            {
                new Appointment{Title = "TitleOne", Patient = patient1, Service = service1, Employee = employee1, Description = "Text text text..."}
            });

            db.Analyzes.AddRange(new List<Analyze>
            {
                new Analyze{Title = "TitleOne", Patient = patient1, Description = "Text text text...", DateCreated = DateTime.Now }
            });

            base.Seed(db);
        }
    }
}