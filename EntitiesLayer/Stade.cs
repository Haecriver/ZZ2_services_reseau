using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiesLayer
{
    public class Stade : EntityObject
    {
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
        public Stade(int id, int nbplaces, string planet, List<Caracteristique> pcaracteristiques) : base(id)
        {
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
