﻿using RAP.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RAP.Domain.Repositories;
using System.Threading.Tasks;
using RAP.Domain.Entities;
using AutoMapper;
using RAP.UI.Models;

namespace RAP.UI.Controllers
{
    [Authorize(Roles = "admin")]
    public class ServicesController : Controller
    {
        IUnitOfWork unitOfWork;

        public ServicesController()
        {
            unitOfWork = new EFUnitOfWork();
        }

        // GET: Services
        public async Task<ActionResult> Index()
        {
            IEnumerable <Service> services = await unitOfWork.Services.GetAllAsync();
            return View(Mapper.Map<IEnumerable<ServiceViewModel>>(services));
        }

        // GET: Services/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Services/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Services/Create
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

        // GET: Services/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Services/Edit/5
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

        // GET: Services/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Services/Delete/5
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
