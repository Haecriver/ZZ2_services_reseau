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
        
        private Tournoi pool;
        public Tournoi Pool
        {
            get { return pool; }
            //   set { pool = value; }
        }

        Random rand;

        private List<Joueur> joueurs;
        public List<Joueur> Joueurs
        {
            get { return joueurs; }
        }

        private List<Jedi> jedis;
        public List<Jedi> Jedis
        {
            get { return jedis; }
            //   set { jedis = value; }
        }


        public BettingManager(BusinessManager businessManager, int nbJoueur)
        {
            this.businessManager = businessManager;
            rand = new Random();
            joueurs = new List<Joueur>();

            for (int i = 0; i < nbJoueur; i++)
            {
                joueurs.Add(new Joueur("player" + i, 0));
            }

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
            pool = new Tournoi(jedis_to_pool, businessManager.getStades());

        }

        public void lancerPhaseTournoi(List<int> paris, List<Jedi> jedis_paris)
        {
            foreach (Match match in pool.Matches)
            {
                PlayingMatch pMatch = new PlayingMatch(match);
                while (!pMatch.MatchOver)
                {
                    pMatch.playTurn(pMatch.automaticChoose(), pMatch.automaticChoose());
                }
                for (int i= 0;i < joueurs.Count;i++)
                {
                    if (match.JediVainqueur.Id == jedis_paris[i].Id)
                    {
                        joueurs[i].Score += paris[i];
                    }
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
            foreach(Joueur j in joueurs)
            {
                str += j.toString() + "\n";
            }

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
