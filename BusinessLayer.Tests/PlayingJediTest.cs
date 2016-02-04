using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BusinessLayer.Tests
{
    [TestClass]
    public class PlayingJediTest
    {
        private static DataAccessLayer.DalManager data = new DataAccessLayer.DalManager();

        [TestMethod]
        public void TestCaracs_Luke()
        {
            PlayingJedi jedi = new PlayingJedi(data.getAllJedi().Find(j => j.Nom == "Luke"));
            Assert.AreEqual(jedi.HpJedi, 50);
            Assert.AreEqual(jedi.CaractForce, 70);
            Assert.AreEqual(jedi.CaractDefense, 20);
            Assert.AreEqual(jedi.CaractChance, 60);
        }

        [TestMethod]
        public void TestCaracs_DarthVader()
        {
            PlayingJedi jedi = new PlayingJedi(data.getAllJedi().Find(j => j.Nom == "Darth Vader"));
            Assert.AreEqual(jedi.HpJedi, 110);
            Assert.AreEqual(jedi.CaractForce, 60);
            Assert.AreEqual(jedi.CaractDefense, 20);
            Assert.AreEqual(jedi.CaractChance, 80);
        }

        [TestMethod]
        public void TestCaracs_ObiWanKenobi()
        {
            PlayingJedi jedi = new PlayingJedi(data.getAllJedi().Find(j => j.Nom == "Obi Wan Kenobi"));
            Assert.AreEqual(jedi.HpJedi, 50);
            Assert.AreEqual(jedi.CaractForce, 70);
            Assert.AreEqual(jedi.CaractDefense, 40);
            Assert.AreEqual(jedi.CaractChance, 60);
        }

        [TestMethod]
        public void TestCaracs_JarJar()
        {
            PlayingJedi jedi = new PlayingJedi(data.getAllJedi().Find(j => j.Nom == "JarJar"));
            Assert.AreEqual(jedi.HpJedi, 30);
            Assert.AreEqual(jedi.CaractForce, 20);
            Assert.AreEqual(jedi.CaractDefense, 20);
            Assert.AreEqual(jedi.CaractChance, 120);
        }

        [TestMethod]
        public void TestCaracs_Palpatine()
        {
            PlayingJedi jedi = new PlayingJedi(data.getAllJedi().Find(j => j.Nom == "Palpatine"));
            Assert.AreEqual(jedi.HpJedi, 50);
            Assert.AreEqual(jedi.CaractForce, 50);
            Assert.AreEqual(jedi.CaractDefense, 60);
            Assert.AreEqual(jedi.CaractChance, 80);
        }

        [TestMethod]
        public void TestCaracs_MaceWindu()
        {
            PlayingJedi jedi = new PlayingJedi(data.getAllJedi().Find(j => j.Nom == "Mace Windu"));
            Assert.AreEqual(jedi.HpJedi, 70);
            Assert.AreEqual(jedi.CaractForce, 40);
            Assert.AreEqual(jedi.CaractDefense, 40);
            Assert.AreEqual(jedi.CaractChance, 40);
        }

        [TestMethod]
        public void TestCaracs_Rey()
        {
            PlayingJedi jedi = new PlayingJedi(data.getAllJedi().Find(j => j.Nom == "Rey"));
            Assert.AreEqual(jedi.HpJedi, 50);
            Assert.AreEqual(jedi.CaractForce, 20);
            Assert.AreEqual(jedi.CaractDefense, 20);
            Assert.AreEqual(jedi.CaractChance, 100);
        }

        [TestMethod]
        public void TestCaracs_DarthPlagueis()
        {
            PlayingJedi jedi = new PlayingJedi(data.getAllJedi().Find(j => j.Nom == "Darth Plagueis"));
            Assert.AreEqual(jedi.HpJedi, 70);
            Assert.AreEqual(jedi.CaractForce, 20);
            Assert.AreEqual(jedi.CaractDefense, 20);
            Assert.AreEqual(jedi.CaractChance, 80);
        }

        [TestMethod]
        public void TestCaracs_Grievous()
        {
            PlayingJedi jedi = new PlayingJedi(data.getAllJedi().Find(j => j.Nom == "Grievous"));
            Assert.AreEqual(jedi.HpJedi, 130);
            Assert.AreEqual(jedi.CaractForce, 60);
            Assert.AreEqual(jedi.CaractDefense, 20);
            Assert.AreEqual(jedi.CaractChance, 0);
        }

        [TestMethod]
        public void TestCaracs_DarthMaul()
        {
            PlayingJedi jedi = new PlayingJedi(data.getAllJedi().Find(j => j.Nom == "Darth Maul"));
            Assert.AreEqual(jedi.HpJedi, 50);
            Assert.AreEqual(jedi.CaractForce, 60);
            Assert.AreEqual(jedi.CaractDefense, 40);
            Assert.AreEqual(jedi.CaractChance, 40);
        }

        [TestMethod]
        public void TestCaracs_ComteDooku()
        {
            PlayingJedi jedi = new PlayingJedi(data.getAllJedi().Find(j => j.Nom == "Comte Dooku"));
            Assert.AreEqual(jedi.HpJedi, 70);
            Assert.AreEqual(jedi.CaractForce, 50);
            Assert.AreEqual(jedi.CaractDefense, 40);
            Assert.AreEqual(jedi.CaractChance, 80);
        }

        [TestMethod]
        public void TestCaracs_KiAdiMundi()
        {
            PlayingJedi jedi = new PlayingJedi(data.getAllJedi().Find(j => j.Nom == "Ki Adi Mundi"));
            Assert.AreEqual(jedi.HpJedi, 70);
            Assert.AreEqual(jedi.CaractForce, 40);
            Assert.AreEqual(jedi.CaractDefense, 20);
            Assert.AreEqual(jedi.CaractChance, 60);
        }

        [TestMethod]
        public void TestCaracs_LuminaraUnduli()
        {
            PlayingJedi jedi = new PlayingJedi(data.getAllJedi().Find(j => j.Nom == "Luminara Unduli"));
            Assert.AreEqual(jedi.HpJedi, 70);
            Assert.AreEqual(jedi.CaractForce, 20);
            Assert.AreEqual(jedi.CaractDefense, 20);
            Assert.AreEqual(jedi.CaractChance, 60);
        }

        [TestMethod]
        public void TestCaracs_MaitreYoda()
        {
            PlayingJedi jedi = new PlayingJedi(data.getAllJedi().Find(j => j.Nom == "Maitre Yoda"));
            Assert.AreEqual(jedi.HpJedi, 30);
            Assert.AreEqual(jedi.CaractForce, 100);
            Assert.AreEqual(jedi.CaractDefense, 100);
            Assert.AreEqual(jedi.CaractChance, 100);
        }

        [TestMethod]
        public void TestCaracs_PloKoon()
        {
            PlayingJedi jedi = new PlayingJedi(data.getAllJedi().Find(j => j.Nom == "Plo Koon"));
            Assert.AreEqual(jedi.HpJedi, 70);
            Assert.AreEqual(jedi.CaractForce, 20);
            Assert.AreEqual(jedi.CaractDefense, 20);
            Assert.AreEqual(jedi.CaractChance, 60);
        }

        [TestMethod]
        public void TestCaracs_AshokaTano()
        {
            PlayingJedi jedi = new PlayingJedi(data.getAllJedi().Find(j => j.Nom == "Ashoka Tano"));
            Assert.AreEqual(jedi.HpJedi, 50);
            Assert.AreEqual(jedi.CaractForce, 20);
            Assert.AreEqual(jedi.CaractDefense, 40);
            Assert.AreEqual(jedi.CaractChance, 40);
        }

        [TestMethod]
        public void TestCaracs_ShaakTi()
        {
            PlayingJedi jedi = new PlayingJedi(data.getAllJedi().Find(j => j.Nom == "Shaak Ti"));
            Assert.AreEqual(jedi.HpJedi, 70);
            Assert.AreEqual(jedi.CaractForce, 20);
            Assert.AreEqual(jedi.CaractDefense, 20);
            Assert.AreEqual(jedi.CaractChance, 60);
        }

        [TestMethod]
        public void TestCaracs_KyloRen()
        {
            PlayingJedi jedi = new PlayingJedi(data.getAllJedi().Find(j => j.Nom == "Kylo Ren"));
            Assert.AreEqual(jedi.HpJedi, 90);
            Assert.AreEqual(jedi.CaractForce, 20);
            Assert.AreEqual(jedi.CaractDefense, 20);
            Assert.AreEqual(jedi.CaractChance, 40);
        }

        [TestMethod]
        public void TestCaracs_DarthBane()
        {
            PlayingJedi jedi = new PlayingJedi(data.getAllJedi().Find(j => j.Nom == "Darth Bane"));
            Assert.AreEqual(jedi.HpJedi, 110);
            Assert.AreEqual(jedi.CaractForce, 40);
            Assert.AreEqual(jedi.CaractDefense, 0);
            Assert.AreEqual(jedi.CaractChance, 80);
        }

        [TestMethod]
        public void TestCaracs_DarthMalgus()
        {
            PlayingJedi jedi = new PlayingJedi(data.getAllJedi().Find(j => j.Nom == "Darth Malgus"));
            Assert.AreEqual(jedi.HpJedi, 110);
            Assert.AreEqual(jedi.CaractForce, 40);
            Assert.AreEqual(jedi.CaractDefense, 20);
            Assert.AreEqual(jedi.CaractChance, 80);
        }
    }
}
