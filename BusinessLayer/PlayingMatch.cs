using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntitiesLayer;


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

    public class PlayingMatch
    {
        // Base de pv des Jedi
        public static readonly int baseHP = 30;

        // Mutiplicateur Pierre/Feuille/Ciseau
        private const int multiplicator = 5;

        private static Random rand;

        // Caracteritiques du match
        Match match;
        public Match Match
        {
            get { return match; }
            set { match = value; }
        }

        private int caractForceStade;
        public int CaractForceStade
        {
            get { return caractForceStade; }
            set { caractForceStade = value; }
        }

        private int caractDefenseStade;
        public int CaractDefenseStade
        {
            get { return caractDefenseStade; }
            set { caractDefenseStade = value; }
        }

        private int caractChanceStade;
        public int CaractChanceStade
        {
            get { return caractChanceStade; }
            set { caractChanceStade = value; }
        }

        private int caractSanteStade;
        public int CaractSanteStade
        {
            get { return caractSanteStade; }
            set { caractSanteStade = value; }
        }


        private PlayingJedi pJedi1;
        public PlayingJedi PJedi1
        {
            get { return pJedi1; }
            set { pJedi1 = value; }
        }

        private PlayingJedi pJedi2;
        public PlayingJedi PJedi2
        {
            get { return pJedi2; }
            set { pJedi2 = value; }
        }

        // Valeur calculees du TOUR courant
        private bool matchOver;

        public bool MatchOver
        {
            get { return matchOver; }
            set { matchOver = value; }
        }


        private Jedi looserJedi;
        public Jedi LooserJedi
        {
            get { return looserJedi; }
            set { looserJedi = value; }
        }

        private Jedi winnerJedi;

        public Jedi WinnerJedi
        {
            get { return winnerJedi; }
            set { winnerJedi = value; }
        }


        private int damageInflicted;
        public int DamageInflicted
        {
            get { return damageInflicted; }
            set { damageInflicted = value; }
        }


        public PlayingMatch(Match match)
        {
            matchOver = false;
            if (match.JediVainqueur != null)
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

                //Calcul de la santé
                caractSanteStade = (from element in caractStade
                                    where element.Definition == EDefCaracteristique.Sante
                                    select element.Valeur).Sum();

                //Ajustement de santé des deux jedis
                pJedi1.HpJedi += caractSanteStade;
                pJedi2.HpJedi += caractSanteStade;
            }
        }

        // Le vainqueur est directement changé dans Match
        public void playTurn(EDefCaracteristique chosenCaract1, EDefCaracteristique chosenCaract2)
        {


            if (!MatchOver)
            {
                pJedi1.ChosenCaract = chosenCaract1;
                pJedi2.ChosenCaract = chosenCaract2;

                int scoreJ1 = 0;
                int scoreJ2 = 0;

                // 1 pour J1, 2 pour J2, 0 sinon
                RepShiFuMi vainqueurShiFuMi = 0;

                //Calcul de la valeur de score
                try
                {
                    scoreJ1 = computeScore(pJedi1);
                    scoreJ2 = computeScore(pJedi2);
                }
                catch (Exception e)
                {
                    throw e;
                }

                // Calcul du Shi-Fu-Mi
                try
                {
                    vainqueurShiFuMi = shiFuMi(pJedi1.ChosenCaract, pJedi2.ChosenCaract);
                }
                catch (Exception e)
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
                damageInflicted = 0;
                winnerJedi = match.Jedi1;
                looserJedi = match.Jedi2;

                if (scoreJ1 > scoreJ2)
                {
                    damageInflicted = scoreJ1 - scoreJ2;
                    winnerJedi = match.Jedi1;
                    looserJedi = match.Jedi2;

                    pJedi2.HpJedi -= damageInflicted;
                }
                else if (scoreJ1 < scoreJ2)
                {
                    damageInflicted = scoreJ2 - scoreJ1;
                    looserJedi = match.Jedi1;
                    winnerJedi = match.Jedi2;

                    pJedi1.HpJedi -= damageInflicted;
                }

                //Le dernier vainqueur du match sera donc le vainqueur
                if (pJedi1.HpJedi <= 0 || pJedi2.HpJedi <= 0)
                {
                    matchOver = true;
                    match.JediVainqueur = winnerJedi;
                }

            }
            else
            {
                throw new Exception("Match already over !");
            }
        }

        public EDefCaracteristique automaticChoose()
        {
            return (EDefCaracteristique)(rand.Next() % 3);
        }


        private int computeScore(PlayingJedi joueur)
        {
            int score = 0;
            switch (joueur.ChosenCaract)
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
                    throw new Exception("Error : \"Caracteristique Sante\" chosen !");
            }
            return score;
        }

        private RepShiFuMi shiFuMi(EDefCaracteristique chosenCaract1, EDefCaracteristique chosenCaract2)
        {
            RepShiFuMi vainqueurShiFuMi = RepShiFuMi.Null;
            if (chosenCaract1 == chosenCaract2)
            {
                vainqueurShiFuMi = RepShiFuMi.Egalite;
            }
            else
            {
                switch (chosenCaract1)
                {
                    case EDefCaracteristique.Force:
                        vainqueurShiFuMi = RepShiFuMi.J1Gagnant;
                        if (chosenCaract2 == EDefCaracteristique.Chance)
                        {
                            vainqueurShiFuMi = RepShiFuMi.J2Gagnant;
                        }
                        break;

                    case EDefCaracteristique.Chance:
                        vainqueurShiFuMi = RepShiFuMi.J1Gagnant;
                        if (chosenCaract2 == EDefCaracteristique.Defense)
                        {
                            vainqueurShiFuMi = RepShiFuMi.J2Gagnant;
                        }
                        break;

                    case EDefCaracteristique.Defense:
                        vainqueurShiFuMi = RepShiFuMi.J1Gagnant;
                        if (chosenCaract2 == EDefCaracteristique.Force)
                        {
                            vainqueurShiFuMi = RepShiFuMi.J2Gagnant;
                        }
                        break;

                    case EDefCaracteristique.Sante:
                        throw new Exception("Error : \"Caracteristique Sante\" chosen !");
                }
            }
            return vainqueurShiFuMi;
        }
    }
}
