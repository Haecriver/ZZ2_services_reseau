using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using EntitiesLayer;
using System.Runtime.Serialization;

namespace JediService.BusinessWCF
{
    [DataContract]
    public class JediWCF
    {
        private Jedi jedi;
        private List<CaracteristiqueWCF> caracteristiquesWCF;

        public JediWCF(Jedi jedi)
        {
            this.jedi = jedi;
            this.caracteristiquesWCF = new List<CaracteristiqueWCF>();
            foreach (Caracteristique c in jedi.Caracteristiques)
            {
                caracteristiquesWCF.Add(new CaracteristiqueWCF(c));
            }
        }

        public Jedi toJedi()
        {
            return jedi;
        }

        [DataMember]
        public string Nom
        {
            get { return jedi.Nom; }
            set { jedi.Nom = value; }
        }

        [DataMember]
        public bool IsSith
        {
            get { return jedi.IsSith; }
            set { jedi.IsSith = value; }
        }

        [DataMember]
        public List<CaracteristiqueWCF> Caracteristiques
        {
            get { return caracteristiquesWCF; }
            set { caracteristiquesWCF = value; }
        }

    }
}