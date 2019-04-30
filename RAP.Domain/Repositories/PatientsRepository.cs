using RAP.Domain.Entities;
using RAP.Domain.Identity;
using RAP.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;

namespace RAP.Domain.Repositories
{
    public class PatientsRepository : IBaseRepository<Patient>
    {
        ApplicationDbContext db;


        public PatientsRepository(ApplicationDbContext context)
        {
            db = context;
        }

        public async Task<IEnumerable<Patient>> GetAllAsync()
        {
            IEnumerable<Patient> patients = await db.Patients.Include(p => p.Address).Include(p => p.Address2).ToListAsync();
            return patients;
        }

        public async Task<Patient> GetById(int id)
        {
            return await db.Patients.Include(p => p.Address).Include(p => p.Address2).FirstOrDefaultAsync(p => p.Id == id);
        }

        public void Create(Patient item)
        {
            db.Patients.Add(item);
        }

        public void Update(Patient item)
        {
            db.Entry(item).State = EntityState.Modified;
        }

        public async Task Delete(int id)
        {
            Patient item = await db.Patients.FindAsync(id);

            if (item != null)
                db.Patients.Remove(item);
        }
    }
}