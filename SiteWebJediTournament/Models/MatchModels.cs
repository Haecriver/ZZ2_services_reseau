using SiteWebJediTournament.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SiteWebJediTournament.Models
{
    public class MatchModels
    {
        public int Id { get; set; }
        public JediWCF Jedi1 { get; set; }
        public JediWCF Jedi2 { get; set; }
        public EPhaseTournoi PhaseTournoi { get; set; }
        public JediWCF JediVainqueur { get; set; }
        public StadeWCF Stade { get; set; }

        public MatchModels(MatchWCF match)
        {
            Jedi1 = match.Jedi1;
            Jedi2 = match.Jedi2;
            JediVainqueur = match.JediVainqueur;
            Stade = match.Stade;
            PhaseTournoi = match.PhaseTournoi;
        }

        public MatchModels()
        {

        }

    }
}