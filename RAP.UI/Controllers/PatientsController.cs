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

namespace RAP.UI.Controllers
{
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
            //TODO:For DropDownList Address
            //ViewBag.AddressList = new SelectList(await unitOfWork.Addresses.GetAllAsync(), "AddressId", "City");

            return View();
        }

        // POST: Patients/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(PatientViewModel patientViewModel)
        {
            Patient patient = Mapper.Map<Patient>(patientViewModel); 

            if (ModelState.IsValid)
            {
                unitOfWork.Patients.Create(patient);
                await unitOfWork.SaveAsync();

                return RedirectToAction("Index");
            }

            //ViewBag.AddressId = new SelectList(await unitOfWork.Addresses.GetAllAsync(), "AddressId", "City", patientViewModel.AddressId);
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
