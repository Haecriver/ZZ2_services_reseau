using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiesLayer
{
    public enum EDefCaracteristique
    {
        Force,
        Defense,
        Sante,
        Chance
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
        }

        private string nom;
        public string Nom
        {
            get { return nom; }
        }

        private ETypeCaracteristique type;
        public ETypeCaracteristique Type
        {
            get { return type; }
        }

        private int valeur;
        public int Valeur
        {
            get { return valeur; }
        }

        public Caracteristique(int id, EDefCaracteristique def, string _nom, ETypeCaracteristique _type, int _valeur) : base(id)
        {
            definition = def;
            nom = _nom;
            type = _type;
            valeur = _valeur;
        }
    }
}
