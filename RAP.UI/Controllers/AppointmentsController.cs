﻿using AutoMapper;
using RAP.Domain.Entities;
using RAP.Domain.Interfaces;
using RAP.Domain.Repositories;
using RAP.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace RAP.UI.Controllers
{
    public class AppointmentsController : Controller
    {
        IUnitOfWork unitOfWork;

        public AppointmentsController()
        {
            unitOfWork = new EFUnitOfWork();
        }

        // GET: Appointments
        public async Task<ActionResult> Index()
        {
            IEnumerable<Appointment> appointments = await unitOfWork.Appointments.GetAllAsync();

            return View(Mapper.Map<IEnumerable<AppointmentViewModel>>(appointments));
        }

        // GET: Appointments/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Appointments/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Appointments/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Appointments/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Appointments/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Appointments/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Appointments/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
