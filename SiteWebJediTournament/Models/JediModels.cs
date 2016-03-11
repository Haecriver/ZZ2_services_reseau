using SiteWebJediTournament.ServiceReference1;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SiteWebJediTournament.Models
{
    public class JediModels
    {
        public int Id {get; set;}
        [Required]
        [Display(Name="Nom")]
        public string Nom {get; set;}
        [Required]
        [Display(Name = "Est un sith")]
        public bool IsSith {get; set;}

        [Display(Name = "Caracteristiques du jedi")]
        public List<CaracteristiqueWCF> Caracts { get; set; }

        public JediModels(JediWCF jedi)
        {
            Id = jedi.Id;
            Nom = jedi.Nom;
            IsSith = jedi.IsSith;
            Caracts = new List<CaracteristiqueWCF>();
            foreach (CaracteristiqueWCF c in jedi.Caracteristiques)
            {
                Caracts.Add(c);
            }
        }

        public JediModels()
        {
        }
    }
}