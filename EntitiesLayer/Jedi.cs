using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiesLayer
{
    [Serializable]
    public class Jedi : EntityObject
    {
        private List<Caracteristique> caracteristiques;
        public List<Caracteristique> Caracteristiques
        {
            get { return caracteristiques; }
            set { caracteristiques = value; }
        }        

        private bool isSith;
        public bool IsSith
        {
            get { return isSith; }
            set { isSith = value; }
        }

        private string nom;
        public string Nom
        {
            get { return nom; }
            set { nom = value; }
        }

        public Jedi()
        {

        }
        public Jedi(int id, string _nom, bool sith, List<Caracteristique> lc)
            : base(id)
        {
            nom = _nom;
            isSith = sith;
            caracteristiques = lc;
        }

        public override string ToString ()
        {
            string s=Nom + "\n";
            IEnumerable<string> results = from caracteristic in Caracteristiques select caracteristic.ToString();
            foreach(string el in results)
            {
                s += el + "\n";
            }
            return s;
        }
    }
}
