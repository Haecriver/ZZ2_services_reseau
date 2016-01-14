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
        private int idJediVainqueur;
        public int IdJediVainqueur
        {
            get { return idJediVainqueur; }
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

        public Match(int id, Jedi j1, Jedi j2) : base(id)
        {
            throw new NotImplementedException();
        }
    }
}
