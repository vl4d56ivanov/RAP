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
            using(var transaction = db.Database.BeginTransaction())
            {
                try
                {
                    UpdateAddress(item.Address);

                    if (item.Address2 != null)
                        UpdateAddress(item.Address2);

                    db.Entry(item).State = EntityState.Modified;
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    throw;
                }
            }           
        }

        public async Task Delete(int id)
        {
            Patient item = await db.Patients.FindAsync(id);

            if (item != null)
            {
                using (var transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        await DeleteAddress(item.AddressId);

                        if (item.Address2Id != null)
                            await DeleteAddress(item.Address2Id.Value);

                        db.Patients.Remove(item);
                    }
                    catch (Exception)
                    {
                        transaction.Rollback();
                        throw;
                    }
                }                
            }           
        }

        private void UpdateAddress(Address address)
        {
            db.Entry(address).State = EntityState.Modified;
        }

        private async Task DeleteAddress(int addressId)
        {
            Address address = await db.Address.FindAsync(addressId);
            if (address != null)
                db.Address.Remove(address);
        }
    }
}