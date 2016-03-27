using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SiteWebJediTournament.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "A propos de ce projet.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Voici les informations pour nous contacter.";

            return View();
        }

        public ActionResult Test()
        {
            ViewBag.Message = "test.";
            return View();
        }
    }
}