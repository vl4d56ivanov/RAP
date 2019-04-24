using AutoMapper;
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
            Mapper.Initialize(cfg => { });
        }
    }
}