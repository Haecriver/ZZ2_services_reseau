using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiesLayer
{
    public class Joueur : EntityObject
    {
        private string nom;

        public string Nom
        {
            get { return nom; }
            set { nom = value; }
        }

        private int score;
        public int Score
        {
            get { return score; }
            set { score = value; }
        }

        public Joueur()
        {

        }
        public Joueur(int id, string no, int sc)
            : base(id)
        {
            nom = no;
            score = sc;
        }

        public override int GetHashCode()
        {
            return Id;
        }
    }
}
