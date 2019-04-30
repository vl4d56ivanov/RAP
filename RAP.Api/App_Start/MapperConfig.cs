using AutoMapper;
using RAP.Api.Models;
using RAP.Domain.Entities;

namespace RAP.Api.App_Start
{
    public class MapperConfig
    {
        public static void RegisterMapper()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<AddressApiModel, Address>();
            });
        }
    }
}