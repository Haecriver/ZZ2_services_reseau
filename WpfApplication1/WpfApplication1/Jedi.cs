using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApplication1
{
    [Serializable]
    public class Jedi
    {
        public event PropertyChangedEventHandler PropertyChanged;

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
        public Jedi(int id, string _nom, bool sith)
        {
            nom = _nom;
            isSith = sith;
        }

        public override string ToString()
        {
            string s = Nom + "\n";
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
    }
}
