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
            IEnumerable<PatientViewModel> patients = Mapper.Map<IEnumerable<PatientViewModel>>(await unitOfWork.Patients.GetAllAsync());
            return View(patients);
        }

        // GET: Patients/Create
        public async Task<ActionResult> Create()
        {
            return View();
        }

        // POST: Patients/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(PatientViewModel patientViewModel)
        {
            Patient patient = Mapper.Map<Patient>(patientViewModel);

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

            if (ModelState.IsValid)
            {
                unitOfWork.Patients.Create(patient);
                await unitOfWork.SaveAsync();

                LoggerManager.Log.Info($"Created new Patient: {patientViewModel.FName} {patientViewModel.LName}");

                return RedirectToAction("Index");
            }

            return View(patientViewModel);
        }

        // GET: Patients/Details/5
        //public ActionResult Details(int id)
        //{
        //    return View();
        //}



        //// GET: Patients/Edit/5
        //public ActionResult Edit(int id)
        //{
        //    return View();
        //}

        //// POST: Patients/Edit/5
        //[HttpPost]
        //public ActionResult Edit(int id, FormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add update logic here

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

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
        //        // TODO: Add delete logic here

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
