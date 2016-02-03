using BiblioWPF.ViewModel;
using stadeTournamentWPF.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JediTournamentWPF.Models;
using JediTournamentWPF.ListModels;

namespace JediTournamentWPF
{
    public class MatchCombo : ViewModelBase, INotifyPropertyChanged
    {
        private MatchModel match;
        private readonly ObservableCollection<JediModel> jedis;
        private readonly ObservableCollection<StadeModel> stades;

        public MatchCombo(MatchModel match_, JedisListModel jedis_, StadesListModel stades_)
        {
            match = match_;
            jedis = jedis_.Jedis;
            stades = stades_.Stades;
        }

        public MatchModel Match
        {
            get { return match; }
            set
            {
                match = value;
                OnPropertyChanged("Match");
            }
        }

        public ObservableCollection<JediModel> Jedis
        {
            get { return jedis; }
        }

        public ObservableCollection<StadeModel> Stades
        {
            get { return stades; }
        }

    }
}
