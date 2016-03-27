using SiteWebJediTournament.ServiceReference1;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SiteWebJediTournament.Models
{
    public class CaracteristiqueModels
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Définition")]
        public EDefCaracteristique Def {get; set;}
        [Required]
        [Display(Name = "Nom")]
        public string Nom { get; set; }
        [Required]
        [Display(Name = "Type")]
        public ETypeCaracteristique Type { get; set; }
        [Required]
        [Display(Name = "Valeur")]
        public int Valeur { get; set; }

        public CaracteristiqueModels(CaracteristiqueWCF caracteristique)
        {
            Id = caracteristique.Id;
            Def = caracteristique.Definition;
            Nom = caracteristique.Nom;
            Type = caracteristique.Type;
            Valeur = caracteristique.Valeur;
        }

        public CaracteristiqueModels()
        {
        }
    }

    public class CaracteristiqueCollection
    {
        public int Id { get; set; }
        public List<CaracteristiqueModels> List { get; set; }

        public CaracteristiqueCollection(List<CaracteristiqueModels> list)
        {
            List = list;
        }

        public CaracteristiqueModels Default
        {
            get { return new CaracteristiqueModels(); }
        }
    }
}