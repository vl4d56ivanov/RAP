using RAP.Domain.Interfaces;
using RAP.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Configuration;

namespace RAP.Domain.Services
{
    public class GridsImagesService : IGridsImagesService
    {
        IUnitOfWork unitOfWork;

        public GridsImagesService()
        {
            unitOfWork = new EFUnitOfWork();
        }

        public string GetPathToDirectory(string keyAppSettings)
        {
            return WebConfigurationManager.AppSettings.GetValues(keyAppSettings).First(); 
        }
    }
}
