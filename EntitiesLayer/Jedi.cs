using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiesLayer
{
    public class Jedi : EntityObject
    {
        private List<Caracteristique> caracteristiques;
        public List<Caracteristique> Caracteristiques
        {
            get { return caracteristiques; }
        }

        private bool isSith;
        public bool IsSith
        {
            get { return isSith; }
        }

        private string nom;
        public string Nom
        {
            get { return nom; }
        }

        Jedi(int id, string _nom, bool sith, List<Caracteristique> lc) : base(id)
        {
            nom = _nom;
            isSith = sith;
            caracteristiques = lc;
        }
    }
}
