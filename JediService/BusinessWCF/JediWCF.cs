using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using EntitiesLayer;
using System.Runtime.Serialization;

namespace JediService.BusinessWCF
{
    [DataContract]
    public class JediWCF : EntityObjectWCF
    {
        private string nom;
        private bool isSith;
        private List<CaracteristiqueWCF> caracteristiquesWCF;

        public JediWCF(Jedi jedi) : base(jedi)
        {
            this.nom = jedi.Nom;
            this.isSith = jedi.IsSith;
            this.caracteristiquesWCF = new List<CaracteristiqueWCF>();
            foreach (Caracteristique c in jedi.Caracteristiques)
            {
                caracteristiquesWCF.Add(new CaracteristiqueWCF(c));
            }
        }

        public Jedi toJedi()
        {
            List<Caracteristique> carac = new List<Caracteristique>();
            foreach (CaracteristiqueWCF c in caracteristiquesWCF)
            {
                carac.Add(c.toCaracteristique());
            }

            return new Jedi(nom,isSith,carac);
        }

        [DataMember]
        public string Nom
        {
            get { return nom; }
            set { nom = value; }
        }

        [DataMember]
        public bool IsSith
        {
            get { return isSith; }
            set
            { isSith = value; }
        }

        [DataMember]
        public List<CaracteristiqueWCF> Caracteristiques
        {
            get { return caracteristiquesWCF; }
            set { caracteristiquesWCF = value; }
        }

    }
}