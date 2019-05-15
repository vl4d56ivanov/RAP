using RAP.Domain.Entities;
using RAP.Domain.Identity;
using RAP.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAP.Domain.Repositories
{
    public class ServicesRepository : IBaseRepository<Service>
    {
        ApplicationDbContext db;

        public ServicesRepository(ApplicationDbContext context)
        {
            db = context;
        }

        public async Task<IEnumerable<Service>> GetAllAsync()
        {
            return await db.Services.Include(s => s.ServiceType).ToListAsync();
        }

        public async Task<Service> GetById(int id)
        {
            return await db.Services.Include(s => s.ServiceType).FirstOrDefaultAsync(s => s.Id == id);
        }

        public void Create(Service item)
        {
            db.Services.Add(item);
        }

        public void Update(Service item)
        {
            db.Entry(item).State = EntityState.Modified;
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}