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
            C = c_;
            lc = new ObservableCollection<EDefCaracteristique>();
            for (int i = 0; i < 3; ++i)
            {
                lc.Add((EDefCaracteristique)i);
            }
        }

        public int Valeur
        {
            get
            {
                return C.Valeur;
            }
            set
            {
                C.Valeur = value;
                OnPropertyChanged("Valeur");
            }
        }

        public EDefCaracteristique Definition
        {
            get
            {
                return C.Definition;
            }
            set
            {
                C.Definition = value;
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

        public Caracteristique C
        {
            get
            {
                return c;
            }

            set
            {
                c = value;
            }
        }

        public override String ToString()
        {
            return c.ToString();
        }
    }
}
