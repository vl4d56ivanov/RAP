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

        public void Create(Patient item)
        {
            db.Patients.Add(item);
        }
    }
}