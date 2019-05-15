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
                string extension = Path.GetExtension(logo.FileName);

                List<string> validExtensions = new List<string>() { ".jpg", ".png" };
                if (!validExtensions.Contains(extension))
                {
                    ModelState.AddModelError("Logo", "Logo must have an extension - .jpg, .png.");
                }

                nameLogo = serviceViewModel.Name + "_" + DateTime.Now.ToShortDateString() + extension;             
            }

            serviceViewModel.Logo = nameLogo;

            if (ModelState.IsValid)
            {
                if (logo != null)
                {
                    string pathToServiceLogos = WebConfigurationManager.AppSettings.GetValues("PathToServiceLogos").First();
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

        protected override void Dispose(bool disposing)
        {
            unitOfWork.Dispose();
            base.Dispose(disposing);
        }
    }
}
