using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiesLayer
{
    public enum EPhaseTournoi
    {
        QuartFinale,
        HuitiemeFinale,
        DemiFinale,
        Finale
    }
    public class Match : EntityObject
    {
        private Jedi jediVainqueur;
        public Jedi JediVainqueur
        {
            get { return jediVainqueur; }
            set { jediVainqueur = value; }
        }

        private Jedi jedi1;
        public Jedi Jedi1
        {
            get { return jedi1; }
            set { jedi1 = value; }
        }

        private Jedi jedi2;
        public Jedi Jedi2
        {
            get { return jedi2; }
            set { jedi2 = value; }
        }

        private EPhaseTournoi phaseTournoi;
        public EPhaseTournoi PhaseTournoi
        {
            get { return phaseTournoi; }
            set { phaseTournoi = value; }
        }

        private Stade stade;
        public Stade Stade
        {
            get { return stade; }
            set { stade = value; }
        }

        public Match()
        {

        }

        public Match(int pId, Jedi pJedi1, Jedi pJedi2, EPhaseTournoi pPhaseTournoi, Stade pStade) : base(pId)
        {
            JediVainqueur = null;
            Jedi1 = pJedi1;
            Jedi2 = pJedi2;
            PhaseTournoi = pPhaseTournoi;
            Stade = pStade;
        }

        public override string ToString()
        {
            string s = phaseTournoi + "\n" + jedi1.Nom + " vs " + Jedi2.Nom + " sur " + stade.Planete + "\n";
            if (jediVainqueur != null)
                s += "Vainqueur : " + jediVainqueur.ToString();
            else
                s += "Le match n'a pas encore été joué";
            return s;
        }

        public static EPhaseTournoi stringToEPhase(string str)
        {
            EPhaseTournoi res;
            switch (str)
            {
                case "HuitiemeFinale":
                    res = EPhaseTournoi.HuitiemeFinale;
                    break;
                case "QuartFinale":
                    res = EPhaseTournoi.QuartFinale;
                    break;
                case "DemiFinale":
                    res = EPhaseTournoi.DemiFinale;
                    break;
                case "Finale":
                    res = EPhaseTournoi.Finale;
                    break;
                default:
                    throw new Exception("Bad input, this phase is not defined");
            }
            return res;
        }
        public override int GetHashCode()
        {
            return Id;
        }
    }
}
