using RAP.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace RAP.Domain.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        
        IBaseRepository<Address>     Addresses { get; }
        IBaseRepository<Appointment> Appointments { get; }
        IBaseRepository<Employee>    Employees { get; }
        IBaseRepository<Patient>     Patients { get; }
        IBaseRepository<Service>     Services { get; }
        IBaseRepository<ServiceType> ServiceTypes { get; }
                 
        Task SaveAsync();
    }
}
