using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntitiesLayer;

namespace StubDataAccessLayer
{
    public class DalManager
    {
        private List<Jedi> allJedi;
        private List<Match> allMatch;
        private List<Stade> allStade;
        private List<Caracteristique> allCharacteristics;
        private SortedDictionary<string, Utilisateur> allUtilisateurs;

        // Ajout de donnees factices
        private void stuber()
        {
            // Ajout de Caracteristiques
            allCharacteristics = new List<Caracteristique>();
            allCharacteristics.Add(new Caracteristique(1, EDefCaracteristique.Chance, "Utilisation de la force", ETypeCaracteristique.Jedi, 18));
            allCharacteristics.Add(new Caracteristique(1, EDefCaracteristique.Defense, "Agilite", ETypeCaracteristique.Jedi, 5));
            allCharacteristics.Add(new Caracteristique(1, EDefCaracteristique.Sante, "Armure", ETypeCaracteristique.Jedi, 100));
            allCharacteristics.Add(new Caracteristique(1, EDefCaracteristique.Force, "Badassitude", ETypeCaracteristique.Jedi, 7));
            allCharacteristics.Add(new Caracteristique(5, EDefCaracteristique.Force, "Lave", ETypeCaracteristique.Stade, 12));

            // Ajout de Jedis
            allJedi = new List<Jedi>();
            List<Caracteristique> lc = new List<Caracteristique>();
            lc.Add(new Caracteristique(1, EDefCaracteristique.Force, "Force", ETypeCaracteristique.Jedi, 90));
            lc.Add(new Caracteristique(4, EDefCaracteristique.Sante, "Santé", ETypeCaracteristique.Jedi, 90));
            allJedi.Add(new Jedi(0, "Luke", false, lc));

            lc = new List<Caracteristique>();
            lc.Add(new Caracteristique(2, EDefCaracteristique.Force, "Force", ETypeCaracteristique.Jedi, 95));
            lc.Add(new Caracteristique(3, EDefCaracteristique.Sante, "Santé", ETypeCaracteristique.Jedi, 85));
            allJedi.Add(new Jedi(1, "Anakin", true, lc));

            List<Caracteristique> CaractBenjamen = getAllCaracteristic();
            allJedi.Add(new Jedi(2, "Benjamin",  true,  CaractBenjamen));

            List<Caracteristique> CaractCat = getAllCaracteristic().Where(c => c.Id == 1).ToList();
            allJedi.Add(new Jedi(3, "Cataracte", true, CaractCat));
            
            // Ajout de Stades
            allStade = new List<Stade>();
            List<Caracteristique> caractStade = getAllCaracteristic().Where(c => c.Id == 5).ToList();
            allStade.Add(new Stade(1, 300, "Jakku", caractStade));

            // Ajout de Matchs
            allMatch = new List<Match>();
            allMatch.Add(new Match(1, 2, allJedi[0], allJedi[2], EPhaseTournoi.Finale, allStade[0]));
            
            // Ajout d'Utilisateur
            allUtilisateurs = new SortedDictionary<string, Utilisateur>();
            allUtilisateurs["pierre-loup"] = new Utilisateur("Pissavy", "Pierre-Loup", "pierre-loup", "totoestbete");
            allUtilisateurs["anne-lise"] = new Utilisateur("Michel", "Anne-Lise", "anne-lise", "moustache");
            allUtilisateurs["pierre"] = new Utilisateur("Chevalier", "Pierre", "pierre", "jveuxdire");
            allUtilisateurs["gael"] = new Utilisateur("Raux", "Gaël", "gael", "brest");
            
            allUtilisateurs["begarco"] = new Utilisateur("Garcon", "Benoit", "begarco", "suce"); // l'intru
        }

        public DalManager()
        {
            stuber();
        }

        public List<Jedi> getAllJedi()
        {    
            return allJedi;
        }

        public List<Match> getAllMatch()
        {
            
            return allMatch;
        }

        public List<Stade> getAllStade()
        {
            
            return allStade;
        }

        public List<Caracteristique> getAllCaracteristic()
        {
            return allCharacteristics;
        }


        public Utilisateur getUtilisateurByLogin(string login) {
            try
            {
                return allUtilisateurs[login];
            }
            catch (KeyNotFoundException)
            {
                return null;
            }

        }
    }
}
