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

        public static EDefCaracteristique stringToEDef(string str)
        {
            EDefCaracteristique res;
            switch (str)
            {
                case "Force":
                    res = EDefCaracteristique.Force;
                    break;
                case "Defense":
                    res = EDefCaracteristique.Defense;
                    break;
                case "Sante":
                    res = EDefCaracteristique.Sante;
                    break;
                case "Chance":
                    res = EDefCaracteristique.Chance;
                    break;
                default:
                    throw new Exception("Bad input, this def is not defined");
            }
            return res;
        }

        public static ETypeCaracteristique stringToEType(string str)
        {
            ETypeCaracteristique res;
            switch (str)
            {
                case "Jedi":
                    res = ETypeCaracteristique.Jedi;
                    break;
                case "Stade":
                    res = ETypeCaracteristique.Stade;
                    break;
                default:
                    throw new Exception("Bad input, this type is not defined");
            }
            return res;
        }
        public override int GetHashCode()
        {
            return Id;
        }

    }
}
