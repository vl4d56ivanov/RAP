using RAP.Domain.Entities;
using RAP.Domain.Interfaces;
using RAP.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace RAP.Api.Controllers
{
    public class PatientsController : ApiController
    {
        IUnitOfWork unitOfWork;

        public PatientsController()
        {
            unitOfWork = new EFUnitOfWork();        
        }

        // GET: api/Patients
        public async Task<IHttpActionResult> GetAll()
        {
            // Add api model and Automapper? 
            IEnumerable<Patient> patients = await unitOfWork.Patients.GetAllAsync();
            return Json(patients);
        }

        //// GET: api/Patients/5
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST: api/Patients
        //public void Post([FromBody]string value)
        //{
        //}

        //// PUT: api/Patients/5
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE: api/Patients/5
        //public void Delete(int id)
        //{
        //}
    }
}
