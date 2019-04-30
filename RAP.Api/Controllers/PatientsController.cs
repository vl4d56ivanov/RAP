﻿using RAP.Domain.Entities;
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

        // GET: api/Patients/5
        public async Task<IHttpActionResult> Get(int id)
        {
            Patient patient = await unitOfWork.Patients.GetById(id);

            return Json(patient);
        }

        // POST: api/Patients
        public IHttpActionResult Post([FromBody]Patient patient)
        {
            unitOfWork.Patients.Create(patient);

            return Ok();
        }

        // PUT: api/Patients/5
        public IHttpActionResult Put(int id, [FromBody]Patient patient)
        {
            unitOfWork.Patients.Update(patient);

            return Ok();
        }

        // DELETE: api/Patients/5
        public async Task<IHttpActionResult> Delete(int id)
        {
            await unitOfWork.Patients.Delete(id);

            return Ok();
        }
    }
}
