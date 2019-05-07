using AutoMapper;
using RAP.Domain.Entities;
using RAP.Domain.Interfaces;
using RAP.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using RAP.UI.Models;

namespace RAP.UI.Controllers
{
    [Authorize(Roles = "admin")]
    public class ServiceTypesController : Controller
    {
        IUnitOfWork unitOfWork;

        public ServiceTypesController()
        {
            unitOfWork = new EFUnitOfWork();
        }

        // GET: ServiceTypes
        public async Task<ActionResult> Index()
        {
            IEnumerable<ServiceType> serviceTypes = await unitOfWork.ServiceTypes.GetAllAsync();
            return View(Mapper.Map<IEnumerable<ServiceTypeViewModel>>(serviceTypes));
        }

        // GET: ServiceTypes/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ServiceTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ServiceTypes/Create
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

        // GET: ServiceTypes/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ServiceTypes/Edit/5
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

        // GET: ServiceTypes/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ServiceTypes/Delete/5
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
