using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using EntitiesLayer;

namespace DataAccessLayer
{
    public enum _typeBDD {
        SQL,
        ORACLE
    }
    public class DalManager
    {
        private static DalManager instance;
        private static readonly object padlock = new object();

        _typeBDD typeBDD;

        private IDAL usingDal;

        public DalManager()
        {
            typeBDD = _typeBDD.SQL;
            if(typeBDD==_typeBDD.SQL){
                usingDal = new DALSqlServer();
            }
        }

        public static DalManager Instance{
            get{
                if (instance == null)
                {
                    lock (padlock)
                    {
                        if (instance == null)
                        {
                            instance = new DalManager();
                        }
                    }
                }
                return instance;
            }
        }

        public Jedi testBDD(){ return usingDal.testBDD();}
        public List<Jedi> getAllJedi(){return usingDal.getAllJedi();}
        public List<Match> getAllMatch() { return usingDal.getAllMatch(); }
        public List<Stade> getAllStade() { return usingDal.getAllStade(); }
        public List<Caracteristique> getAllCaracteristic() { return usingDal.getAllCaracteristic(); }
        public List<Utilisateur> getAllUtilisateur() { return usingDal.getAllUtilisateur(); }


        public Utilisateur getUtilisateurByLogin(string login)
        {
            try
            {
                return usingDal.getUtilisateurByLogin(login);
            }
            catch (KeyNotFoundException)
            {
                return null;
            }

        }

        public void updateJedi(List<Jedi> jedis) { usingDal.updateJedi(jedis); }
        public void updateMatch(List<Match> matches) { usingDal.updateMatch(matches); }
        public void updateStade(List<Stade> stades) { usingDal.updateStade(stades); }
        public void updateCaracteristique(List<Caracteristique> caracteristiques) { usingDal.updateCaracteristique(caracteristiques); }
        public void updateUtilisateur(List<Utilisateur> utilisateurs) { usingDal.updateUtilisateur(utilisateurs); }
    }
}
