using EntitiesLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace JediService.BusinessWCF
{
    [DataContract]
    public class CaracteristiqueWCF
    {
        private Caracteristique caracteristique;
        public CaracteristiqueWCF(Caracteristique caracteristique)
        {
            this.caracteristique = caracteristique;
        }

        [DataMember]
        public EDefCaracteristique Definition
        {
            get { return caracteristique.Definition; }
            set { caracteristique.Definition = value;}
        }

        [DataMember]
        public string Nom
        {
            get { return caracteristique.Nom; }
            set { caracteristique.Nom = value; }
        }

        [DataMember]
        public ETypeCaracteristique Type
        {
            get { return caracteristique.Type; }
            set { caracteristique.Type = value; }
        }
        [DataMember]
        public int Valeur
        {
            get { return caracteristique.Valeur; }
            set { caracteristique.Valeur = value; }
        }
    }
}
