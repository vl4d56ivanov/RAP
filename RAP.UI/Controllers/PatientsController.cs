using RAP.Domain.Interfaces;
using RAP.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using RAP.Domain.Repositories;
using RAP.Domain.Entities;
using RAP.Domain.Util;
using System.Net;

namespace RAP.UI.Controllers
{
    [Authorize(Roles = "admin")]
    public class PatientsController : Controller
    {
        IUnitOfWork unitOfWork;

        //TODO: Add later DI
        public PatientsController()
        {
            unitOfWork = new EFUnitOfWork();
        }

        // GET: Patients
        public async Task<ActionResult> Index()
        {
            return View();
        }

        // GET: Patients/Create
        public async Task<ActionResult> Create()
        {
            return PartialView("Create");
        }

        public async Task<ActionResult> CreateModal(PatientViewModel patientViewModel)
        {
            Patient patient = Mapper.Map<Patient>(patientViewModel);
            unitOfWork.Patients.Create(patient);
            await unitOfWork.SaveAsync();

            IEnumerable<Patient> patients = await unitOfWork.Patients.GetAllAsync();
            IEnumerable<PatientViewModel> patientViewModels = Mapper.Map<IEnumerable<PatientViewModel>>(patients);

            return PartialView("_TableData", patientViewModels);
        }

        //// POST: Patients/Create
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> Create(PatientViewModel patientViewModel)
        //{
        //    Patient patient = Mapper.Map<Patient>(patientViewModel);

        //    if (
        //        String.IsNullOrEmpty(patientViewModel.Address.City) ||
        //        String.IsNullOrEmpty(patientViewModel.Address.Street) ||
        //        String.IsNullOrEmpty(patientViewModel.Address.Home) ||
        //        String.IsNullOrEmpty(patientViewModel.Address.Flat))
        //        ModelState.AddModelError("Address 1", "Address 1 must be filled out completely.");

            
        //    if ((patientViewModel.Address2.City == null ||
        //        patientViewModel.Address2.Street == null ||
        //        patientViewModel.Address2.Home == null ||
        //        patientViewModel.Address2.Flat == null))
        //    {
        //        if (!(patientViewModel.Address2.City == null &&
        //            patientViewModel.Address2.Street == null &&
        //            patientViewModel.Address2.Home == null &&
        //            patientViewModel.Address2.Flat == null))
        //        {
        //            ModelState.AddModelError("Address 2", "Address 2 must be filled out completely.");
        //        }
        //    }

        //    try
        //    {
        //        if (ModelState.IsValid)
        //        {
        //            unitOfWork.Patients.Create(patient);
        //            await unitOfWork.SaveAsync();

        //            LoggerManager.Log.Info($"Created new Patient: {patientViewModel.FName} {patientViewModel.LName}");

        //            return RedirectToAction("Index");
        //        }

        //        return View(patientViewModel);
        //    }
        //    catch (Exception ex)
        //    {
        //        LoggerManager.Log.Error("", ex);
        //        return View("~/Views/Shared/Error.cshtml", new HandleErrorInfo(ex, "Patients", "Create"));
        //    }           
        //}

        // GET: Patients/Details/5
        public async Task<ActionResult> Details(int id)
        {
            try
            {
                Patient patient = await unitOfWork.Patients.GetById(id);

                return View(Mapper.Map<PatientViewModel>(patient));
            }
            catch (Exception ex)
            {
                LoggerManager.Log.Error("", ex);
                return View("~/Views/Shared/Error.cshtml", new HandleErrorInfo(ex, "Patients", "Details"));
            }
        }



        // GET: Patients/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            Patient patient = await unitOfWork.Patients.GetById(id.Value);

            if (patient == null)
                return HttpNotFound();

            return View(Mapper.Map<PatientViewModel>(patient));
        }

        // POST: Patients/Edit/5
        [HttpPost]
        public async Task<ActionResult> Edit(PatientViewModel patientViewModel)
        {
            if (
                String.IsNullOrEmpty(patientViewModel.Address.City) ||
                String.IsNullOrEmpty(patientViewModel.Address.Street) ||
                String.IsNullOrEmpty(patientViewModel.Address.Home) ||
                String.IsNullOrEmpty(patientViewModel.Address.Flat))
                ModelState.AddModelError("Address 1", "Address 1 must be filled out completely.");


            if ((patientViewModel.Address2.City == null ||
                patientViewModel.Address2.Street == null ||
                patientViewModel.Address2.Home == null ||
                patientViewModel.Address2.Flat == null))
            {
                if (!(patientViewModel.Address2.City == null &&
                    patientViewModel.Address2.Street == null &&
                    patientViewModel.Address2.Home == null &&
                    patientViewModel.Address2.Flat == null))
                {
                    ModelState.AddModelError("Address 2", "Address 2 must be filled out completely.");
                }
            }
            Patient patient = Mapper.Map<Patient>(patientViewModel);

            try
            {
                if (ModelState.IsValid)
                {
                    unitOfWork.Patients.Update(patient);
                    await unitOfWork.SaveAsync();

                    LoggerManager.Log.Info($"Updated Patient: {patientViewModel.FName} {patientViewModel.LName}");

                    return RedirectToAction("Index");
                }

                return View(patientViewModel);
            }
            catch (Exception ex)
            {
                LoggerManager.Log.Error("", ex);
                return View("~/Views/Shared/Error.cshtml", new HandleErrorInfo(ex, "Patients", "Edit"));
            }
        }

        [ChildActionOnly]
        public ActionResult TableData()
        {
            try
            {
                IEnumerable<PatientViewModel> patients = Task.Run(GetPatientsForTableDataAsync).Result;    //GetPatientsForTableData().Result;
                return PartialView("_TableData", patients);
            }
            catch (Exception ex)
            {
                LoggerManager.Log.Error("", ex);
                return View("~/Views/Shared/Error.cshtml", new HandleErrorInfo(ex, "Patients", "Index"));
            }          
        }

        //TODO: How to add async/await?
        private async Task<IEnumerable<PatientViewModel>> GetPatientsForTableDataAsync()
        {
                IEnumerable<Patient> patients = await unitOfWork.Patients.GetAllAsync();
                 return  Mapper.Map<IEnumerable<PatientViewModel>>(patients);
        }

        //// GET: Patients/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        //// POST: Patients/Delete/5
        //[HttpPost]
        //public ActionResult Delete(int id, FormCollection collection)
        //{
        //    try
        //    {

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
        protected override void Dispose(bool disposing)
        {
            unitOfWork.Dispose();
            base.Dispose(disposing);
        }
    }
}
