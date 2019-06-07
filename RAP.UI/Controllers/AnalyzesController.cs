using AutoMapper;
using RAP.Domain.Entities;
using RAP.Domain.Interfaces;
using RAP.Domain.Repositories;
using RAP.Domain.Util;
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
    public class AnalyzesController : Controller
    {
        IUnitOfWork unitOfWork;

        public AnalyzesController()
        {
            unitOfWork = new EFUnitOfWork();
        }

        // GET: Analyzes
        public async Task<ActionResult> Index()
        {
            try
            {
                IEnumerable<Analyze> analyzes = await unitOfWork.Analyzes.GetAllAsync();

                return View(Mapper.Map<IEnumerable<AnalyzeViewModel>>(analyzes));
            }
            catch (Exception ex)
            {
                LoggerManager.Log.Error("", ex);
                return View("~/Views/Shared/Error.cshtml", new HandleErrorInfo(ex, "Analyzes", "Index"));
            }
        }

        // GET: Analyzes/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Analyzes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Analyzes/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
              
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Analyzes/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Analyzes/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
               
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Analyzes/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Analyzes/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
               
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        protected override void Dispose(bool disposing)
        {
            unitOfWork.Dispose();
            base.Dispose(disposing);
        }
    }
}
