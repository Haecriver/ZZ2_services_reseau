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
        public void getAllJediTest()
        {
            ServiceJediReference.ServiceJediClient service = new ServiceJediReference.ServiceJediClient();
            List<JediWCF> result = service.getAllJedi();
            BusinessLayer.BusinessManager bm = new BusinessLayer.BusinessManager();
            List<Jedi> original = bm.getJedis();
            List<JediWCF> expected = new List<JediWCF>();
            foreach (Jedi j in original)
            {
                expected.Add(new JediWCF(j));
            }
            foreach (JediWCF j in expected)
            {
                Assert.IsTrue(result.Exists(x=> x.Nom == j.Nom),"Le jedi " + j.Nom + " n'est pas present");
            }
        }

        [TestMethod]
        public void addJediTest()
        {
            ServiceJediReference.ServiceJediClient service = new ServiceJediReference.ServiceJediClient();
            BusinessLayer.BusinessManager bm = new BusinessLayer.BusinessManager();
            bm.getJedis();  //met a jour l'id
            List<Caracteristique> list_carac = bm.getCaracteristique().FindAll(x => x.Id == 1);
            JediWCF j = new JediWCF(new Jedi("TestAjout", false, list_carac));
            service.addJedi(j);
            List<JediWCF> result = service.getAllJedi();
            Assert.IsTrue(result.Exists(x => x.Nom == j.Nom), "Le jedi " + j.Nom + " n'est pas present");
        }

        [TestMethod]
        public void updateJediTest()
        {
            ServiceJediReference.ServiceJediClient service = new ServiceJediReference.ServiceJediClient();
            BusinessLayer.BusinessManager bm = new BusinessLayer.BusinessManager();
            bm.getJedis();  //met a jour l'id
            JediWCF j = service.getAllJedi().Find(x => x.Nom.Equals("TestAjout"));
            j.IsSith = true;
            service.updateJedi(j);
            List<JediWCF> result = service.getAllJedi();
            Assert.IsTrue(result.Exists(x => x.Nom == j.Nom && x.IsSith == true), "Le jedi " + j.Nom + " n'a pas ete modife");
        }

        [TestMethod]
        public void deleteJediTest()
        {
            ServiceJediReference.ServiceJediClient service = new ServiceJediReference.ServiceJediClient();
            BusinessLayer.BusinessManager bm = new BusinessLayer.BusinessManager();
            bm.getJedis();  //met a jour l'id
            JediWCF j = service.getAllJedi().Find(x => x.Nom.Equals("TestAjout"));
            service.deleteJedi(j);
            List<JediWCF> result = service.getAllJedi();
            Assert.IsTrue(!result.Exists(x => x.Nom == j.Nom), "Le jedi " + j.Nom + "existe toujours");
        }

        //Matches
        [TestMethod]
        public void getAllMatchTest()
        {
            ServiceJediReference.ServiceJediClient service = new ServiceJediReference.ServiceJediClient();
            List<MatchWCF> result = service.getAllMatch();
            BusinessLayer.BusinessManager bm = new BusinessLayer.BusinessManager();
            List<Match> original = bm.getMatches();
            List<MatchWCF> expected = new List<MatchWCF>();
            foreach (Match m in original)
            {
                expected.Add(new MatchWCF(m));
            }
            foreach (MatchWCF m in expected)
            {
                Assert.IsTrue(result.Exists(x=> (x.Jedi1.Nom == m.Jedi1.Nom && x.Jedi2.Nom == m.Jedi2.Nom)),"Le match " + m.Jedi1.Nom + " contre " + m.Jedi2.Nom + " n'est pas present");
            }
        }

        [TestMethod]
        public void addMatchTest()
        {
            ServiceJediReference.ServiceJediClient service = new ServiceJediReference.ServiceJediClient();
            BusinessLayer.BusinessManager bm = new BusinessLayer.BusinessManager();
            bm.getMatches();  //met a jour l'id
            List<Jedi> jedis = bm.getJedis();
            List<Stade> stades = bm.getStades();
            MatchWCF m = new MatchWCF(new Match(0,jedis[0], jedis[1], EPhaseTournoi.DemiFinale,stades[0]));
            service.addMatch(m);
            List<MatchWCF> result = service.getAllMatch();
            Assert.IsTrue(result.Exists(x => x.Id == m.Id), "Le match " + m.ToString() + " n'est pas present");
        }

        [TestMethod]
        public void updateMatchTest()
        {
            ServiceJediReference.ServiceJediClient service = new ServiceJediReference.ServiceJediClient();
            BusinessLayer.BusinessManager bm = new BusinessLayer.BusinessManager();
            bm.getMatches();  //met a jour l'id
            MatchWCF m = service.getAllMatch().Find(x => x.Id==0);
            m.PhaseTournoi = EPhaseTournoi.Finale;
            service.updateMatch(m);
            List<MatchWCF> result = service.getAllMatch();
            Assert.IsTrue(result.Exists(x => x.Id == m.Id && x.PhaseTournoi == EPhaseTournoi.Finale), "Le match " + m.ToString() + " n'a pas ete modife");
        }

        [TestMethod]
        public void deleteMatchTest()
        {
            ServiceJediReference.ServiceJediClient service = new ServiceJediReference.ServiceJediClient();
            BusinessLayer.BusinessManager bm = new BusinessLayer.BusinessManager();
            bm.getMatches();  //met a jour l'id
            MatchWCF m = service.getAllMatch().Find(x => x.Id == 0);
            service.deleteMatch(m);
            List<MatchWCF> result = service.getAllMatch();
            Assert.IsTrue(!result.Exists(x => x.Id == m.Id), "Le match " + m.ToString() + "existe toujours");
        }

        //Stades
        [TestMethod]
        public void getAllStadeTest()
        {
            ServiceJediReference.ServiceJediClient service = new ServiceJediReference.ServiceJediClient();
            List<StadeWCF> result = service.getAllStade();
            BusinessLayer.BusinessManager bm = new BusinessLayer.BusinessManager();
            List<Stade> original = bm.getStades();
            List<StadeWCF> expected = new List<StadeWCF>();
            foreach (Stade s in original)
            {
                expected.Add(new StadeWCF(s));
            }
            foreach (StadeWCF s in expected)
            {
                Assert.IsTrue(result.Exists(x=> x.Planete == s.Planete),"Le stade " + s.Planete + " n'est pas present");
            }
        }
        [TestMethod]
        public void addStadeTest()
        {
            ServiceJediReference.ServiceJediClient service = new ServiceJediReference.ServiceJediClient();
            BusinessLayer.BusinessManager bm = new BusinessLayer.BusinessManager();
            bm.getStades();  //met a jour l'id
            List<Caracteristique> caracts = bm.getCaracteristique();
            StadeWCF s = new StadeWCF(new Stade(100,"stadeTest",caracts.FindAll(x=>x.Id==1)));
            service.addStade(s);
            List<StadeWCF> result = service.getAllStade();
            Assert.IsTrue(result.Exists(x => x.Id == s.Id), "Le stade " + s.Planete + " n'est pas present");
        }

        [TestMethod]
        public void updateStadeTest()
        {
            ServiceJediReference.ServiceJediClient service = new ServiceJediReference.ServiceJediClient();
            BusinessLayer.BusinessManager bm = new BusinessLayer.BusinessManager();
            bm.getStades();  //met a jour l'id
            StadeWCF s = service.getAllStade().Find(x => x.Planete.Equals("stadeTest"));
            s.NbPlaces = 150;
            service.updateStade(s);
            List<StadeWCF> result = service.getAllStade();
            Assert.IsTrue(result.Exists(x => x.Planete == s.Planete && x.NbPlaces == 150), "Le stade " + s.Planete + " n'a pas ete modife");
        }

        [TestMethod]
        public void deleteStadeTest()
        {
            ServiceJediReference.ServiceJediClient service = new ServiceJediReference.ServiceJediClient();
            BusinessLayer.BusinessManager bm = new BusinessLayer.BusinessManager();
            bm.getStades();  //met a jour l'id
            StadeWCF s = service.getAllStade().Find(x => x.Planete.Equals("stadeTest"));
            service.deleteStade(s);
            List<StadeWCF> result = service.getAllStade();
            Assert.IsTrue(!result.Exists(x => x.Planete == s.Planete), "Le stade " + s.Planete + "existe toujours");
        }


        //Tournois
        [TestMethod]
        public void getAllTournoiTest()
        {
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
        public void getAllCaracteristiqueTest()
        {
            ServiceJediReference.ServiceJediClient service = new ServiceJediReference.ServiceJediClient();
            List<CaracteristiqueWCF> result = service.getAllCaracteristique();
            BusinessLayer.BusinessManager bm = new BusinessLayer.BusinessManager();
            List<Caracteristique> original = bm.getCaracteristique();
            List<CaracteristiqueWCF> expected = new List<CaracteristiqueWCF>();
            foreach (Caracteristique c in original)
            {
                expected.Add(new CaracteristiqueWCF(c));
            }
            foreach (CaracteristiqueWCF c in expected)
            {
                Assert.IsTrue(result.Exists(x=> x.Nom == c.Nom && x.Valeur == c.Valeur && x.Type == c.Type && x.Definition == c.Definition),"La caracteristique " + c.Nom + " n'est pas presente");
            }
        }

        [TestMethod]
        public void addCaracteristiqueTest()
        {
            ServiceJediReference.ServiceJediClient service = new ServiceJediReference.ServiceJediClient();
            BusinessLayer.BusinessManager bm = new BusinessLayer.BusinessManager();
            bm.getCaracteristique();  //met a jour l'id
            CaracteristiqueWCF c = new CaracteristiqueWCF(new Caracteristique(EDefCaracteristique.Chance,"testCaract",ETypeCaracteristique.Jedi,10));
            service.addCracteristique(c);
            List<CaracteristiqueWCF> result = service.getAllCaracteristique();
            Assert.IsTrue(result.Exists(x => x.Nom == c.Nom), "La caract " + c.Nom + " n'est pas presente");
        }

        [TestMethod]
        public void updateCaracteristiqueTest()
        {
            ServiceJediReference.ServiceJediClient service = new ServiceJediReference.ServiceJediClient();
            BusinessLayer.BusinessManager bm = new BusinessLayer.BusinessManager();
            bm.getCaracteristique();  //met a jour l'id
            CaracteristiqueWCF c = service.getAllCaracteristique().Find(x => x.Nom.Equals("testCaract"));
            c.Valeur = 20;
            service.updateCaracteristique(c);
            List<CaracteristiqueWCF> result = service.getAllCaracteristique();
            Assert.IsTrue(result.Exists(x => x.Nom == c.Nom && x.Valeur == 20), "La caract " + c.Nom + " n'a pas ete modifee");
        }

        [TestMethod]
        public void deleteCaracteristiqueTest()
        {
            ServiceJediReference.ServiceJediClient service = new ServiceJediReference.ServiceJediClient();
            BusinessLayer.BusinessManager bm = new BusinessLayer.BusinessManager();
            bm.getCaracteristique();  //met a jour l'id
            CaracteristiqueWCF c = service.getAllCaracteristique().Find(x => x.Nom.Equals("testCaract"));
            service.deleteCaracteristique(c);
            List<CaracteristiqueWCF> result = service.getAllCaracteristique();
            Assert.IsTrue(!result.Exists(x => x.Nom == c.Nom), "Le caract " + c.Nom + "existe toujours");
        }


    }
}
