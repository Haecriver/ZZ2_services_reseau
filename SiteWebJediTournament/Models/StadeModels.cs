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
        public CaracteristiqueCollection Caracts { get; set; }

        public StadeModels(StadeWCF stade)
        {
            Id = stade.Id;
            Planete = stade.Planete;
            NbPlaces = stade.NbPlaces;
            List<CaracteristiqueModels> list = new List<CaracteristiqueModels>();
            foreach (CaracteristiqueWCF c in stade.Caracteristiques)
            {
                list.Add(new CaracteristiqueModels(c));
            }
            Caracts = new CaracteristiqueCollection(list);
        }

        public StadeModels()
        {
            
        }


    }
    public class StadeContainer
    {
        public int Id { get; set; }
        public StadeModels Stade { get; set; }

        public StadeContainer(StadeModels stade)
        {
            Stade = stade;
        }

        public StadeModels Default
        {
            get { return new StadeModels(); }
        }
    }

}