using EntitiesLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class BusinessManager
    {
        private StubDataAccessLayer.DalManager Data;

        public BusinessManager()
        {
            Data = new StubDataAccessLayer.DalManager();
        }

        public List<String> printStades()
        {
            List<String> l = new List<string>();
            foreach (var st in Data.getAllStade())
            {
                l.Add(st.ToString());
            }
            return l;
        }

        public List<String> printObscurJedis()
        {
            List<String> l = new List<string>();
            foreach (EntitiesLayer.Jedi je in Data.getAllJedi())
            {
                if (je.IsSith) {
                    l.Add(je.ToString());
                }
            }
            return l;
        }

        public List<String> printJedis(int strengthPts, int lifePts)
        {
            List<String> l = new List<string>();
            int okay;
            foreach (EntitiesLayer.Jedi je in Data.getAllJedi())
            {
                okay = 0;
                foreach (EntitiesLayer.Caracteristique c in je.Caracteristiques)
                {
                    if (c.Definition == EntitiesLayer.EDefCaracteristique.Force && c.Valeur > strengthPts)
                    {
                        okay++;
                    } else if (c.Definition == EntitiesLayer.EDefCaracteristique.Sante  && c.Valeur > lifePts)
                    {
                        okay++;
                    }
                }
                if (okay == 2)
                {
                    l.Add(je.ToString());
                }
            }
            return l;
        }

        public void printSithMatchesOver200()
        {
            throw new NotImplementedException();
        }

        public bool CheckConnexionUser(string login, string password)
        {
            bool result;
            try
            {
                Utilisateur u = Data.getUtilisateurByLogin(login);
                result = (u.Password == password);
            }
            catch (NullReferenceException)
            {
                result = false;
            }
            return result;
        }
    }

}
