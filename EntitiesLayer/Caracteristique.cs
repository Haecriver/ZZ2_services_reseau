using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiesLayer
{
    public enum EDefCaracteristique
    {
        Force=0,
        Defense=1,
        Sante=3,
        Chance=2
    }

    public enum ETypeCaracteristique
    {
        Jedi,
        Stade
    }
    public class Caracteristique : EntityObject
    {
        private EDefCaracteristique definition;
        public EDefCaracteristique Definition
        {
            get { return definition; }
            set { definition = value; }
        }

        private string nom;
        public string Nom
        {
            get { return nom; }
            set { nom = value; }
        }

        private ETypeCaracteristique type;
        public ETypeCaracteristique Type
        {
            get { return type; }
            set { type = value; }
        }

        private int valeur;
        public int Valeur
        {
            get { return valeur; }
            set { valeur = value; }
        }

        public Caracteristique()
        {

        }
        public Caracteristique(int id, EDefCaracteristique def, string _nom, ETypeCaracteristique _type, int _valeur) : base(id)
        {
            definition = def;
            nom = _nom;
            type = _type;
            valeur = _valeur;
        }

        public override string ToString()
        {
            return Nom + " in " + definition + " : " + valeur;
        }
    }
}
