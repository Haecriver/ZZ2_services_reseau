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
            tModels.bank = bank;
            return View(tModels);
        }

        [HttpPost]
        public ActionResult Details(int id, int bank, int bet, int jediBet)
        {
            ServiceJediClient service = new ServiceJediClient();
            TournoiWCF t = service.getAllTournoi().ToList().Find(x => x.Id == id);
            if (t == null)
            {
                return HttpNotFound();
            }
            if (t.Matches.ToList().Count == 1)
            {
                return RedirectToAction("Index");
            }
            else
            {
                bank -= bet;

                // Jouer les matches et recuperer le nouveau tournois
                TournoiWCF tnew = service.playTournoi(t);
                string nom = t.Nom + " " + tnew.Matches[0].PhaseTournoi;
                tnew.Nom = nom;
                service.addTournoi(tnew);
                tnew = service.getAllTournoi().ToList().Find(x => x.Nom == nom);

                // Determine si le joueur a gagne
                bool win = false;
                for(int i=0; i<tnew.Matches.ToList().Count && !win; i++)
                {
                    if(tnew.Matches[i].Jedi1.Id == jediBet ||
                        tnew.Matches[i].Jedi2.Id == jediBet)
                    {
                        win = true;
                        bank += bet * 2;
                    }
                }

                return RedirectToAction("Details", new { Id = tnew.Id, bank = bank });
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

        public ActionResult ListJediConcourant(int id)
        {
            ServiceJediClient service = new ServiceJediClient();
            List<JediModels> list = new List<JediModels>();

            TournoiWCF t = service.getAllTournoi().ToList().Find(x => x.Id == id);

            foreach (MatchWCF m in t.Matches)
            {
                list.Add(new JediModels(m.Jedi1));
                list.Add(new JediModels(m.Jedi2));
            }
            list.Sort(delegate (JediModels x, JediModels y)
            {
                return x.Nom.CompareTo(y.Nom);
            });
            return PartialView(list);
        }
    }
}
