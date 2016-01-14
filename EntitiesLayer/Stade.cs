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

        public Stade(int id, int nbplaces, string planet) : base(id)
        {
            nbPlaces = nbplaces;
            planete = planet;
        }
    }
}
