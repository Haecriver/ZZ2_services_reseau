using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using JediService.BusinessWCF;
using System.Collections.Generic;
using BusinessLayer;
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
            List<Jedi> original = JediService.ServiceJedi.bm.getJedis();
            List<JediWCF> expected = new List<JediWCF>();
            foreach (Jedi j in original)
            {
                expected.Add(new JediWCF(j));
            }
            foreach (JediWCF j in expected)
            {
                //Assert.IsTrue(result.Exists(x=> x.Nom == j.Nom),"Le jedi " + j.Nom + " n'est pas present");
            }
        }
        
        [TestMethod]
        public void getAllMatchTest()
        {

        }

        [TestMethod]
        public void getAllStadeTest()
        {

        }

        [TestMethod]
        public void getAllTournoiTest()
        {

        }

        [TestMethod]
        public void getAllCaracteristiqueTest()
        {

        }

        [TestMethod]
        public void addJediTest()
        {

        }
    }
}
