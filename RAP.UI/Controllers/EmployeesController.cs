﻿using AutoMapper;
using RAP.Domain.Entities;
using RAP.Domain.Interfaces;
using RAP.Domain.Repositories;
using RAP.Domain.Services;
using RAP.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace RAP.UI.Controllers
{
    [Authorize(Roles = "admin")]
    public class EmployeesController : Controller
    {
        private const string keyAppSettings = "PathToEmployeePhotos";

        private IUnitOfWork unitOfWork;
        private IGridsImagesService gridsImagesService;

        public EmployeesController()
        {
            unitOfWork = new EFUnitOfWork();
            gridsImagesService = new GridsImagesService();
        }

        // GET: Employees
        [OverrideAuthorization]
        [Authorize]
        public async Task<ActionResult> Index()
        {
            ViewBag.PathToDirectory = gridsImagesService.GetPathToDirectory(keyAppSettings); ;

            IEnumerable<EmployeeViewModel> employeeViewModels = Mapper.Map<IEnumerable<EmployeeViewModel>>(await unitOfWork.Employees.GetAllAsync());

            if (HttpContext.User.IsInRole("admin"))
                return View(employeeViewModels);

            return View("IndexClient", employeeViewModels);
        }

        //// GET: Employees/Details/5
        public async Task<ActionResult> Details(int id)
        {
            Employee employee = await unitOfWork.Employees.GetById(id);

            ViewBag.PathToDirectory = gridsImagesService.GetPathToDirectory(keyAppSettings);

            return View(Mapper.Map<EmployeeViewModel>(employee));
        }

        //// GET: Employees/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        //// POST: Employees/Create
        //[HttpPost]
        //public ActionResult Create(FormCollection collection)
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

        //// GET: Employees/Edit/5
        //public ActionResult Edit(int id)
        //{
        //    return View();
        //}

        //// POST: Employees/Edit/5
        //[HttpPost]
        //public ActionResult Edit(int id, FormCollection collection)
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

        //// GET: Employees/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        //// POST: Employees/Delete/5
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
