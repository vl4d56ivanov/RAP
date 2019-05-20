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
    public class AppointmentsController : ApiController
    {
        IUnitOfWork unitOfWork;

        public AppointmentsController()
        {
            unitOfWork = new EFUnitOfWork();
        }

        // GET: api/Appointments
        public async Task<IHttpActionResult> GetAll()
        {
            IEnumerable<AppointmentApiModel> appointments = Mapper.Map<IEnumerable<AppointmentApiModel>>(await unitOfWork.Appointments.GetAllAsync());
            return Json(appointments);
        }

        // GET: api/Appointments/5
        public async Task<IHttpActionResult> GetById(int? id)
        {
            if (id == null)          
                return BadRequest();
            
            AppointmentApiModel appointment = Mapper.Map<AppointmentApiModel>(await unitOfWork.Appointments.GetById(id.Value));

            if (appointment == null)
                return NotFound();

            return Json(appointment);
        }

        // POST: api/Appointments
        public async Task<IHttpActionResult> Post([FromBody]AppointmentApiModel appointmentApi)
        {
            if (appointmentApi == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            unitOfWork.Appointments.Create(Mapper.Map<Appointment>(appointmentApi));
            await unitOfWork.SaveAsync();

            LoggerManager.Log.Info($"Created new Appointment: {appointmentApi.Title}.");

            return Ok();
        }

        // PUT: api/Appointments/5
        public async Task<IHttpActionResult> Put([FromBody]AppointmentApiModel appointmentApi)
        {
            if (appointmentApi == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            unitOfWork.Appointments.Update(Mapper.Map<Appointment>(appointmentApi));
            await unitOfWork.SaveAsync();

            LoggerManager.Log.Info($"Updated Patient: {appointmentApi.Title}.");

            return Ok();
        }

        // DELETE: api/Appointments/5
        public async Task<IHttpActionResult> Delete(int? id)
        {
            if (id == null)
                return BadRequest();

            await unitOfWork.Appointments.Delete(id.Value);
            await unitOfWork.SaveAsync();

            LoggerManager.Log.Info($"Deleted Appointment ID = {id}");

            return Ok();
        }

        protected override void Dispose(bool disposing)
        {
            unitOfWork.Dispose();
            base.Dispose(disposing);
        }
    }
}
