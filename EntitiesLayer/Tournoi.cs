using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiesLayer
{
    public class Tournoi : EntityObject
    {
        private static int countId;
        public static int CountId
        {
            get { return countId; }
        }

        private List<Match> matchs;
        public List<Match> Matchs
        {
          get { return matchs; }
            set { matchs = value; }
        }

        private string nom;
        public string Nom
        {
            get { return nom; }
            set { nom = value; }
        }

        public Tournoi()
        {

        }
        public Tournoi(int _id, List<Match> lm, string nom) : base(_id)
        {
            if (_id > countId)
            {
                countId = _id;
            }
            matchs = lm;
            Nom = nom;
        }

        public Tournoi(List<Match> lm, string nom)
        {
            countId++;
            Id = countId;

            matchs = lm;
            Nom = nom;
        }

        public override int GetHashCode()
        {
            return Id;
        }
    }
}
