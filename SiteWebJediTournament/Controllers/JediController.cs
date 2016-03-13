using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SiteWebJediTournament.ServiceReference1;
using SiteWebJediTournament.Models;

namespace SiteWebJediTournament.Controllers
{
    public class JediController : Controller
    {
        //
        // GET: /Jedi/
        public ActionResult Index()
        {
            ServiceJediClient service = new ServiceJediClient();
            List<JediModels> list = new List<JediModels>();

            foreach (JediWCF jedi in service.getAllJedi())
            {
                list.Add(new JediModels(jedi));
            }

            return View(list);
        }

        //
        // GET: /Jedi/Details/5
        public ActionResult Details(int id)
        {
            ServiceJediClient service = new ServiceJediClient();
            JediWCF jedi = service.getAllJedi().ToList().Find(x => x.Id == id);
            if (jedi == null)
            {
                return HttpNotFound();
            }
            return View(new JediModels(jedi));
        }

        //
        // GET: /Jedi/Create
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Jedi/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                ServiceJediClient service = new ServiceJediClient();
                List<CaracteristiqueWCF> listCar = service.getAllCaracteristique().ToList();
        
                JediWCF jediWCF = new JediWCF();
                jediWCF.Nom = collection[1];
                jediWCF.IsSith = collection[2].StartsWith("true");

                List<CaracteristiqueWCF> listCarRes = new List<CaracteristiqueWCF>();
                char[] delimiterChars = {','};
                string[] caractStr = collection[3].Split(delimiterChars);
                foreach (string str in caractStr)
                {
                    if (str != "false")
                    {
                        listCarRes.Add(listCar.Find(x => x.Id == Int32.Parse(str)));
                    }
                }

                jediWCF.Caracteristiques = listCarRes.ToArray();

                service.addJedi(jediWCF);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Jedi/Edit/5
        public ActionResult Edit(int id)
        {
            ServiceJediClient service = new ServiceJediClient();
            JediWCF jedi = service.getAllJedi().ToList().Find(x => x.Id == id);
            if (jedi == null)
            {
                return HttpNotFound();
            }
            return View(new JediModels(jedi));
        }

        //
        // POST: /Jedi/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                ServiceJediClient service = new ServiceJediClient();
                List<CaracteristiqueWCF> listCar = service.getAllCaracteristique().ToList();

                JediWCF jediWCF = service.getAllJedi().ToList().Find(x => x.Id == id);
                jediWCF.Nom = collection[2];
                jediWCF.IsSith = collection[3].StartsWith("true");

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

                jediWCF.Caracteristiques = listCarRes.ToArray();

                service.updateJedi(jediWCF);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Jedi/Delete/5
        public ActionResult Delete(int id)
        {
            ServiceJediClient service = new ServiceJediClient();
            JediWCF jedi = service.getAllJedi().ToList().Find(x => x.Id == id);
            if (jedi == null)
            {
                return HttpNotFound();
            }
            return View(new JediModels(jedi));
        }

        //
        // POST: /Jedi/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                ServiceJediClient service = new ServiceJediClient();
                JediWCF jedi = service.getAllJedi().ToList().Find(x => x.Id == id);
                if (jedi == null)
                {
                    return HttpNotFound();
                }
                service.deleteJedi(jedi);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult ListJedi()
        {
            ServiceJediClient service = new ServiceJediClient();
            List<JediModels> list = new List<JediModels>();
            foreach (JediWCF j in service.getAllJedi())
            {
                list.Add(new JediModels(j));
            }
            return PartialView(list);
        }
    }
}
