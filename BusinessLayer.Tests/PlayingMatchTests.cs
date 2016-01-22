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
        private static StubDataAccessLayer.DalManager data = new StubDataAccessLayer.DalManager();

        [TestMethod]
        public void TestTurn_AnakinForce_LukeDefense()
        {
            Jedi papa = data.getAllJedi().Find(j => j.Nom == "Anakin");
            Jedi fiston = data.getAllJedi().Find(j => j.Nom == "Luke");
            Stade stade = data.getAllStade().Find(s => s.Planete == "Jakku");
            Match leDuelDelAnnee = new Match(42, papa, fiston, EPhaseTournoi.Finale, stade);
            PlayingMatch match = new PlayingMatch(leDuelDelAnnee);
            match.playTurn(EDefCaracteristique.Force, EDefCaracteristique.Defense);
            Assert.AreEqual(match.DammageInfliged, 535); //Le fiston se prend 535 !
            Assert.IsTrue(match.MatchOver);
            Assert.AreEqual(leDuelDelAnnee.IdJediVainqueur, papa.Id);

        }
    }
}
