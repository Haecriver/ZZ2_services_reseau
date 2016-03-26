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
        public void addJedi(JediWCF jedi)
        {
            List<Jedi> jedis = bm.getJedis();
            List<Caracteristique> listCaract = new List<Caracteristique>();
            foreach (CaracteristiqueWCF car in jedi.Caracteristiques)
            {
                listCaract.Add(car.toCaracteristique());
            }
            jedis.Add(new Jedi(jedi.Nom,jedi.IsSith,listCaract));
            bm.updateJedi(jedis);
        }

        public void addMatch(MatchWCF match)
        {
            List<Match> matches = bm.getMatches();
            matches.Add(new Match(match.Jedi1.toJedi(), match.Jedi2.toJedi(), match.PhaseTournoi, match.Stade.toStade()));
            bm.updateMatch(matches);
        }

        public void addStade(StadeWCF stade)
        {
            List<Stade> stades = bm.getStades();
            List<Caracteristique> listCaract = new List<Caracteristique>();
            foreach (CaracteristiqueWCF car in stade.Caracteristiques)
            {
                listCaract.Add(car.toCaracteristique());
            }
            stades.Add(new Stade(stade.NbPlaces,stade.Planete,listCaract));
            bm.updateStades(stades);
        }

        public void addTournoi(TournoiWCF tournoi)
        {
            List<Tournoi> tournois = bm.getTournoi();
            List<Match> listMatch = new List<Match>();
            foreach (MatchWCF match in tournoi.Matches)
            {
                listMatch.Add(match.toMatch());
            }
            tournois.Add(new Tournoi(listMatch,tournoi.Nom));
            bm.updateTournoi(tournois);
        }

        public void addCracteristique(CaracteristiqueWCF carac)
        {
            List<Caracteristique> caracts = bm.getCaracteristique();
            caracts.Add(new Caracteristique(carac.Definition,carac.Nom,carac.Type,carac.Valeur));
            bm.updateCaracteristique(caracts);
        }

        public void deleteJedi(JediWCF jedi)
        {
            List<Jedi> jedis = bm.getJedis();
            int index_to_modify = jedis.FindIndex(x => x.Id == jedi.Id);
            jedis.RemoveAt(index_to_modify);
            bm.updateJedi(jedis);
        }

        public void deleteMatch(MatchWCF match)
        {
            List<Match> matches = bm.getMatches();
            int index_to_modify = matches.FindIndex(x => x.Id == match.Id);
            matches.RemoveAt(index_to_modify);
            bm.updateMatch(matches);
        }

        public void deleteStade(StadeWCF stade)
        {
            List<Stade> stades = bm.getStades();
            int index_to_modify = stades.FindIndex(x => x.Id == stade.Id);
            stades.RemoveAt(index_to_modify);
            bm.updateStades(stades);
        }

        public void deleteTournois(TournoiWCF tournoi)
        {
            List<Tournoi> tournois = bm.getTournoi();
            int index_to_modify = tournois.FindIndex(x => x.Id == tournoi.Id);
            tournois.RemoveAt(index_to_modify);
            bm.updateTournoi(tournois);
        }

        public void deleteCaracteristique(CaracteristiqueWCF caract)
        {
            List<Caracteristique> caracts = bm.getCaracteristique();
            int index_to_modify = caracts.FindIndex(x => x.Id == caract.Id);
            caracts.RemoveAt(index_to_modify);
            bm.updateCaracteristique(caracts);
        }

        public void updateJedi(JediWCF jedi)
        {
            List<Jedi> jedis = bm.getJedis();
            int index_to_modify = jedis.FindIndex(x => x.Id == jedi.Id);
            jedis[index_to_modify] = jedi.toJedi();
            bm.updateJedi(jedis);
        }

        public void updateMatch(MatchWCF match)
        {
            List<Match> matches = bm.getMatches();
            int index_to_modify = matches.FindIndex(x => x.Id == match.Id);
            matches[index_to_modify] = match.toMatch();
            bm.updateMatch(matches);
        }

        public void updateStade(StadeWCF stade)
        {
            List<Stade> stades = bm.getStades();
            int index_to_modify = stades.FindIndex(x => x.Id == stade.Id);
            stades[index_to_modify] = stade.toStade();
            bm.updateStades(stades);
        }

        public void updateTournois(TournoiWCF tournoi)
        {
            List<Tournoi> tournois = bm.getTournoi();
            int index_to_modify = tournois.FindIndex(x => x.Id == tournoi.Id);
            tournois[index_to_modify] = tournoi.toTournoi();
            bm.updateTournoi(tournois);
        }

        public void updateCaracteristique(CaracteristiqueWCF caract)
        {
            List<Caracteristique> caracts = bm.getCaracteristique();
            int index_to_modify = caracts.FindIndex(x => x.Id == caract.Id);
            caracts[index_to_modify] = caract.toCaracteristique();
            bm.updateCaracteristique(caracts);
        }

        public TournoiWCF playTournoi(TournoiWCF tournoi)
        {
            return new TournoiWCF(bm.playTournoi(tournoi.toTournoi()));
        }
    }
}
