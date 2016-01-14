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

        public DalManager()
        {
            allJedi = new List<Jedi>();
            List<Caracteristique> lc = new List<Caracteristique>();
            lc.Add(new Caracteristique(1, EDefCaracteristique.Force, "Force", ETypeCaracteristique.Jedi, 90));
            lc.Add(new Caracteristique(4, EDefCaracteristique.Sante, "Santé", ETypeCaracteristique.Jedi, 90));
            allJedi.Add(new Jedi(0, "Luke", false, lc));
            lc = new List<Caracteristique>();
            lc.Add(new Caracteristique(2, EDefCaracteristique.Force, "Force", ETypeCaracteristique.Jedi, 95));
            lc.Add(new Caracteristique(3, EDefCaracteristique.Sante, "Santé", ETypeCaracteristique.Jedi, 85));
            allJedi.Add(new Jedi(1, "Anakin", true, lc));

            allMatch = new List<Match>();

            allStade = new List<Stade>();

            allCharacteristics = new List<Caracteristique>();

            allUtilisateurs = new SortedDictionary<string, Utilisateur>();
            allUtilisateurs["pierre-loup"] = new Utilisateur("Pissavy", "Pierre-Loup", "pierre-loup", "totoestbete");
            allUtilisateurs["anne-lise"] = new Utilisateur("Michel", "Anne-Lise", "anne-lise", "moustache");
            allUtilisateurs["pierre"] = new Utilisateur("Chevalier", "Pierre", "pierre", "jveuxdire");
            allUtilisateurs["gael"] = new Utilisateur("Raux", "Gaël", "gael", "brest");
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
