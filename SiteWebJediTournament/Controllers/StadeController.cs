using SiteWebJediTournament.Models;
using SiteWebJediTournament.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SiteWebJediTournament.Controllers
{
    public class StadeController : Controller
    {
        // GET: Stade
        public ActionResult Index()
        {
            ServiceJediClient service = new ServiceJediClient();
            List<StadeModels> list = new List<StadeModels>();

            foreach (StadeWCF stade in service.getAllStade())
            {
                list.Add(new StadeModels(stade));
            }

            return View(list);
        }

        // GET: Stade/Details/5
        public ActionResult Details(int id)
        {
            ServiceJediClient service = new ServiceJediClient();
            StadeWCF stade = service.getAllStade().ToList().Find(x => x.Id == id);
            if (stade == null)
            {
                return HttpNotFound();
            }
            return View(new StadeModels(stade));
        }

        // GET: Stade/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Stade/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                ServiceJediClient service = new ServiceJediClient();
                List<CaracteristiqueWCF> listCar = service.getAllCaracteristique().ToList();

                StadeWCF stadeWCf = new StadeWCF();
                stadeWCf.Planete = collection[1];
                stadeWCf.NbPlaces = Int32.Parse(collection[2]);

                List<CaracteristiqueWCF> listCarRes = new List<CaracteristiqueWCF>();
                char[] delimiterChars = { ',' };
                string[] caractStr = collection[3].Split(delimiterChars);
                foreach (string str in caractStr)
                {
                    if (str != "false")
                    {
                        listCarRes.Add(listCar.Find(x => x.Id == Int32.Parse(str)));
                    }
                }

                stadeWCf.Caracteristiques = listCarRes.ToArray();

                service.addStade(stadeWCf);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Stade/Edit/5
        public ActionResult Edit(int id)
        {
            ServiceJediClient service = new ServiceJediClient();
            StadeWCF stade = service.getAllStade().ToList().Find(x => x.Id == id);
            if (stade == null)
            {
                return HttpNotFound();
            }
            return View(new StadeModels(stade));
        }

        // POST: Stade/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                ServiceJediClient service = new ServiceJediClient();
                List<CaracteristiqueWCF> listCar = service.getAllCaracteristique().ToList();

                StadeWCF stadeWCF = service.getAllStade().ToList().Find(x => x.Id == id);
                stadeWCF.Planete = collection[2];
                stadeWCF.NbPlaces = Int32.Parse(collection[3]);

                List<CaracteristiqueWCF> listCarRes = new List<CaracteristiqueWCF>();
                char[] delimiterChars = { ',' };
                string[] caractStr = collection[4].Split(delimiterChars);
                foreach (string str in caractStr)
                {
                    if (str != "false")
                    {
                        listCarRes.Add(listCar.Find(x => x.Id == Int32.Parse(str)));
                    }
                }

                stadeWCF.Caracteristiques = listCarRes.ToArray();

                service.updateStade(stadeWCF);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Stade/Delete/5
        public ActionResult Delete(int id)
        {
            ServiceJediClient service = new ServiceJediClient();
            StadeWCF stade = service.getAllStade().ToList().Find(x => x.Id == id);
            if (stade == null)
            {
                return HttpNotFound();
            }
            return View(new StadeModels(stade));
        }

        // POST: Stade/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                ServiceJediClient service = new ServiceJediClient();
                StadeWCF stade = service.getAllStade().ToList().Find(x => x.Id == id);
                if (stade == null)
                {
                    return HttpNotFound();
                }
                service.deleteStade(stade);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }


        public ActionResult ListStade()
        {
            ServiceJediClient service = new ServiceJediClient();
            List<StadeModels> list = new List<StadeModels>();
            foreach (StadeWCF s in service.getAllStade())
            {
                list.Add(new StadeModels(s));
            }
            return PartialView(list);
        }
    }
}
