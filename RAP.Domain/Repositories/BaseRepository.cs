using RAP.Domain.Identity;
using RAP.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAP.Domain.Repositories
{
    class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        ApplicationDbContext db;
        DbSet<T> dbSet;

        public BaseRepository(ApplicationDbContext db)
        {
            this.db = db;
            this.dbSet = db.Set<T>();
        }
        
        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await dbSet.AsNoTracking().ToListAsync();
        }

        public async Task<T> GetById(int id)
        {
            return await dbSet.FindAsync(id);
        }

        public void Create(T item)
        {
            dbSet.Add(item);
        }

        public void Update(T item)
        {
            db.Entry(item).State = EntityState.Modified;
        }

        public async Task Delete(int id)
        {
            T item = await dbSet.FindAsync(id);

            if (item != null)
                dbSet.Remove(item);
        }
    }
}
