using RAP.Domain.Interfaces;
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
using System.Web.Configuration;
using System.IO;
using RAP.Domain.Util;
using RAP.Domain.Services;
using System.Net;

namespace RAP.UI.Controllers
{
    [Authorize(Roles = "admin")]
    public class ServicesController : Controller
    {
        private const string keyAppSettings = "PathToServiceLogos";

        private IUnitOfWork unitOfWork;
        private IGridsImagesService gridsImagesService;

        public ServicesController()
        {
            unitOfWork = new EFUnitOfWork();
            gridsImagesService = new GridsImagesService();
        }

        // GET: Services
        [OverrideAuthorization]
        [Authorize]
        public async Task<ActionResult> Index()
        {
            ViewBag.PathToDirectory = gridsImagesService.GetPathToDirectory(keyAppSettings);

            IEnumerable<ServiceViewModel> serviceViewModels = Mapper.Map<IEnumerable<ServiceViewModel>>(await unitOfWork.Services.GetAllAsync());

            if (HttpContext.User.IsInRole("admin"))
                return View(serviceViewModels);

            return View("IndexClient", serviceViewModels);
        }

        // GET: Services/Details/5
        public async Task<ActionResult> Details(int id)
        {
            Service service = await unitOfWork.Services.GetById(id);

            return View(Mapper.Map<ServiceViewModel>(service));
        }

        // GET: Services/Create
        public async Task<ActionResult> Create()
        {
            ViewBag.ServiceTypeId = new SelectList(await unitOfWork.ServiceTypes.GetAllAsync(), "Id", "Name");

            return View();
        }

        // POST: Services/Create
        [HttpPost]
        public async Task<ActionResult> Create(ServiceViewModel serviceViewModel, HttpPostedFileBase logo)
        {
            string nameLogo = null;

            if (logo != null)
            {
                if (!gridsImagesService.IsGetAndValidExtencion(ref nameLogo, logo.FileName))
                {
                    ModelState.AddModelError("Logo", "Logo must have an extension - .jpg, .png.");
                }

                nameLogo = serviceViewModel.Name + "_" + DateTime.Now.ToShortDateString() + nameLogo;             
            }

            serviceViewModel.Logo = nameLogo;
            
            if (ModelState.IsValid)
            {
                //TODO: Transaction???
                if (logo != null)
                {
                    string pathToServiceLogos = gridsImagesService.GetPathToDirectory(keyAppSettings);
                    logo.SaveAs(Server.MapPath("~\\" + pathToServiceLogos + nameLogo));
                }
                    
                Service service = Mapper.Map<Service>(serviceViewModel);
                unitOfWork.Services.Create(service);
                await unitOfWork.SaveAsync();

                LoggerManager.Log.Info($"Created new Service: {serviceViewModel.Name}.");

                return RedirectToAction("Index");
            }

            ViewBag.ServiceTypeId = new SelectList(await unitOfWork.ServiceTypes.GetAllAsync(), "Id", "Name", 
                                                        serviceViewModel.ServiceTypeId);
            return View();
        }

        // GET: Services/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Service service = await unitOfWork.Services.GetById(id.Value);
            if (service == null)
            {
                return HttpNotFound();
            }

            ViewBag.ServiceTypeId = new SelectList(await unitOfWork.ServiceTypes.GetAllAsync(), "Id", "Name");
            ViewBag.PathToDirectory = gridsImagesService.GetPathToDirectory(keyAppSettings);

            return View(Mapper.Map<ServiceViewModel>(service));
        }

        // POST: Services/Edit/5
        [HttpPost]
        public async Task<ActionResult> Edit(ServiceViewModel serviceViewModel, HttpPostedFileBase logo)
        {
            Service serviceFromForm = Mapper.Map<Service>(serviceViewModel);

            if (ModelState.IsValid)
            {
                if (logo == null)
                {
                    Service serviceFromDb = await unitOfWork.Services.GetById(serviceViewModel.Id);
                    serviceFromDb.Name = serviceFromForm.Name;
                    serviceFromDb.Description = serviceFromForm.Description;
                    serviceFromDb.ServiceTypeId = serviceFromForm.ServiceTypeId;

                    unitOfWork.Services.Update(serviceFromDb);
                    await unitOfWork.SaveAsync();
                }
                else
                {
                    string nameLogo = null;

                    if (!gridsImagesService.IsGetAndValidExtencion(ref nameLogo, logo.FileName))
                    {
                        ModelState.AddModelError("Logo", "Logo must have an extension - .jpg, .png.");
                    }

                    nameLogo = serviceViewModel.Name + "_" + DateTime.Now.ToShortDateString() + nameLogo;

                    serviceFromForm.Logo = nameLogo;

                    string pathToServiceLogos = gridsImagesService.GetPathToDirectory(keyAppSettings);
                    logo.SaveAs(Server.MapPath("~\\" + pathToServiceLogos + nameLogo));

                    unitOfWork.Services.Update(serviceFromForm);
                    await unitOfWork.SaveAsync();
                }
                LoggerManager.Log.Info($"Updated Service: {serviceViewModel.Name}.");

                return RedirectToAction("Index");
            }
            ViewBag.ServiceTypeId = new SelectList(await unitOfWork.ServiceTypes.GetAllAsync(), "Id", "Name",
                                                        serviceViewModel.ServiceTypeId);
            return View(serviceViewModel);
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
