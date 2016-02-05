using BiblioWPF.ViewModel;
using JediTournamentWPF.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JediTournamentWPF.ListModels
{
    class CaracteristiqueListModel : ViewModelBase, INotifyPropertyChanged
    {
        private ObservableCollection<CaracteristiqueModel> _caracteristiques;
        public ObservableCollection<CaracteristiqueModel> Caracteristiques
        {
            get
            {
                return _caracteristiques;
            }
            private set
            {
                _caracteristiques = value;
                OnPropertyChanged("Caracteristiques");
            }
        }

        private CaracteristiqueModel _selectedItem;
        public CaracteristiqueModel SelectedItem
        {
            get { return _selectedItem; }
            private set
            {
                _selectedItem = value;
                OnPropertyChanged("Selectedcaracteristique");
            }
        }

        //Constructeur
        public CaracteristiqueListModel(List<EntitiesLayer.Caracteristique> caracteristiquesList)
        {
            _caracteristiques = new ObservableCollection<CaracteristiqueModel>();
            foreach (EntitiesLayer.Caracteristique j in caracteristiquesList)
            {
                _caracteristiques.Add(new CaracteristiqueModel(j));
            }
        }
    }
}
