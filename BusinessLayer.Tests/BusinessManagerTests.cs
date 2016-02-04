using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using EntitiesLayer;

namespace BusinessLayer.Tests
{

    [TestClass]
    public class BusinessManagerTests
    {
        private static DataAccessLayer.DalManager data = new DataAccessLayer.DalManager();

        [TestMethod]
        public void TestBDD_AjoutSupprCarac()
        {
            List<Caracteristique> lc = new List<Caracteristique>(data.getAllCaracteristic());
            // Création de la caractéristique
            int id = 42;
            EDefCaracteristique def = EDefCaracteristique.Chance;
            String text = "Carac ajoutée Jedi";
            ETypeCaracteristique type = ETypeCaracteristique.Jedi;
            int val = 20;
            Caracteristique carac = new Caracteristique(id, def, text, type, val);

            // Modifications BDD
            Assert.IsFalse(data.getAllCaracteristic().Any(c => c.Id == id), "Cette caractéristique est déjà présente dans la BDD !");    // On vérifie que la caractéristique n'est pas déjà présente dans la BDD
            
            lc.Add(carac);
            data.updateCaracteristique(lc);

            Assert.IsTrue(data.getAllCaracteristic().Any(c => c.Id == id), "La caractéristique n'a pas été ajoutée");     // On vérifie que la caractéristique a bien été rajoutée
            
            lc.Remove(lc.Find(c => c.Id == id));
            data.updateCaracteristique(lc);

            Assert.IsFalse(data.getAllCaracteristic().Any(c => c.Id == id), "La caractéristique n'a pas été supprimée");    // On vérifie que la caractéristique a bien été supprimée
        }

        [TestMethod]
        public void TestBDD_AjoutSupprJedi()
        {
            List<Jedi> lj = new List<Jedi>(data.getAllJedi());
            // Création du jedi
            int id = 42;
            String name = "Sloubi";
            bool isSith = true;
            Caracteristique carac = data.getAllCaracteristic().Find(c => c.Id == 1);

            List<Caracteristique> lc = new List<Caracteristique>();
            lc.Add(carac);

            Jedi jedi = new Jedi(id, name, isSith, lc);

            // Modifications BDD
            Assert.IsFalse(data.getAllJedi().Any(j => j.Id == id), "Ce jedi est déjà présent dans la BDD !");    // On vérifie que le jedi n'est pas déjà présent dans la BDD

            lj.Add(jedi);
            data.updateJedi(lj);

            Assert.IsTrue(data.getAllJedi().Any(j => j.Id == id), "Le jedi n'a pas été ajouté");     // On vérifie que le jedi a bien été rajouté

            lj.Remove(lj.Find(j => j.Id == id));
            data.updateJedi(lj);

            Assert.IsFalse(data.getAllJedi().Any(j => j.Id == id), "Le jedi n'a pas été supprimé");    // On vérifie que le jedi a bien été supprimé
        }

        [TestMethod]
        public void TestBDD_AjoutSupprStade()
        {
            List<Stade> ls = new List<Stade>(data.getAllStade());
            // Création du stade
            int id = 42;
            int nbplaces = 42000;
            String name = "Youpi";
            Caracteristique carac = data.getAllCaracteristic().Find(c => c.Id == 22);

            List<Caracteristique> lc = new List<Caracteristique>();
            lc.Add(carac);

            Stade stade = new Stade(id, nbplaces, name, lc);

            // Modifications BDD
            Assert.IsFalse(data.getAllStade().Any(s => s.Id == id), "Ce stade est déjà présent dans la BDD !");    // On vérifie que le stade n'est pas déjà présent dans la BDD

            ls.Add(stade);
            data.updateStade(ls);

            Assert.IsTrue(data.getAllStade().Any(s => s.Id == id), "Le stade n'a pas été ajouté");     // On vérifie que le stade a bien été rajouté

            ls.Remove(ls.Find(s => s.Id == id));
            data.updateStade(ls);

            Assert.IsFalse(data.getAllStade().Any(s => s.Id == id), "Le stade n'a pas été supprimé");    // On vérifie que le stade a bien été supprimé
        }

        [TestMethod]
        public void TestBDD_AjoutSupprMatch()
        {
            List<Match> lm = new List<Match>(data.getAllMatch());
            // Création du match
            int id = 42;
            Jedi pJedi1 = data.getAllJedi().Find(j => j.Id == 8);
            Jedi pJedi2 = data.getAllJedi().Find(j => j.Id == 13);
            EPhaseTournoi phase = EPhaseTournoi.Finale;
            Stade stade = data.getAllStade().Find(c => c.Id == 5);

            Match match = new Match(id, pJedi1, pJedi2, phase, stade);

            // Modifications BDD
            Assert.IsFalse(data.getAllMatch().Any(m => m.Id == id), "Ce match est déjà présent dans la BDD !");    // On vérifie que le match n'est pas déjà présent dans la BDD

            lm.Add(match);
            data.updateMatch(lm);

            Assert.IsTrue(data.getAllMatch().Any(m => m.Id == id), "Le match n'a pas été ajouté");     // On vérifie que le match a bien été rajouté

            lm.Remove(lm.Find(m => m.Id == id));
            data.updateMatch(lm);

            Assert.IsFalse(data.getAllMatch().Any(m => m.Id == id), "Le match n'a pas été supprimé");    // On vérifie que le match a bien été supprimé
        }

        [TestMethod]
        public void TestBDD_AjoutSupprUser()
        {
            List<Utilisateur> lu = new List<Utilisateur>(data.getAllUtilisateur());
            // Création de l'utilisateur
            int id = 42;
            String nom = "Perceval";
            String prenom = "le Gallois";
            String login = "Sloubi";
            String pass = "youpi";

            Utilisateur user = new Utilisateur(id, nom, prenom, login, pass);

            // Modifications BDD
            Assert.IsFalse(data.getAllUtilisateur().Any(u => u.Id == id), "Cet utilisateur est déjà présent dans la BDD !");    // On vérifie que l'utilisateur n'est pas déjà présent dans la BDD

            lu.Add(user);
            data.updateUtilisateur(lu);

            Assert.IsTrue(data.getAllUtilisateur().Any(u => u.Id == id), "L'utilisateur n'a pas été ajouté");     // On vérifie que l'utilisateur a bien été rajouté

            lu.Remove(lu.Find(u => u.Id == id));
            data.updateUtilisateur(lu);

            Assert.IsFalse(data.getAllUtilisateur().Any(u => u.Id == id), "L'utilisateur n'a pas été supprimé");    // On vérifie que l'utilisateur a bien été supprimé
        }
    }
}
