using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using JediService.BusinessWCF;
using System.Collections.Generic;
using EntitiesLayer;

namespace TestJediService
{
    [TestClass]
    public class JediServiceTests
    {

        //Jedis
        [TestMethod]
        public void JediWCFTest()
        {
            //get
            ServiceJediReference.ServiceJediClient service = new ServiceJediReference.ServiceJediClient();
            BusinessLayer.BusinessManager bm = new BusinessLayer.BusinessManager();
            List<JediWCF> result = service.getAllJedi();
            List<Jedi> original = bm.getJedis(); //met a jour l'id
            List<JediWCF> expected = new List<JediWCF>();
            foreach (Jedi jedi in original)
            {
                expected.Add(new JediWCF(jedi));
            }
            foreach (JediWCF jedi in expected)
            {
                Assert.IsTrue(result.Exists(x=> x.Nom == jedi.Nom),"Le jedi " + jedi.Nom + " n'est pas present");
            }
            
            //add
            List<Caracteristique> list_carac = bm.getCaracteristique().FindAll(x => x.Id == 1);
            JediWCF j = new JediWCF(new Jedi("TestAjout", false, list_carac));
            service.addJedi(j);
            result = service.getAllJedi();
            Assert.IsTrue(result.Exists(x => x.Nom == j.Nom), "Le jedi " + j.Nom + " n'est pas present");

            //update
            j = result.Find(x => x.Nom == "TestAjout");
            j.IsSith = true;
            service.updateJedi(j);
            result = service.getAllJedi();
            Assert.IsTrue(result.Exists(x => x.Nom == j.Nom && x.IsSith == true), "Le jedi " + j.Nom + " n'a pas ete modife");

            //delete
            service.deleteJedi(j);
            result = service.getAllJedi();
            Assert.IsTrue(!result.Exists(x => x.Nom == j.Nom), "Le jedi " + j.Nom + "existe toujours");
        }

        //Matches
        [TestMethod]
        public void MatchTest()
        {
            //get
            ServiceJediReference.ServiceJediClient service = new ServiceJediReference.ServiceJediClient();
            BusinessLayer.BusinessManager bm = new BusinessLayer.BusinessManager();
            List<MatchWCF> result = service.getAllMatch();
            List<Match> original = bm.getMatches();
            List<MatchWCF> expected = new List<MatchWCF>();
            foreach (Match match in original)
            {
                expected.Add(new MatchWCF(match));
            }
            foreach (MatchWCF match in expected)
            {
                Assert.IsTrue(result.Exists(x=> (x.Jedi1.Nom == match.Jedi1.Nom && x.Jedi2.Nom == match.Jedi2.Nom)),
                    "Le match " + match.Jedi1.Nom + " contre " + match.Jedi2.Nom + " n'est pas present");
            }

            //add
            List<Jedi> jedis = bm.getJedis();
            List<Stade> stades = bm.getStades();
            MatchWCF m = new MatchWCF(new Match(0, jedis[0], jedis[1], EPhaseTournoi.DemiFinale, stades[0]));
            service.addMatch(m);
            result = service.getAllMatch();
            m = result.Find(x => x.Jedi1.Id == jedis[0].Id && x.Jedi2.Id == jedis[1].Id && x.PhaseTournoi == EPhaseTournoi.DemiFinale && x.Stade.Id == stades[0].Id);
            Assert.IsTrue(result.Exists(x => x.Id == m.Id), "Le match " + m.ToString() + " n'est pas present");

            //update
            m.PhaseTournoi = EPhaseTournoi.Finale;
            service.updateMatch(m);
            result = service.getAllMatch();
            Assert.IsTrue(result.Exists(x => x.Id == m.Id && x.PhaseTournoi == EPhaseTournoi.Finale), "Le match " + m.ToString() + " n'a pas ete modife");

            //delete
            service.deleteMatch(m);
            result = service.getAllMatch();
            Assert.IsTrue(!result.Exists(x => x.Id == m.Id), "Le match " + m.ToString() + "existe toujours");
        }

        //Stades
        [TestMethod]
        public void StadeTest()
        {
            //get
            ServiceJediReference.ServiceJediClient service = new ServiceJediReference.ServiceJediClient();
            List<StadeWCF> result = service.getAllStade();
            BusinessLayer.BusinessManager bm = new BusinessLayer.BusinessManager();
            List<Stade> original = bm.getStades();
            List<StadeWCF> expected = new List<StadeWCF>();
            foreach (Stade stade in original)
            {
                expected.Add(new StadeWCF(stade));
            }
            foreach (StadeWCF stade in expected)
            {
                Assert.IsTrue(result.Exists(x=> x.Planete == stade.Planete),"Le stade " + stade.Planete + " n'est pas present");
            }

            //add
            List<Caracteristique> caracts = bm.getCaracteristique();
            StadeWCF s = new StadeWCF(new Stade(100, "stadeTest", caracts.FindAll(x => x.Id == 1)));
            service.addStade(s);
            result = service.getAllStade();
            Assert.IsTrue(result.Exists(x => x.Id == s.Id), "Le stade " + s.Planete + " n'est pas present");

            //update
            s = result.Find(x => x.Planete == "stadeTest");
            s.NbPlaces = 150;
            service.updateStade(s);
            result = service.getAllStade();
            Assert.IsTrue(result.Exists(x => x.Planete == s.Planete && x.NbPlaces == 150), "Le stade " + s.Planete + " n'a pas ete modife");

            //delete
            service.deleteStade(s);
            result = service.getAllStade();
            Assert.IsTrue(!result.Exists(x => x.Planete == s.Planete), "Le stade " + s.Planete + "existe toujours");
        }

        //Tournois
        [TestMethod]
        public void getAllTournoiTest()
        {
            //get
            ServiceJediReference.ServiceJediClient service = new ServiceJediReference.ServiceJediClient();
            List<TournoiWCF> result = service.getAllTournoi();
            BusinessLayer.BusinessManager bm = new BusinessLayer.BusinessManager();
            List<Tournoi> original = bm.getTournoi();
            List<TournoiWCF> expected = new List<TournoiWCF>();
            foreach (Tournoi t in original)
            {
                expected.Add(new TournoiWCF(t));
            }
            foreach (TournoiWCF t in expected)
            {
                Assert.IsTrue(result.Exists(x=> x.Nom == t.Nom),"Le tournoi " + t.Nom + " n'est pas present");
            }
        }

        //STUB DONC NE MARCHE PAS

        /*  [TestMethod]
        public void addTournoiTest()
        {
            ServiceJediReference.ServiceJediClient service = new ServiceJediReference.ServiceJediClient();
            BusinessLayer.BusinessManager bm = new BusinessLayer.BusinessManager();
            bm.getTournoi();  //met a jour l'id
            List<Match> matches = bm.getMatches();
            TournoiWCF t = new TournoiWCF(new Tournoi(matches.FindAll(x=>x.Id==1),"tournoisTest"));
            service.addTournoi(t);
            List<TournoiWCF> result = service.getAllTournoi();
            Assert.IsTrue(result.Exists(x => x.Id == t.Id), "Le tournoi " + t.Nom + " n'est pas present");
        }

        [TestMethod]
        public void updateTournoiTest()
        {
            ServiceJediReference.ServiceJediClient service = new ServiceJediReference.ServiceJediClient();
            BusinessLayer.BusinessManager bm = new BusinessLayer.BusinessManager();
            bm.getTournoi();  //met a jour l'id
            TournoiWCF t = service.getAllTournoi().Find(x => x.Nom.Equals("tournoisTest"));
            t.Nom = "tournoisTest2";
            service.updateTournois(t);
            List<TournoiWCF> result = service.getAllTournoi();
            Assert.IsTrue(result.Exists(x => x.Id == t.Id && x.Nom.Equals("tournoisTest2")), "Le tournoi " + t.Nom + " n'a pas ete modife");
        }

        [TestMethod]
        public void deleteTournoiTest()
        {
            ServiceJediReference.ServiceJediClient service = new ServiceJediReference.ServiceJediClient();
            BusinessLayer.BusinessManager bm = new BusinessLayer.BusinessManager();
            bm.getTournoi();  //met a jour l'id
            TournoiWCF t = service.getAllTournoi().Find(x => x.Nom.Equals("tournoisTest2"));
            service.deleteTournois(t);
            List<TournoiWCF> result = service.getAllTournoi();
            Assert.IsTrue(!result.Exists(x => x.Nom == t.Nom), "Le tournoi " + t.Nom + "existe toujours");
        }*/

        //Caracteristique
        [TestMethod]
        public void CaracteristiqueTest()
        {
            //get
            ServiceJediReference.ServiceJediClient service = new ServiceJediReference.ServiceJediClient();
            List<CaracteristiqueWCF> result = service.getAllCaracteristique();
            BusinessLayer.BusinessManager bm = new BusinessLayer.BusinessManager();
            List<Caracteristique> original = bm.getCaracteristique();
            List<CaracteristiqueWCF> expected = new List<CaracteristiqueWCF>();
            foreach (Caracteristique cara in original)
            {
                expected.Add(new CaracteristiqueWCF(cara));
            }
            foreach (CaracteristiqueWCF cara in expected)
            {
                Assert.IsTrue(result.Exists(x=> x.Nom == cara.Nom && x.Valeur == cara.Valeur && x.Type == cara.Type && x.Definition == cara.Definition),"La caracteristique " + cara.Nom + " n'est pas presente");
            }

            //add
            CaracteristiqueWCF c = new CaracteristiqueWCF(new Caracteristique(EDefCaracteristique.Chance, "testCaract", ETypeCaracteristique.Jedi, 10));
            service.addCracteristique(c);
            result = service.getAllCaracteristique();
            Assert.IsTrue(result.Exists(x => x.Nom == c.Nom), "La caract " + c.Nom + " n'est pas presente");

            //update
            c = result.Find(x => x.Nom == "testCaract");
            c.Valeur = 20;
            service.updateCaracteristique(c);
            result = service.getAllCaracteristique();
            Assert.IsTrue(result.Exists(x => x.Nom == c.Nom && x.Valeur == 20), "La caract " + c.Nom + " n'a pas ete modifee");

            //delete
            service.deleteCaracteristique(c);
            result = service.getAllCaracteristique();
            Assert.IsTrue(!result.Exists(x => x.Nom == c.Nom), "Le caract " + c.Nom + "existe toujours");
        }

    }
}
