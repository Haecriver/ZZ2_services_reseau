using EntitiesLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace JediService.BusinessWCF
{
    [DataContract]
    public class TournoiWCF
    {
        private Tournoi tournoi;
        private List<MatchWCF> matchesWCF;

        public TournoiWCF(Tournoi tournoi)
        {
            this.tournoi = tournoi;
            matchesWCF = new List<MatchWCF>();
            foreach (Match m in tournoi.Matchs)
	        {
                matchesWCF.Add(new MatchWCF(m));
	        }
        }

        [DataMember]
        public String Nom
        {
            get { return tournoi.Nom; }
            set { tournoi.Nom = value; }
        }

        [DataMember]
        public List<MatchWCF> Matches
        {
            get { return matchesWCF; }
            set { matchesWCF = value; }
        }
    }
}