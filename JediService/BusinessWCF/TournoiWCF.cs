﻿using EntitiesLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace JediService.BusinessWCF
{
    [DataContract]
    public class TournoiWCF : EntityObjectWCF
    {
        private string nom;
        private List<MatchWCF> matchesWCF;

        public TournoiWCF(Tournoi tournoi) : base(tournoi)
        {
            this.nom = tournoi.Nom;
            matchesWCF = new List<MatchWCF>();
            foreach (Match m in tournoi.Matches)
	        {
                matchesWCF.Add(new MatchWCF(m));
	        }
        }

        [DataMember]
        public String Nom
        {
            get { return nom; }
            set { nom = value; }
        }

        [DataMember]
        public List<MatchWCF> Matches
        {
            get { return matchesWCF; }
            set { matchesWCF = value; }
        }

        public Tournoi toTournoi()
        {
            List<Match> matches = new List<Match>();
            foreach (MatchWCF matchWCF in matchesWCF)
            {
                matches.Add(matchWCF.toMatch());
            }
            return new Tournoi(Id, matches, nom);
        }
    }
}