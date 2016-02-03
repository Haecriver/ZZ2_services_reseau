using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiesLayer
{
    public class Stade : EntityObject
    {
        private static int countId;
        public static int CountId
        {
            get { return countId; }
        }

        private List<Caracteristique> caracteristiques;
        public List<Caracteristique> Caracteristiques
        {
            get { return caracteristiques; }
            set { caracteristiques = value; }
        }

        private int nbPlaces;
        public int NbPlaces
        {
            get { return nbPlaces; }
            set { nbPlaces = value; }
        }

        private string planete;
        public string Planete
        {
            get { return planete; }
            set { planete = value; }
        }

        public Stade()
        {

        }
        public Stade(int _id, int nbplaces, string planet, List<Caracteristique> pcaracteristiques) : base(_id)
        {
            if (_id > countId)
            {
                countId = _id;
            }
            caracteristiques = pcaracteristiques;
            nbPlaces = nbplaces;
            planete = planet;
        }

        public Stade(int nbplaces, string planet, List<Caracteristique> pcaracteristiques)
        {
            countId++;
            Id = countId;

            caracteristiques = pcaracteristiques;
            nbPlaces = nbplaces;
            planete = planet;
        }

        public override string ToString()
        {
            string s = Planete + "\n";
            IEnumerable<string> results = from caracteristic in Caracteristiques select caracteristic.ToString();
            foreach (string el in results)
            {
                s += el + "\n";
            }
            return s;
        }

        public override int GetHashCode()
        {
            return Id;
        }
    }
}
