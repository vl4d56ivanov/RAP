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

        public async Task<Appointment> GetById(int id)
        {
            return await db.Appointments.Include(a => a.Patient)
                                        .Include(a => a.Service)
                                        .Include(a => a.Employee)
                                        .FirstOrDefaultAsync(a => a.Id == id);
        }

        public void Create(Appointment item)
        {
            db.Appointments.Add(item);
        }

        public void Update(Appointment item)
        {

            db.Entry(item).State = EntityState.Modified;
        }

        public async Task Delete(int id)
        {
            Appointment appointment = await db.Appointments.FindAsync(id);

            if(appointment != null)
            db.Appointments.Remove(appointment);
        }  
    }
}