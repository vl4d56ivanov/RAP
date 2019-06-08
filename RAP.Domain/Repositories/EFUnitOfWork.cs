﻿using RAP.Domain.Entities;
using RAP.Domain.Identity;
using RAP.Domain.Interfaces;
using System;
using System.Threading.Tasks;

namespace RAP.Domain.Repositories
{
    public class EFUnitOfWork : IUnitOfWork
    {
        ApplicationDbContext db;

        BaseRepository<Address>     addressRepository;            
        BaseRepository<Employee>    employeeRepository;            //EmployeesRepository
        BaseRepository<ServiceType> serviceTypeRepository;

        AnalyzesRepository     analizesRepository;
        AppointmentsRepository appointmentRepository;
        PatientsRepository     patientRepository;
        ServicesRepository     serviceRepository;

        public EFUnitOfWork()
        {
            db = new ApplicationDbContext();
        }

        public IBaseRepository<Patient> Patients
        { 
            get
            {
                if (patientRepository == null)
                    patientRepository = new PatientsRepository(db);

                return patientRepository;
            }
        }

        public IBaseRepository<Address> Addresses
        {
            get
            {
                if (addressRepository == null)
                    addressRepository = new BaseRepository<Address>(db);

                return addressRepository;
            }
        }

        public IBaseRepository<Appointment> Appointments
        {
            get
            {
                if (appointmentRepository == null)
                    appointmentRepository = new AppointmentsRepository(db);

                return appointmentRepository;
            }
        }

        public IBaseRepository<Employee> Employees
        {
            get
            {
                if (employeeRepository == null)
                    employeeRepository = new BaseRepository<Employee>(db);

                return employeeRepository;
            }
        }

        public IBaseRepository<ServiceType> ServiceTypes
        {
            get
            {
                if (serviceTypeRepository == null)
                    serviceTypeRepository = new BaseRepository<ServiceType>(db);

                return serviceTypeRepository;
            }
        }

        public IBaseRepository<Service> Services
        {
            get
            {
                if (serviceRepository == null)
                    serviceRepository = new ServicesRepository(db);

                return serviceRepository;
            }
        }

        public IBaseRepository<Analyze> Analyzes
        {
            get
            {
                if (analizesRepository == null)
                    analizesRepository = new AnalyzesRepository(db);

                return analizesRepository;
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
