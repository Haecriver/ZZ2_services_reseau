using EntitiesLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace BusinessLayer
{
    public class BusinessManager
    {
        private StubDataAccessLayer.DalManager Data;

        public BusinessManager()
        {
            Data = new StubDataAccessLayer.DalManager();
        }

        public List<string> getStades()
        {
            List<String> l = new List<string>();
            foreach (var st in Data.getAllStade())
            {
                l.Add(st.ToString());
            }
            return l;
        }

        public List<string> getObscurJedis()
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

        public List<string> getJedis()
        {
            return getJedis(-1, -1);
        }

        public List<string> getJedis(int strengthPts, int lifePts)
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

        public List<string> getMatchs()
        {
            List<string> l = new List<string>();
            foreach (EntitiesLayer.Match ma in Data.getAllMatch())
            {
                l.Add(ma.ToString());
            }
            return l;
        }

        public List<string> getCaracteristics()
        {
            throw new NotImplementedException();
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
