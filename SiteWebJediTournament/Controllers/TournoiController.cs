using SiteWebJediTournament.Models;
using SiteWebJediTournament.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SiteWebJediTournament.Controllers
{
    public class TournoiController : Controller
    {
        // GET: Tournoi
        public ActionResult Index()
        {
            ServiceJediClient service = new ServiceJediClient();
            List<TournoiModels> list = new List<TournoiModels>();

            foreach (TournoiWCF t in service.getAllTournoi())
            {
                list.Add(new TournoiModels(t));
            }

            return View(list);
        }

        // GET: Tournoi/Details/5
        public ActionResult Details(int id, int bank)
        {
            ServiceJediClient service = new ServiceJediClient();
            TournoiWCF t = service.getAllTournoi().ToList().Find(x => x.Id == id);
            if (t == null)
            {
                return HttpNotFound();
            }
            TournoiModels tModels = new TournoiModels(t);
            tModels.Bank = bank;
            return View(tModels);
        }

        // GET: Tournoi/Create
        public ActionResult Play(int id, int bank, int bet, int jediBet)
        {
            ServiceJediClient service = new ServiceJediClient();
            TournoiWCF t = service.getAllTournoi().ToList().Find(x => x.Id == id);
            if (t == null)
            {
                return HttpNotFound();
            }
            if (t.Matches.ToList().Count != 1)
            {
                TournoiWCF tnew = service.playTournoi(t);
                string nom = t.Nom + " " + tnew.Matches[0].PhaseTournoi;
                tnew.Nom = nom;
                service.addTournoi(tnew);
                tnew = service.getAllTournoi().ToList().Find(x => x.Nom == nom);
                return RedirectToAction("Details", new { Id = tnew.Id, });
            }
            else
            {
                return RedirectToAction("Index");
            }

        }

        // GET: Tournoi/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Tournoi/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                /*ServiceJediClient service = new ServiceJediClient();
                List<MatchWCF> listJedis = service.getAllMatch().ToList();
                TournoiWCF tournoi = new TournoiWCF();
                tournoi.Nom = 
                tournoi.Matches = 

                service.addMatch(match);*/
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Tournoi/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Tournoi/Edit/5
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

        // GET: Tournoi/Delete/5
        public ActionResult Delete(int id)
        {
            ServiceJediClient service = new ServiceJediClient();
            TournoiWCF t = service.getAllTournoi().ToList().Find(x => x.Id == id);
            if (t == null)
            {
                return HttpNotFound();
            }
            return View(new TournoiModels(t));
        }

        // POST: Tournoi/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                ServiceJediClient service = new ServiceJediClient();
                TournoiWCF t = service.getAllTournoi().ToList().Find(x => x.Id == id);
                if (t == null)
                {
                    return HttpNotFound();
                }
                service.deleteTournois(t);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
