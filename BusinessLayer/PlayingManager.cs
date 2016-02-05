using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using EntitiesLayer;

namespace BusinessLayer
{
    public class PlayingManager
    {
        BusinessManager businessManager;

        private string statLastTurn;
        public string StatLastTurn
        {
            get { return statLastTurn; }
            //   set { statLastTurn = value; }
        }

        private PlayingMatch playerPlayingMatch;
        public PlayingMatch PlayerPlayingMatch
        {
            get { return playerPlayingMatch; }
            //   set { playerPlayingMatch = value; }
        }

        private bool end;
        public bool End
        {
            get { return end; }
            //   set { end = value; }
        }

        private bool win;
        public bool Win
        {
            get { return win; }
            //   set { win = value; }
        }

        private Jedi playerJedi;
        public Jedi PlayerJedi
        {
            get { return playerJedi; }
            //   set { playerJedi = value; }
        }

        private Pool pool;
        public Pool Pool
        {
            get { return pool; }
            //   set { pool = value; }
        }

        public PlayingManager(BusinessManager businessManager)
        {
            this.businessManager = businessManager;
        }
        
        public void LancerMatch(Jedi jedi)
        {
            LancerMatch(jedi, 8);
        }

        public void LancerMatch(Jedi jedi, int nbJediDepart)
        {
            end = false;
            win = false;
            playerJedi = jedi;
            
            List<Jedi> jedis = businessManager.getJedis();
            Jedi jediToRemove = jedis.Find(x => x.Id == jedi.Id);
            jedis.Remove(jediToRemove);
            List<Jedi> jedis_to_pool = new List<Jedi>();
            jedis_to_pool.Add(jedi);

            Random rand = new Random();

            //Creation de la liste a mettre dans la pool
            for (int i = 0; i < nbJediDepart-1; i++)
            {
                int index = rand.Next() % jedis.Count;
                jedis_to_pool.Add(jedis[index]);
                jedis.Remove(jedis[index]);
            }

            //Premiere pool a jouer
            //Le premier match de la list sera celui du joueur
            pool = new Pool(jedis_to_pool, businessManager.getStades());

            //On joue tout les autres matches
            foreach (Match match in pool.Matches)
            {
                PlayingMatch pMatch = new PlayingMatch(match);
                while (!pMatch.MatchOver)
                {
                    pMatch.playTurn(pMatch.automaticChoose(), pMatch.automaticChoose());
                }
            }
            pool.Matches[0].JediVainqueur = null;
            playerPlayingMatch = new PlayingMatch(pool.Matches[0]);
        }

        public void utiliserForce()
        {
            playerPlayingMatch.playTurn(EDefCaracteristique.Force,playerPlayingMatch.automaticChoose());
            checkContinue();
        }

        public void utiliserChance()
        {
            playerPlayingMatch.playTurn(EDefCaracteristique.Chance, playerPlayingMatch.automaticChoose());
            checkContinue();
        }

        public void utiliserDefense()
        {
            playerPlayingMatch.playTurn(EDefCaracteristique.Defense, playerPlayingMatch.automaticChoose());
            checkContinue();
        }

        private void checkContinue()
        {
            statLastTurn = turn();
            if (playerPlayingMatch.MatchOver)
            {
                if (playerPlayingMatch.Match.JediVainqueur.Id != playerJedi.Id)
                {
                    //player loose
                    end = true;
                    win = false;
                }else{
                    //Maj bdd
                    List<Match> oldMatches = businessManager.getMatches();
                    oldMatches.Concat(pool.Matches);
                    businessManager.updateMatch(oldMatches);
                    pool = pool.nextPool();
                    foreach (Match match in pool.Matches)
                    {
                        PlayingMatch pMatch = new PlayingMatch(match);
                        while (!pMatch.MatchOver)
                        {
                            pMatch.playTurn(pMatch.automaticChoose(), pMatch.automaticChoose());
                        }
                    }
                    if (pool.PoolVide)
                    {
                        end = true;
                        win = true;
                    }
                    else
                    {
                        pool.Matches[0].JediVainqueur = null;
                        playerPlayingMatch = new PlayingMatch(pool.Matches[0]);
                    }
                }
            }
        }

        public string title()
        {
            string str = "";
            Match match = playerPlayingMatch.Match;

            str += "Match on " + match.Stade.Planete + "\n";
            str += match.Stade.ToString() + "\n";
            str += "Phase : " + match.PhaseTournoi + "\n";

            str += match.Jedi1.Nom + " contre " + match.Jedi2.Nom + "\n";
            str += match.Jedi1.ToString() + "\n";
            str += match.Jedi2.ToString() + "\n";
            return str;
        }

        public string turn()
        {
            string str = "";
            Match match = playerPlayingMatch.Match;
            // str +="Tour {0}", i);
            str += match.Jedi1.Nom + " utilise : " + playerPlayingMatch.PJedi1.ChosenCaract.ToString() + "\n";
            str += match.Jedi2.Nom + " utilise : " + playerPlayingMatch.PJedi2.ChosenCaract.ToString() + "\n";
            str += playerPlayingMatch.WinnerJedi.Nom + " inflige " + playerPlayingMatch.DamageInflicted + " degats a " + playerPlayingMatch.LooserJedi.Nom + "\n";
            str += "Point de vie restant a " + match.Jedi1.Nom + " : " + playerPlayingMatch.PJedi1.HpJedi + "\n";
            str += "Point de vie restant a " + match.Jedi2.Nom + " : " + playerPlayingMatch.PJedi2.HpJedi + "\n";

            return str;
        }

        
        public string toString()
        {
            return title() + turn();
        }
    }
}
