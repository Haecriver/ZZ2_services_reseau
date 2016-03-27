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
        [Required]
        [Display(Name = "Caractéristiques du Jedi")]
        public  CaracteristiqueCollection Caracts { get; set; }

        public JediModels(JediWCF jedi)
        {
            Id = jedi.Id;
            Nom = jedi.Nom;
            IsSith = jedi.IsSith;
        
            List<CaracteristiqueModels> list = new List<CaracteristiqueModels>();
            foreach (CaracteristiqueWCF c in jedi.Caracteristiques)
            {
                list.Add(new CaracteristiqueModels(c));
            }
            Caracts = new CaracteristiqueCollection(list);
        }

        public JediModels()
        {
        }
    }
    public class JediCollection
    {
        public int Id { get; set; }
        public List<JediModels> List { get; set; }

        public JediCollection(List<JediModels> list)
        {
            List = list;
        }

        public JediModels Default
        {
            get { return new JediModels(); }
        }
    }

    public class JediContainer
    {
        public int Id { get; set; }
        public JediModels Jedi { get; set; }

        public JediContainer(JediModels jedi)
        {
            Jedi = jedi;
        }

        public JediModels Default
        {
            get { return new JediModels(); }
        }
    }
}