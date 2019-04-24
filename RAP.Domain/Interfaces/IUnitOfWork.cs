using RAP.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAP.Domain.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IBaseRepository<Patient> Patients { get; }
        
        Task SaveAsync();
    }
}
