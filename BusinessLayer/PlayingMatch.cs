using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntitiesLayer;
using System.Linq;


namespace BusinessLayer
{
    /*********************************************************************/
    /* Regle du jeu :                                                    */
    /* Au debut de chaque tours, le joueur choisit un type de            */
    /* caracteristique avec lequel jouer.                                */
    /*                                                                   */
    /* Le cumule des points des caracteristiques de ce type donne le     */
    /* score du tour avec ce joueur (caract Jedi et Stade comprises)     */
    /*                                                                   */
    /* Quand les caract des deux joueurs sont différentes, un            */
    /* mutliplicateur agit sur une des deux caracts selon cette regle :  */
    /*     Force>Defense; Defense>Chance; Chance>Force                   */
    /*                                                                   */
    /* On soustrait aux pv du joueur qui a le plus petit score la        */
    /* différence                                                        */
    /*********************************************************************/

    enum RepShiFuMi
    {
        Egalite,
        J1Gagnant,
        J2Gagnant,
        Null
    }
    
    class PlayingMatch
    {
        // Base de pv des Jedi
        public static readonly int baseHP = 30;

        // Mutiplicateur Pierre/Feuille/Ciseau
        private const int multiplicator = 5;

        private static Random rand;

        // Caracteritiques du match
        Match match;

        private int caractForceStade;
        private int caractDefenseStade;
        private int caractChanceStade;

        private PlayingJedi pJedi1;
        private PlayingJedi pJedi2;

        // Valeur calculees du TOUR courant
        bool matchOver = false;
        Jedi looserJedi;
        Jedi winnerJedi;
        int dammageInfliged;

        public PlayingMatch(Match match)
        {
            if (match.IdJediVainqueur != -1)
            {
                throw new Exception("Error : Match already run !");
            }
            else
            {
                //Pour les jeux automatique
                rand = new Random(42);

                this.match = match;
                pJedi1 = new PlayingJedi(match.Jedi1);
                pJedi2 = new PlayingJedi(match.Jedi2);

                List<Caracteristique> caractStade = match.Stade.Caracteristiques;

                //Calcul de la force
                caractForceStade = (from element in caractStade
                                    where element.Definition == EDefCaracteristique.Force
                                    select element.Valeur).Sum();


                //Calcul de la defense
                caractDefenseStade = (from element in caractStade
                                      where element.Definition == EDefCaracteristique.Defense
                                      select element.Valeur).Sum();

                //Calcul de la chance
                caractChanceStade = (from element in caractStade
                                     where element.Definition == EDefCaracteristique.Chance
                                     select element.Valeur).Sum();
            }
        }

        // Le vainqueur est directement changé dans Match
        public void playTurn(EDefCaracteristique choosenCaract1, EDefCaracteristique choosenCaract2)
        {
            

            if (!MatchOver)
            {
                Jedi1.ChoosenCaract = choosenCaract1;
                Jedi2.ChoosenCaract = choosenCaract2;

                int scoreJ1 = 0;
                int scoreJ2 = 0;

                // 1 pour J1, 2 pour J2, 0 sinon
                RepShiFuMi vainqueurShiFuMi = 0;

                //Calcul de la valeur de score
                try
                {
                    scoreJ1 = computeScore(Jedi1);
                    scoreJ2 = computeScore(Jedi2);
                }catch (Exception e)
                {
                    throw e;
                }

                // Calcul du Shi-Fu-Mi
                try
                {
                    vainqueurShiFuMi = shiFuMi(Jedi1.ChoosenCaract, Jedi2.ChoosenCaract);
                }catch (Exception e)
                {
                    throw e;
                }

                // Calcul final du score
                if (vainqueurShiFuMi == RepShiFuMi.J1Gagnant)
                {
                    scoreJ1 *= multiplicator;
                }
                if (vainqueurShiFuMi == RepShiFuMi.J2Gagnant)
                {
                    scoreJ2 *= multiplicator;
                }

                // Calcul vainqueur

                // Par defaut J1 GAGNE et J2 PERD
                dammageInfliged = 0;
                winnerJedi = match.Jedi1;
                looserJedi = match.Jedi2;

                if (scoreJ1 > scoreJ2)
                {
                    dammageInfliged = scoreJ1 - scoreJ2;
                    winnerJedi = match.Jedi1;
                    looserJedi = match.Jedi2;

                    Jedi2.HpJedi -= dammageInfliged;
                }
                else if (scoreJ1 < scoreJ2)
                {
                    dammageInfliged = scoreJ2 - scoreJ1;
                    looserJedi = match.Jedi1;
                    winnerJedi = match.Jedi2;

                    Jedi1.HpJedi -= dammageInfliged;
                }

                //Le dernier vainqueur du match sera donc le vainqueur
                if (Jedi1.HpJedi <= 0 || Jedi2.HpJedi <= 0)
                {
                    matchOver = true;
                    match.IdJediVainqueur = winnerJedi.Id;
                }

            }
            else
            {
                throw new Exception("Match already over !");
            }
        }

        public EDefCaracteristique automaticChoose()
        {
            return (EDefCaracteristique)(rand.Next()%3);
        }


        private int computeScore(PlayingJedi joueur)
        {
            int score=0;
            switch (joueur.ChoosenCaract)
            {
                case EDefCaracteristique.Force:
                    score += joueur.CaractForce;
                    score += caractForceStade;
                    break;

                case EDefCaracteristique.Defense:
                    score += joueur.CaractDefense;
                    score += caractDefenseStade;
                    break;

                case EDefCaracteristique.Chance:
                    score += joueur.CaractChance;
                    score += caractChanceStade;
                    break;

                case EDefCaracteristique.Sante:
                    throw new Exception("Error : \"Caracteristique Sante\" choosen !");
            }
            return score;
        }

        private RepShiFuMi shiFuMi(EDefCaracteristique choosenCaract1, EDefCaracteristique choosenCaract2)
        {
            RepShiFuMi vainqueurShiFuMi = RepShiFuMi.Null;
            if (choosenCaract1 == choosenCaract2)
            {
                vainqueurShiFuMi = RepShiFuMi.Egalite;
            }
            else
            {
                switch (choosenCaract1)
                {
                    case EDefCaracteristique.Force:
                        vainqueurShiFuMi = RepShiFuMi.J1Gagnant;
                        if (choosenCaract2 == EDefCaracteristique.Chance)
                        {
                            vainqueurShiFuMi = RepShiFuMi.J2Gagnant;
                        }
                        break;

                    case EDefCaracteristique.Chance:
                        vainqueurShiFuMi = RepShiFuMi.J1Gagnant;
                        if (choosenCaract2 == EDefCaracteristique.Defense)
                        {
                            vainqueurShiFuMi = RepShiFuMi.J2Gagnant;
                        }
                        break;

                    case EDefCaracteristique.Defense:
                        vainqueurShiFuMi = RepShiFuMi.J1Gagnant;
                        if (choosenCaract2 == EDefCaracteristique.Force)
                        {
                            vainqueurShiFuMi = RepShiFuMi.J2Gagnant;
                        }
                        break;

                    case EDefCaracteristique.Sante:
                        throw new Exception("Error : \"Caracteristique Sante\" choosen !");
                }
            }
            return vainqueurShiFuMi;
        }



        public bool MatchOver
        {
            get { return matchOver; }
        }
        public Jedi WinnerJedi
        {
            get { return winnerJedi; }
        }
        public Jedi LooserJedi
        {
            get { return looserJedi; }

        }
        public int DammageInfliged
        {
            get { return dammageInfliged; }
        }

        internal PlayingJedi Jedi1
        {
            get
            {
                return pJedi1;
            }
        }

        internal PlayingJedi Jedi2
        {
            get
            {
                return pJedi2;
            }
        }
    }
}
