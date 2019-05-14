using AutoMapper;
using RAP.Domain.Entities;
using RAP.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RAP.UI
{
    public class MapperConfig
    {
        public static void RegisterMapper()
        {
            Mapper.Initialize(cfg => 
            {
                //cfg.CreateMap<PatientViewModel, Patient>();
                cfg.CreateMap<AddressViewModel, Address>();
                //cfg.CreateMap<AppointmentViewModel, Appointment>();
                //cfg.CreateMap<PatientViewModel, Patient>();
                //cfg.CreateMap<ServiceViewModel, Service>();
                //cfg.CreateMap<EmployeeViewModel, Employee>();
            });
        }
    }
}