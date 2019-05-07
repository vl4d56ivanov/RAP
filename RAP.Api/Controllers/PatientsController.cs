using AutoMapper;
using RAP.Api.Models;
using RAP.Domain.Entities;
using RAP.Domain.Interfaces;
using RAP.Domain.Repositories;
using RAP.Domain.Util;
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
            IEnumerable<PatientApiModel> patients = Mapper.Map<IEnumerable<PatientApiModel>>(await unitOfWork.Patients.GetAllAsync());
            return Json(patients);
        }

        // GET: api/Patients/5
        public async Task<IHttpActionResult> Get(int id)
        {
            PatientApiModel patient = Mapper.Map<PatientApiModel>(await unitOfWork.Patients.GetById(id));

            return Json(patient);
        }

        // POST: api/Patients
        public async Task<IHttpActionResult> Post([FromBody]PatientApiModel patient)
        {
            unitOfWork.Patients.Create(Mapper.Map<Patient>(patient));
            await unitOfWork.SaveAsync();

            LoggerManager.Log.Info($"Created new Patient: {patient.FName} {patient.LName}");

            return Ok();
        }

        // PUT: api/Patients/5
        public async Task<IHttpActionResult> Put([FromBody]PatientApiModel patient)
        {
            unitOfWork.Patients.Update(Mapper.Map<Patient>(patient));
            await unitOfWork.SaveAsync();

            LoggerManager.Log.Info($"Updated Patient: {patient.FName} {patient.LName}");

            return Ok();
        }

        // DELETE: api/Patients/5
        public async Task<IHttpActionResult> Delete(int id)
        {
            await unitOfWork.Patients.Delete(id);
            await unitOfWork.SaveAsync();

            LoggerManager.Log.Info($"Deleted Patient ID = {id}");

            return Ok();
        }
    }
}
