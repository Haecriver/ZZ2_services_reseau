using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace EntitiesLayer
{
    [Serializable]
    public class Jedi : EntityObject
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private static int countId=1;
        public static int CountId
        {
            get { return countId; }
        }

        private List<Caracteristique> caracteristiques;
        public List<Caracteristique> Caracteristiques
        {
            get { return caracteristiques; }
            set { 
                caracteristiques = value;
            }
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
            set {
                nom = value;
            }
        }

        public Jedi()
        {

        }

        public Jedi(string _nom, bool sith, List<Caracteristique> lc)
        {
            countId++;
            Id = countId;

            nom = _nom;
            isSith = sith;
            caracteristiques = lc;
        }


        public Jedi(int _id, string _nom, bool sith, List<Caracteristique> lc)
            : base(_id)
        {
            if (_id > countId)
        {
                countId = _id;
            }
            nom = _nom;
            isSith = sith;
            caracteristiques = lc;
        }

        public override string ToString ()
        {
            string s = Nom + "\n";
            if (caracteristiques != null)
            {
                IEnumerable<string> results = from caracteristic in Caracteristiques select caracteristic.ToString();
                foreach (string el in results)
                {
                    s += el + "\n";
                }
            }
            return s;
        }

        private String image;
        public String Image 
        {
            get
            {
                return image;
            }
            set
            {
                image = value;
            }
        }

        public override int GetHashCode()
        {
            return Id;
        }
    }
}
