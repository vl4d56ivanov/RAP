using RAP.Domain.Entities;
using RAP.Domain.Identity;
using RAP.Domain.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Data.Entity;

namespace RAP.Domain.Repositories
{
    class AnalyzesRepository : IBaseRepository<Analyze>
    {
        ApplicationDbContext db;

        public AnalyzesRepository(ApplicationDbContext context)
        {
            db = context;
        }

        public async Task<IEnumerable<Analyze>> GetAllAsync()
        {
            return await db.Analyzes.Include(a => a.Patient)
                                    .Include(a => a.Employee)
                                    .ToListAsync();
        }

        public async Task<Analyze> GetById(int id)
        {
            return await db.Analyzes.Include(a => a.Patient)
                                    .Include(a => a.Employee)
                                    .FirstOrDefaultAsync(a => a.Id == id);
        }

        public void Create(Analyze item)
        {
            db.Analyzes.Add(item);
        }

        public void Update(Analyze item)
        {
            db.Entry(item).State = EntityState.Modified;
        }

        public async Task Delete(int id)
        {
            Analyze analyze = await db.Analyzes.FindAsync(id);

            if (analyze != null)
                db.Analyzes.Remove(analyze);
        }       
    }
}
