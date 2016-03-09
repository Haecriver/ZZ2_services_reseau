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
        public void addJediTest()
        {
            ServiceJediReference.ServiceJediClient service = new ServiceJediReference.ServiceJediClient();
            BusinessLayer.BusinessManager bm = new BusinessLayer.BusinessManager();
            bm.getJedis();  //met a jour l'id
            List<Caracteristique> list_carac = bm.getCaracteristique().FindAll(x=> x.Id == 1);
            JediWCF j = new JediWCF(new Jedi("TestAjout",false,list_carac));
            service.addJedi(j);
            List<JediWCF> result = service.getAllJedi();
            Assert.IsTrue(result.Exists(x=> x.Nom == j.Nom),"Le jedi " + j.Nom + " n'est pas present");
        }

        [TestMethod]
        public void updateJediTest()
        {
            ServiceJediReference.ServiceJediClient service = new ServiceJediReference.ServiceJediClient();
            BusinessLayer.BusinessManager bm = new BusinessLayer.BusinessManager();
            bm.getJedis();  //met a jour l'id
            JediWCF j = service.getAllJedi().Find(x => x.Nom.Equals("TestAjout"));
            j.IsSith=true;
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
    }
}
