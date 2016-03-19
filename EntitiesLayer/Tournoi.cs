using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiesLayer
{
    public class Tournoi : EntityObject
    {
        private static int countId=1;
        public static int CountId
        {
            get { return countId; }
        }

        private bool poolVide;
        public bool PoolVide
        {
            get { return poolVide; }
            set
            {
                poolVide = value;
            }
        }

        private string nom;
        public string Nom
        {
            get { return nom; }
            set { nom = value; }
        }

        private List<Match> matches;
        public List<Match> Matches
        {
            get { return matches; }
            set
            {
                matches = value;
            }
        }

        static private List<Stade> stades;
        static public List<Stade> Stades
        {
            get { return stades; }
            set
            {
                stades = value;
            }
        }

        private EPhaseTournoi phase;
        public EPhaseTournoi Phase
        {
            get { return phase; }
        }

        public Tournoi()
        {

        }

        public Tournoi(int _id, List<Match> lm, string nom) : base(_id)
        {
            if (_id > countId)
            {
                countId = _id;
            }
            matches = lm;
            Nom = nom;
            poolVide = false;
           
            if (matches.Count!=1 && matches.Count!=2 && matches.Count!=4 && matches.Count != 8)
            {
                throw new Exception("Nombre de matches non reglementaire : " + matches.Count);
            }
        }

        public Tournoi(List<Match> lm, string nom)
        {
            countId++;
            Id = countId;

            matches = lm;
            Nom = nom;

            if (matches.Count != 1 && matches.Count != 2 && matches.Count != 4 && matches.Count != 8)
            {
                throw new Exception("Nombre de matches non reglementaire : " + matches.Count);
            }
        }

        public Tournoi(List<Jedi> jedis, List<Stade> _stades)
        {
            countId++;
            Id = countId;
            nom = "TournoiDefault";
            stades = _stades;
            poolVide = false;
            int nb_jedis = jedis.Count;
            int matche_a_creer = jedis.Count/2;
            Random rand = new Random();

            matches = new List<Match>();
            switch (nb_jedis)
            {
                case 1:
                    poolVide = true;
                    break;

                case 2:
                    phase = EPhaseTournoi.Finale;
                    break;

                case 4:
                    phase = EPhaseTournoi.DemiFinale;
                    break;

                case 8:
                    phase = EPhaseTournoi.QuartFinale;
                    break;

                case 16:
                    phase = EPhaseTournoi.HuitiemeFinale;
                    break;

                default:
                    throw new Exception("Nombre de jedi dans le pool incorrecte : "+jedis.Count);
            }
            for (int i = 0; i < matche_a_creer && !poolVide; i++)
            {
                matches.Add(new Match(jedis[i * 2], jedis[i * 2 + 1], phase, stades[rand.Next() % stades.Count]));
            }
        }

        public Tournoi nextPool()
        {
            List<Jedi> gagnants= new List<Jedi>();
            foreach (Match match in matches)
            {
                gagnants.Add(match.JediVainqueur);
            }
            if (stades == null)
            {
                throw new Exception("Stades n'est pas defini");
            }
            return new Tournoi(gagnants, stades);
        }

        public override int GetHashCode()
        {
            return Id;
        }
    }
}
