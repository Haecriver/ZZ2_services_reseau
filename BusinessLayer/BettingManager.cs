using System;
using System.Collections.Generic;
using System.Linq;

using EntitiesLayer;

namespace BusinessLayer
{
    public class BettingManager
    {
        BusinessManager businessManager;

        private bool end;
        public bool End
        {
            get { return end; }
            //   set { end = value; }
        }
        
        private Pool pool;
        public Pool Pool
        {
            get { return pool; }
            //   set { pool = value; }
        }

        Random rand;

        private Joueur joueur1;
        public Joueur Joueur1
        {
            get { return joueur1; }
            //   set { joueur1 = value; }
        }
        private Joueur joueur2;
        public Joueur Joueur2
        {
            get { return joueur2; }
            //   set { joueur2 = value; }
        }

        private List<Jedi> jedis;
        public List<Jedi> Jedis
        {
            get { return jedis; }
            //   set { jedis = value; }
        }


        public BettingManager(BusinessManager businessManager)
        {
            this.businessManager = businessManager;
            rand = new Random();

            joueur1 = new Joueur("player1", 0);
            joueur2 = new Joueur("player2", 0);

            List<Jedi> allJedis = businessManager.getJedis();
            List<Jedi> jedis_to_pool = new List<Jedi>();


            //Creation de la liste a mettre dans la pool
            for (int i = 0; i < 16; i++)
            {
                int index = rand.Next() % allJedis.Count;
                jedis_to_pool.Add(allJedis[index]);
                allJedis.Remove(allJedis[index]);
            }

            jedis = jedis_to_pool;
            pool = new Pool(jedis_to_pool, businessManager.getStades());

        }

        public void lancerPhaseTournoi(int parisJoueur1, Jedi jediParisJoueur1, int parisJoueur2, Jedi jediParisJoueur2)
        {
            foreach (Match match in pool.Matches)
            {
                PlayingMatch pMatch = new PlayingMatch(match);
                while (!pMatch.MatchOver)
                {
                    pMatch.playTurn(pMatch.automaticChoose(), pMatch.automaticChoose());
                }
                if (match.JediVainqueur.Id == jediParisJoueur1.Id)
                {
                    joueur1.Score += parisJoueur1;
                }
                if (match.JediVainqueur.Id == jediParisJoueur2.Id)
                {
                    joueur2.Score += parisJoueur2;
                }
            }

            //Maj bdd
            List<Match> oldMatches = businessManager.getMatches();
            oldMatches.Concat(pool.Matches);
            businessManager.updateMatch(oldMatches);
            pool = pool.nextPool();
            jedis = new List<Jedi>();
            foreach (Match match in pool.Matches)
            {
                jedis.Add(match.Jedi1);
                jedis.Add(match.Jedi2);
            }
            end = pool.PoolVide;
        }

        public string toString()
        {
            string str = "";
            str += joueur1.toString() + "\n";
            str += joueur2.toString() + "\n";

            //affichage des gagnants
            str += "------------------------\n";
            foreach(Match match in pool.Matches){
                str += match.Jedi1.Id + "\t:" + match.Jedi1.Nom + "\n";
                str += match.Jedi2.Id + "\t:" + match.Jedi2.Nom + "\n";
            }

            return str;
        }
    }
}
