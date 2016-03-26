using SiteWebJediTournament.ServiceReference1;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SiteWebJediTournament.Models
{
    public class TournoiModels
    {
        public int Id { get; set; }
        public TournoiWCF TournoiWCF { get; set; }


        [Display(Name = "A parier")]
        public int bet { get; set; }

        [Display(Name = "Nom du jedi sur lequel parier")]
        public int jediBet { get; set; }

        [Required]
        [Display(Name = "Nom")]
        public string Nom { get; set; }
        [Required]
        [Display(Name = "List des matches")]
        public MatchCollection Matches { get; set; }
        [Required]
        [Display(Name = "Argent en banque")]
        public int bank { get; set; }


        public TournoiModels(TournoiWCF tournoi)
        {
            TournoiWCF = tournoi;
            Id = tournoi.Id;
            Nom = tournoi.Nom;
            bank = 500;
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