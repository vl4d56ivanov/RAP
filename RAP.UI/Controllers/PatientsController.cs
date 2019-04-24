using RAP.Domain.Interfaces;
using RAP.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using AutoMapper;

namespace RAP.UI.Controllers
{
    public class PatientsController : Controller
    {
        IUnitOfWork unitOfWork;

        public PatientsController(IUnitOfWork uow)
        {
            unitOfWork = uow;
        }

        // GET: Patients
        public async Task<ActionResult> Index()
        {
            IEnumerable<PatientViewModel> patients = Mapper.Map<IEnumerable<PatientViewModel>>(await unitOfWork.Patients.GetAllAsync());
            return View(patients);
        }

        // GET: Patients/Details/5
        //public ActionResult Details(int id)
        //{
        //    return View();
        //}

        //// GET: Patients/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        //// POST: Patients/Create
        //[HttpPost]
        //public ActionResult Create(FormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add insert logic here

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
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
