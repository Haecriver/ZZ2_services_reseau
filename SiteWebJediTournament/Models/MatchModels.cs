using SiteWebJediTournament.ServiceReference1;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SiteWebJediTournament.Models
{
    public class MatchModels
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Jedi 1")]
        public JediContainer Jedi1 { get; set; }
        [Required]
        [Display(Name = "Jedi 2")]
        public JediContainer Jedi2 { get; set; }
        [Required]
        [Display(Name = "Phase du tournoi")]
        public EPhaseTournoi PhaseTournoi { get; set; }
        
        [Display(Name = "Jedi vainqueur")]
        public JediContainer JediVainqueur { get; set; }
        [Required]
        [Display(Name = "Stade")]
        public StadeContainer Stade { get; set; }

        public MatchModels(MatchWCF match)
        {
            Jedi1 = new JediContainer(new JediModels(match.Jedi1));
            Jedi2 = new JediContainer(new JediModels(match.Jedi2));
            if (match.JediVainqueur != null)
            {
                JediVainqueur = new JediContainer(new JediModels(match.JediVainqueur));
            }
            Stade = new StadeContainer(new StadeModels(match.Stade));
            PhaseTournoi = match.PhaseTournoi;
        }

        public MatchModels()
        {

        }

    }
}