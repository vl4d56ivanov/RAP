using RAP.Domain.Entities;
using RAP.Domain.Identity;
using RAP.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace RAP.Domain.Repositories
{
    public class AppointmentsRepository : IBaseRepository<Appointment>
    {
        ApplicationDbContext db;

        public AppointmentsRepository(ApplicationDbContext context)
        {
            db = context;
        }

        public async Task<IEnumerable<Appointment>> GetAllAsync()
        {
            return await db.Appointments.Include(a => a.Patient)
                                        .Include(a => a.Service)
                                        .Include(a => a.Employee)
                                        .ToListAsync();
        }

        public Task<Appointment> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Create(Appointment item)
        {
            throw new NotImplementedException();
        }

        public void Update(Appointment item)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }  
    }
}