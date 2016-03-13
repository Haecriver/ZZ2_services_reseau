using SiteWebJediTournament.Models;
using SiteWebJediTournament.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SiteWebJediTournament.Controllers
{
    public class CaracteristiqueController : Controller
    {
        // GET: Caracteristique
        public ActionResult Index()
        {
            ServiceJediClient service = new ServiceJediClient();
            List<CaracteristiqueModels> list = new List<CaracteristiqueModels>();

            foreach (CaracteristiqueWCF cara in service.getAllCaracteristique())
            {
                list.Add(new CaracteristiqueModels(cara));
            }

            return View(list);
        }

        // GET: Caracteristique/Details/5
        public ActionResult Details(int id)
        {
            ServiceJediClient service = new ServiceJediClient();
            CaracteristiqueWCF cara = service.getAllCaracteristique().ToList().Find(x => x.Id == id);
            if (cara == null)
            {
                return HttpNotFound();
            }
            return View(new CaracteristiqueModels(cara));
        }

        // GET: Caracteristique/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Caracteristique/Create
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

        // GET: Caracteristique/Edit/5
        public ActionResult Edit(int id)
        {
            ServiceJediClient service = new ServiceJediClient();
            CaracteristiqueWCF cara = service.getAllCaracteristique().ToList().Find(x => x.Id == id);
            if (cara == null)
            {
                return HttpNotFound();
            }
            return View(new CaracteristiqueModels(cara));
        }

        // POST: Caracteristique/Edit/5
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

        // GET: Caracteristique/Delete/5
        public ActionResult Delete(int id)
        {
            ServiceJediClient service = new ServiceJediClient();
            CaracteristiqueWCF cara = service.getAllCaracteristique().ToList().Find(x => x.Id == id);
            if (cara == null)
            {
                return HttpNotFound();
            }
            return View(new CaracteristiqueModels(cara));
        }

        // POST: Caracteristique/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                ServiceJediClient service = new ServiceJediClient();
                CaracteristiqueWCF cara = service.getAllCaracteristique().ToList().Find(x => x.Id == id);
                if (cara == null)
                {
                    return HttpNotFound();
                }
                service.deleteCaracteristique(cara);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult ListCaracteristiqueJedi()
        {
            ServiceJediClient service = new ServiceJediClient();
            List<CaracteristiqueModels> list = new List<CaracteristiqueModels>();
            foreach(CaracteristiqueWCF c in service.getAllCaracteristique())
            {
                if (c.Type == ETypeCaracteristique.Jedi)
                {
                    list.Add(new CaracteristiqueModels(c));
                }
            }
            return PartialView(list);
        }

        public ActionResult ListCaracteristiqueStade()
        {
            ServiceJediClient service = new ServiceJediClient();
            List<CaracteristiqueModels> list = new List<CaracteristiqueModels>();
            foreach (CaracteristiqueWCF c in service.getAllCaracteristique())
            {
                if (c.Type == ETypeCaracteristique.Stade)
                {
                    list.Add(new CaracteristiqueModels(c));
                }
            }
            return PartialView(list);
        }
    }
}
