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

        public void Create(T item)
        {
            dbSet.Add(item);
        }
    }
}
