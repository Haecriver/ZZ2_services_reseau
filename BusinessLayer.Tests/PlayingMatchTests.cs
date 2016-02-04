using System;
using BusinessLayer;
using EntitiesLayer;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BusinessLayer.Tests
{
    [TestClass]
    public class PlayingMatchTests
    {
        private static DataAccessLayer.DalManager data = new DataAccessLayer.DalManager();

        [TestMethod]
        public void TestTurn_DarthVaderForce_LukeDefense_onJakku()
        {
            Jedi papa = data.getAllJedi().Find(j => j.Nom == "Darth Vader");
            Jedi fiston = data.getAllJedi().Find(j => j.Nom == "Luke");
            Stade stade = data.getAllStade().Find(s => s.Planete == "Jakku");
            Match leDuelDelAnnee = new Match(42, papa, fiston, EPhaseTournoi.Finale, stade);
            PlayingMatch match = new PlayingMatch(leDuelDelAnnee);
            match.playTurn(EDefCaracteristique.Force, EDefCaracteristique.Defense);
            Assert.AreEqual(match.WinnerJedi, papa);
            Assert.AreEqual(match.LooserJedi, fiston);
            Assert.AreEqual(match.DamageInflicted, 280); //Le fiston se prend 280 !
            Assert.AreEqual(match.PJedi1.HpJedi, 90);
            Assert.AreEqual(match.PJedi2.HpJedi, -250);
            Assert.IsTrue(match.MatchOver);
            Assert.AreEqual(leDuelDelAnnee.JediVainqueur, papa);
        }

        [TestMethod]
        public void TestTurn_MaitreYodaDefense_PalpatineChance_onEndor()
        {
            Jedi yoda = data.getAllJedi().Find(j => j.Nom == "Maitre Yoda");
            Jedi palpatine = data.getAllJedi().Find(j => j.Nom == "Palpatine");
            Stade stade = data.getAllStade().Find(s => s.Planete == "Endor");
            Match chezLesPetits = new Match(42, yoda, palpatine, EPhaseTournoi.DemiFinale, stade);
            PlayingMatch match = new PlayingMatch(chezLesPetits);
            match.playTurn(EDefCaracteristique.Defense, EDefCaracteristique.Chance);
            Assert.AreEqual(match.WinnerJedi, yoda);
            Assert.AreEqual(match.LooserJedi, palpatine);
            Assert.AreEqual(match.DamageInflicted, 470); //palpatine se prend 470 !
            Assert.AreEqual(match.PJedi1.HpJedi, 30);
            Assert.AreEqual(match.PJedi2.HpJedi, -420);
            Assert.IsTrue(match.MatchOver);
            Assert.AreEqual(chezLesPetits.JediVainqueur, yoda);
        }
    }
}
