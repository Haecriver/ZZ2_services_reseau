using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApplication1
{
    public enum EPhaseTournoi
    {
        QuartFinale,
        HuitiemeFinale,
        DemiFinale,
        Finale
    }
    public class Match
    {
        private int idJediVainqueur;
        public int IdJediVainqueur
        {
            get { return idJediVainqueur; }
            set { idJediVainqueur = value; }
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

        private String stade;
        public String Stade
        {
            get { return stade; }
            set { stade = value; }
        }

        public Match()
        {

        }

        public Match(int pId, Jedi pJedi1, Jedi pJedi2, EPhaseTournoi pPhaseTournoi, String pStade)
        {
            idJediVainqueur = -1;
            Jedi1 = pJedi1;
            Jedi2 = pJedi2;
            PhaseTournoi = pPhaseTournoi;
            Stade = pStade;
        }
    }
}
