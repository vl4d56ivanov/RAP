using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RAP.UI.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            if (HttpContext.User.IsInRole("admin"))
                return RedirectToAction("Index", "Admin");

            if (HttpContext.User.Identity.IsAuthenticated)
                return RedirectToAction("Client");

            return View();
        }

        public ActionResult Client()
        {
            return View();
        }
    }
}