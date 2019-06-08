using AutoMapper;
using RAP.Domain.Entities;
using RAP.Domain.Interfaces;
using RAP.Domain.Repositories;
using RAP.Domain.Util;
using RAP.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
        public async Task<ActionResult> Details(int? id)
        {
            Analyze analyze = null;

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            try
            {
                analyze = await unitOfWork.Analyzes.GetById(id.Value);
            }
            catch (Exception ex)
            {
                LoggerManager.Log.Error("", ex);
                return View("~/Views/Shared/Error.cshtml", new HandleErrorInfo(ex, "Analyzes", "Index"));
            }

            if (analyze == null)
            {
                return HttpNotFound();
            }
            
            return View(Mapper.Map<AnalyzeViewModel>(analyze));
        }

        // GET: Analyzes/Create
        public async Task<ActionResult> Create()
        {
            ViewBag.PatientId = new SelectList(await unitOfWork.Patients.GetAllAsync(), "Id", "LName");
            ViewBag.EmployeeId = new SelectList(await unitOfWork.Employees.GetAllAsync(), "Id", "LName");

            return View();
        }

        // POST: Analyzes/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(AnalyzeViewModel analyzeViewModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    unitOfWork.Analyzes.Create(Mapper.Map<Analyze>(analyzeViewModel));
                    await unitOfWork.SaveAsync();

                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    LoggerManager.Log.Error("", ex);
                    return View("~/Views/Shared/Error.cshtml", new HandleErrorInfo(ex, "Analyzes", "Create"));
                }
            }

            ViewBag.PatientId = new SelectList(await unitOfWork.Patients.GetAllAsync(), "Id", "LName", analyzeViewModel.PatientId);
            ViewBag.EmployeeId = new SelectList(await unitOfWork.Employees.GetAllAsync(), "Id", "LName", analyzeViewModel.EmployeeId);

            return View(analyzeViewModel);
        }

        // GET: Analyzes/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Analyze analyze = await unitOfWork.Analyzes.GetById(id.Value);

            if (analyze == null)
            {
                return HttpNotFound();
            }

            AnalyzeViewModel analyzeViewModel = Mapper.Map<AnalyzeViewModel>(analyze);

            ViewBag.PatientId = new SelectList(await unitOfWork.Patients.GetAllAsync(), "Id", "LName", analyzeViewModel.PatientId);
            ViewBag.EmployeeId = new SelectList(await unitOfWork.Employees.GetAllAsync(), "Id", "LName", analyzeViewModel.EmployeeId);

            return View(analyzeViewModel);
        }

        // POST: Analyzes/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(AnalyzeViewModel analyzeViewModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    unitOfWork.Analyzes.Update(Mapper.Map<Analyze>(analyzeViewModel));
                    await unitOfWork.SaveAsync();

                    return RedirectToAction("Index");
                }
                catch(Exception ex)
                {
                    LoggerManager.Log.Error("", ex);
                    return View("~/Views/Shared/Error.cshtml", new HandleErrorInfo(ex, "Analyzes", "Edit"));
                }
            }

            ViewBag.PatientId = new SelectList(await unitOfWork.Patients.GetAllAsync(), "Id", "LName", analyzeViewModel.PatientId);
            ViewBag.EmployeeId = new SelectList(await unitOfWork.Employees.GetAllAsync(), "Id", "LName", analyzeViewModel.EmployeeId);

            return View(analyzeViewModel);
        }

        // GET: Analyzes/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            Analyze analyze = null;

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            try
            {
                analyze = await unitOfWork.Analyzes.GetById(id.Value);
            }
            catch (Exception ex)
            {
                LoggerManager.Log.Error("", ex);
                return View("~/Views/Shared/Error.cshtml", new HandleErrorInfo(ex, "Analyzes", "Index"));
            }

            if (analyze == null)
            {
                return HttpNotFound();
            }

            return View(Mapper.Map<AnalyzeViewModel>(analyze));
        }

        // POST: Analyzes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            try
            {
                await unitOfWork.Analyzes.Delete(id);
                await unitOfWork.SaveAsync();

                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                LoggerManager.Log.Error("", ex);
                return View("~/Views/Shared/Error.cshtml", new HandleErrorInfo(ex, "Analyzes", "Index"));
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                unitOfWork.Dispose();
            }
          
            base.Dispose(disposing);
        }
    }
}
