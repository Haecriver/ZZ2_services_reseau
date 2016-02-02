using BiblioWPF.ViewModel;
using JediTournamentWPF.ListModels;
using JediTournamentWPF.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JediTournamentWPF
{
    public class MatchListModel : ViewModelBase, INotifyPropertyChanged
    {
        private ObservableCollection<MatchModel> _matchs;
        public ObservableCollection<MatchModel> Matchs
        {
            get { return _matchs; }
            private set
            {
                _matchs = value;
                OnPropertyChanged("Matchs");
            }
        }

        private MatchModel _selectedItem;
        public MatchModel SelectedItem
        {
            get { return _selectedItem; }
            private set
            {
                _selectedItem = value;
                OnPropertyChanged("SelectedMatch");
            }
        }

        //Constructeur
        public MatchListModel(List<EntitiesLayer.Match> matchList)
        {
            _matchs = new ObservableCollection<MatchModel>();
            foreach (EntitiesLayer.Match m in matchList)
            {
                _matchs.Add(new MatchModel(m));
            }
        }
    }
}
