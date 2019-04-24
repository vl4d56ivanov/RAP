using RAP.Domain.Entities;
using RAP.Domain.Identity;
using RAP.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAP.Domain.Repositories
{
    public class EFUnitOfWork : IUnitOfWork
    {
        ApplicationDbContext db;
        BaseRepository<Patient> patientRepository;

        public EFUnitOfWork()
        {
            db = new ApplicationDbContext();
        }

        public IBaseRepository<Patient> Patients
        { 
            get
            {
                if (patientRepository == null)
                    patientRepository = new BaseRepository<Patient>(db);

                return patientRepository;
            }
        }

        public async Task SaveAsync()
        {
            await db.SaveChangesAsync();
        }

        #region IDisposable Support
        private bool disposedValue = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                
                disposedValue = true;
            }
        }
        
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
