using SiteWebJediTournament.ServiceReference1;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SiteWebJediTournament.Models
{
    public class TournoiModels
    {
        public int Id { get; set; }
        public TournoiWCF TournoiWCF { get; set; }

        public int bet { get; set; }
        public int jediBett { get; set; }


        [Required]
        [Display(Name = "Nom")]
        public string Nom { get; set; }
        [Required]
        [Display(Name = "List des matches")]
        public MatchCollection Matches { get; set; }
        [Required]
        [Display(Name = "Argent en banque")]
        public int Bank { get; set; }


        public TournoiModels(TournoiWCF tournoi)
        {
            TournoiWCF = tournoi;
            Id = tournoi.Id;
            Nom = tournoi.Nom;
            Bank = 500;
            List<MatchModels> list = new List<MatchModels>();
            foreach(MatchWCF m in tournoi.Matches)
            {
                list.Add(new MatchModels(m));
            }
            Matches = new MatchCollection(list);
        }

        public TournoiModels()
        {
        }
    }
}