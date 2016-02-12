using EntitiesLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace JediService.BusinessWCF
{
    [DataContract]
    public class StadeWCF
    {
        private Stade stade;
        private List<CaracteristiqueWCF> caracteristiquesWCF;

        public StadeWCF(Stade stade)
        {
            this.stade = stade;
            this.caracteristiquesWCF = new List<CaracteristiqueWCF>();
            foreach (Caracteristique c in stade.Caracteristiques)
            {
                caracteristiquesWCF.Add(new CaracteristiqueWCF(c));
            }
        }

        public Stade toStade()
        {
            return stade;
        }

        [DataMember]
        public string Planete
        {
            get { return stade.Planete; }
            set { stade.Planete = value; }
        }

        [DataMember]
        public int NbPlaces
        {
            get { return stade.NbPlaces; }
            set { stade.NbPlaces = value; }
        }

        [DataMember]
        public List<CaracteristiqueWCF> Caracteristiques
        {
            get { return caracteristiquesWCF; }
            set { caracteristiquesWCF = value; }
        }
       
    }
}