using SiteWebJediTournament.Models;
using SiteWebJediTournament.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SiteWebJediTournament.Controllers
{
    public class MatchController : Controller
    {
        // GET: Match
        public ActionResult Index()
        {
            ServiceJediClient service = new ServiceJediClient();
            List<MatchModels> list = new List<MatchModels>();

            foreach (MatchWCF match in service.getAllMatch())
            {
                list.Add(new MatchModels(match));
            }

            return View(list);
        }

        // GET: Match/Details/5
        public ActionResult Details(int id)
        {
            ServiceJediClient service = new ServiceJediClient();
            MatchWCF match = service.getAllMatch().ToList().Find(x => x.Id == id);
            if (match == null)
            {
                return HttpNotFound();
            }
            return View(new MatchModels(match));
        }

        // GET: Match/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Match/Create
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

        // GET: Match/Edit/5
        public ActionResult Edit(int id)
        {
            ServiceJediClient service = new ServiceJediClient();
            MatchWCF match = service.getAllMatch().ToList().Find(x => x.Id == id);
            if (match == null)
            {
                return HttpNotFound();
            }
            return View(new MatchModels(match));
        }

        // POST: Match/Edit/5
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

        // GET: Match/Delete/5
        public ActionResult Delete(int id)
        {
            ServiceJediClient service = new ServiceJediClient();
            MatchWCF match = service.getAllMatch().ToList().Find(x => x.Id == id);
            if (match == null)
            {
                return HttpNotFound();
            }
            return View(new MatchModels(match));
        }

        // POST: Match/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                ServiceJediClient service = new ServiceJediClient();
                MatchWCF match = service.getAllMatch().ToList().Find(x => x.Id == id);
                if (match == null)
                {
                    return HttpNotFound();
                }
                service.deleteMatch(match);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
