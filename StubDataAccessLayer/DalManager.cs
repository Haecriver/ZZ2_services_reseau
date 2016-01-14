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
            allJedi = new List<Jedi>(2);
            allMatch = new List<Match>(2);
            allStade = new List<Stade>(2);
            allCharacteristics = new List<Caracteristique>(2);
            allUtilisateurs = new SortedDictionary<string, Utilisateur>();
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
