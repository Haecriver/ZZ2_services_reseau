using BiblioWPF.ViewModel;
using stadeTournamentWPF.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JediTournamentWPF.ListModels
{
    public class StadesListModel : ViewModelBase, INotifyPropertyChanged
    {
        private ObservableCollection<StadeModel> _stades;

        public ObservableCollection<StadeModel> Stades
        {
            get { return _stades; }
            private set
            {
                _stades = value;
                OnPropertyChanged("Stades");
            }
        }

        private StadeModel _selectedItem;
        public StadeModel SelectedItem
        {
            get { return _selectedItem; }
            private set
            {
                _selectedItem = value;
                OnPropertyChanged("SelectedStadium");
            }
        }

        //Constructeur
        public StadesListModel(List<EntitiesLayer.Stade> stadeList)
        {
            _stades = new ObservableCollection<StadeModel>();
            foreach (EntitiesLayer.Stade s in stadeList)
            {
                _stades.Add(new StadeModel(s));
            }
        }
    }
}
