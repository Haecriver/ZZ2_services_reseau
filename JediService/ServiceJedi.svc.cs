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
        public static BusinessManager bm;
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

    }
}
