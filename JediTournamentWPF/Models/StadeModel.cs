using BiblioWPF.ViewModel;
using EntitiesLayer;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace stadeTournamentWPF.Models
{
    public class StadeModel : ViewModelBase, INotifyPropertyChanged
    {
        private Stade stade;

        public Stade Stade
        {
            get { return stade; }
        }

        public StadeModel(Stade stade_)
        {
            stade = stade_;
        }

        public ObservableCollection<Caracteristique> Caracteristiques
        {
            get { return new ObservableCollection<Caracteristique>(stade.Caracteristiques); }
            set
            {
                stade.Caracteristiques = value.ToList<Caracteristique>();
                OnPropertyChanged("Caracteristiques");
            }
        }

        public int NbPlaces
        {
            get { return stade.NbPlaces; }
            set
            {
                stade.NbPlaces = value;
                OnPropertyChanged("NbPlaces");
            }
        }

        public string Planete
        {
            get { return stade.Planete; }
            set
            {
                stade.Planete = value;
                OnPropertyChanged("Planete");
            }
        }

        public override string ToString()
        {
            return stade.ToString();
        }

    }
}
