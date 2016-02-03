using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiesLayer
{
    public class Joueur : EntityObject
    {
        private static int countId;
        public static int CountId
        {
            get { return countId; }
        }

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
        public Joueur(int _id, string no, int sc)
            : base(_id)
        {
            if (_id > countId)
            {
                countId = _id;
            }
            nom = no;
            score = sc;
        }

        public Joueur(string no, int sc)
        {
            countId++;
            Id = countId;

            nom = no;
            score = sc;
        }

        public override int GetHashCode()
        {
            return Id;
        }
    }
}
