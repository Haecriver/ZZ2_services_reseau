using EntitiesLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace JediService.BusinessWCF
{
    [DataContract]
    public class CaracteristiqueWCF : EntityObjectWCF
    {
        private EDefCaracteristique def;
        private string nom;
        private ETypeCaracteristique type;
        private int valeur;
       
        public Caracteristique toCaracteristique()
        {
            return new Caracteristique(Id, def, nom, type, valeur);
        }

        public CaracteristiqueWCF(Caracteristique caracteristique) : base(caracteristique)
        {
            this.def = caracteristique.Definition;
            this.nom = caracteristique.Nom;
            this.type = caracteristique.Type;
            this.valeur = caracteristique.Valeur;
        }

        [DataMember]
        public EDefCaracteristique Definition
        {
            get { return def; }
            set { def = value; }
        }

        [DataMember]
        public string Nom
        {
            get { return nom; }
            set 
            { nom = value; }
        }

        [DataMember]
        public ETypeCaracteristique Type
        {
            get { return type; }
            set { type = value; }
        }
        [DataMember]
        public int Valeur
        {
            get { return valeur; }
            set { valeur = value; }
        }

    }
}
