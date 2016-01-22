using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntitiesLayer;

namespace BusinessLayer
{
    public class PlayingJedi
    {
        private int hpJedi;
        private int caractForce;
        private int caractDefense;
        private int caractChance;

        private EDefCaracteristique choosenCaract;

        public PlayingJedi(Jedi jedi)
        {
            List<Caracteristique> caractJedi = jedi.Caracteristiques;

            //Calcul de la sante
            hpJedi = (from element in caractJedi
                      where element.Definition == EDefCaracteristique.Sante
                      select element.Valeur).Sum()
                          + PlayingMatch.baseHP;

            //Calcul de la force
            caractForce = (from element in caractJedi
                           where element.Definition == EDefCaracteristique.Force
                           select element.Valeur).Sum();

            //Calcul de la defense
            caractDefense = (from element in caractJedi
                             where element.Definition == EDefCaracteristique.Defense
                             select element.Valeur).Sum();

            //Calcul de la chance
            caractChance = (from element in caractJedi
                            where element.Definition == EDefCaracteristique.Chance
                            select element.Valeur).Sum();

        }

        public int HpJedi
        {
            get
            {
                return hpJedi;
            }

            set
            {
                hpJedi = value;
            }
        }

        public int CaractForce
        {
            get
            {
                return caractForce;
            }
        }

        public int CaractDefense
        {
            get
            {
                return caractDefense;
            }
        }

        public int CaractChance
        {
            get
            {
                return caractChance;
            }
        }

        public EDefCaracteristique ChoosenCaract
        {
            get
            {
                return choosenCaract;
            }

            set
            {
                choosenCaract = value;
            }
        }
    }
}
