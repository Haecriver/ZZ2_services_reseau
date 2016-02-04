using BiblioWPF.ViewModel;
using EntitiesLayer;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JediTournamentWPF.Models
{
    public class CaracteristiqueModel : ViewModelBase, INotifyPropertyChanged
    {
        private Caracteristique c;
        private ObservableCollection<EDefCaracteristique> lc;

        public CaracteristiqueModel (Caracteristique c_)
        {
            c = c_;
            lc = new ObservableCollection<EDefCaracteristique>(); //TODO: Ajouter la liste des caracteristiques
            for (int i = 0; i < 3; ++i)
            {
                lc.Add((EDefCaracteristique)i);
            }
        }

        public int Valeur
        {
            get
            {
                return c.Valeur;
            }
            set
            {
                c.Valeur = value;
                OnPropertyChanged("Valeur");
            }
        }

        public EDefCaracteristique Definition
        {
            get
            {
                return c.Definition;
            }
            set
            {
                c.Definition = value;
                OnPropertyChanged("Definition");
            }
        }

        public ObservableCollection<EDefCaracteristique> Definitions
        {
            get
            {
                return lc;
            }
        }
    }
}
