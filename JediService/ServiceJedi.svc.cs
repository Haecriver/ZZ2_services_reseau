using BusinessLayer;
using EntitiesLayer;
using JediService.BusinessWCF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace JediService
{
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom de classe "Service1" dans le code, le fichier svc et le fichier de configuration.
    // REMARQUE : pour lancer le client test WCF afin de tester ce service, sélectionnez Service1.svc ou Service1.svc.cs dans l'Explorateur de solutions et démarrez le débogage.
    public class ServiceJedi : IServiceJedi
    {
        private static BusinessManager bm;

        public ServiceJedi()
        {
            bm = new BusinessManager();
        }


        public List<JediWCF> getAllJedi()
        {
            List<JediWCF> jedisWCF = new List<JediWCF>();
            List<Jedi> jedis = bm.getJedis();
            foreach (Jedi j in jedis)
            {
                jedisWCF.Add(new JediWCF(j));
            }
            return jedisWCF;
        }
        public List<MatchWCF> getAllMatch()
        {
            List<MatchWCF> matchsWCF = new List<MatchWCF>();
            List<Match> matchs = bm.getMatches();
            foreach (Match m in matchs)
            {
                matchsWCF.Add(new MatchWCF(m));
            }
            return matchsWCF;
        }
        public List<StadeWCF> getAllStade()
        {
            List<StadeWCF> stadesWCF = new List<StadeWCF>();
            List<Stade> stades = bm.getStades();
            foreach (Stade s in stades)
            {
                stadesWCF.Add(new StadeWCF(s));
            }
            return stadesWCF;
        }
        public List<TournoiWCF> getAllTournoi()
        {
            List<TournoiWCF> tournoisWCF = new List<TournoiWCF>();
            List<Tournoi> tournois = bm.getTournoi();
            foreach (Tournoi t in tournois)
            {
                tournoisWCF.Add(new TournoiWCF(t));
            }
            return tournoisWCF;
        }
        public List<CaracteristiqueWCF> getAllCaracteristique()
        {
            List<CaracteristiqueWCF> caracteristiquesWCF = new List<CaracteristiqueWCF>();
            List<Caracteristique> caracteristiques = bm.getCaracteristique();
            foreach (Caracteristique c in caracteristiques)
            {
                caracteristiquesWCF.Add(new CaracteristiqueWCF(c));
            }
            return caracteristiquesWCF;
        }
        public void addJedi(JediWCF j)
        {
            List<Jedi> jedis = bm.getJedis();
            jedis.Add(j.toJedi());
            bm.updateJedi(jedis);
        }

        public void addMatch(MatchWCF j)
        {
            throw new NotImplementedException();
        }

        public void addStade(StadeWCF j)
        {
            throw new NotImplementedException();
        }

        public void addTournoi(TournoiWCF j)
        {
            throw new NotImplementedException();
        }

        public void addCracteristique(CaracteristiqueWCF j)
        {
            throw new NotImplementedException();
        }

        public void deleteJedi(JediWCF j)
        {
            throw new NotImplementedException();
        }

        public void deleteMatch(MatchWCF j)
        {
            throw new NotImplementedException();
        }

        public void deleteStade(StadeWCF j)
        {
            throw new NotImplementedException();
        }

        public void deleteTournois(TournoiWCF j)
        {
            throw new NotImplementedException();
        }

        public void deleteCaracteristique(CaracteristiqueWCF j)
        {
            throw new NotImplementedException();
        }

        public void updateJedi(JediWCF j)
        {
            throw new NotImplementedException();
        }

        public void updateMatch(MatchWCF j)
        {
            throw new NotImplementedException();
        }

        public void updateStade(StadeWCF j)
        {
            throw new NotImplementedException();
        }

        public void updateTournois(TournoiWCF j)
        {
            throw new NotImplementedException();
        }

        public void updateCaracteristique(CaracteristiqueWCF j)
        {
            throw new NotImplementedException();
        }
    }
}
