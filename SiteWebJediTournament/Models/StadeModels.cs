using SiteWebJediTournament.ServiceReference1;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SiteWebJediTournament.Models
{
    public class StadeModels
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Nom planete")]
        public string Planete { get; set; }
        [Required]
        [Display(Name = "Nombre de places")]
        public int NbPlaces { get; set; }

        [Display(Name = "List caracteristque")]
        public List<CaracteristiqueWCF> Caracts { get; set; }

        public StadeModels(StadeWCF stade)
        {
            Id = stade.Id;
            Planete = stade.Planete;
            NbPlaces = stade.NbPlaces;
            Caracts = new List<CaracteristiqueWCF>();
            foreach (CaracteristiqueWCF c in stade.Caracteristiques)
            {
                Caracts.Add(c);
            }
        }

        public StadeModels()
        {
            
        }


    }
}