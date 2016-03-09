using EntitiesLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace JediService.BusinessWCF
{
    [DataContract]
    public class StadeWCF : EntityObjectWCF
    {
        private string planete;
        private int nbPlaces;
        private List<CaracteristiqueWCF> caracteristiquesWCF;

        public StadeWCF(Stade stade) : base(stade)
        {
            this.planete = stade.Planete;
            this.nbPlaces = stade.NbPlaces;
            this.caracteristiquesWCF = new List<CaracteristiqueWCF>();
            foreach (Caracteristique c in stade.Caracteristiques)
            {
                caracteristiquesWCF.Add(new CaracteristiqueWCF(c));
            }
        }

        public Stade toStade()
        {
            List<Caracteristique> carac = new List<Caracteristique>();
            foreach (CaracteristiqueWCF c in caracteristiquesWCF)
            {
                carac.Add(c.toCaracteristique());
            }
            return new Stade(Id, nbPlaces,planete,carac);
        }

        [DataMember]
        public string Planete
        {
            get { return planete; }
            set { planete = value; }
        }

        [DataMember]
        public int NbPlaces
        {
            get { return nbPlaces; }
            set { nbPlaces = value; }
        }

        [DataMember]
        public List<CaracteristiqueWCF> Caracteristiques
        {
            get { return caracteristiquesWCF; }
            set { caracteristiquesWCF = value; }
        }
       
    }
}