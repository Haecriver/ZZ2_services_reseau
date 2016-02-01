using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiesLayer
{
    class Pool
    {
        private List<Match> matches;
        public List<Match> Matches
        {
            get { return matches; }
            set
            {
                matches = value;
            }
        }

        private List<Stade> stades;
        public List<Stade> Stades
        {
            get { return stades; }
            set
            {
                stades = value;
            }
        }

        private int last_id;
        public int Last_id
        {
            get { return last_id; }
        }

        private EPhaseTournoi phase;
        public EPhaseTournoi Phase
        {
            get { return phase; }
        }

        public Pool(List<Jedi> jedis, List<Stade> _stades, int _last_id)
        {
            stades = _stades;
            last_id = _last_id;

            int id = last_id;
            int nb_jedis = jedis.Count;
            int matche_a_creer = jedis.Count/2;
            Random rand = new Random();

            matches = new List<Match>();
            switch (nb_jedis)
            {
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
                    throw new Exception("Nombre de jedi dans le pool incorrecte");
            }
            for (int i = 0; i < matche_a_creer; i++)
            {
                matches.Add(new Match(id + i, jedis[i * 2], jedis[i * 2 + 1], phase, stades[rand.Next() % stades.Count]));
            }
            last_id += matche_a_creer;
        }

        public Pool nextPool()
        {
            List<Jedi> gagnants= new List<Jedi>();
            foreach (Match match in matches)
            {
                gagnants.Add(match.JediVainqueur);
            }
            return new Pool(gagnants, stades, last_id);
        }
    }
}
