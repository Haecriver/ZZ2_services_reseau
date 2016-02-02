using BiblioWPF.ViewModel;
using JediTournamentWPF.ListModels;
using JediTournamentWPF.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JediTournamentWPF
{
    public class MatchCombo : ViewModelBase, INotifyPropertyChanged
    {
        MatchModel match;
        JedisListModel jedis;
        StadesListModel stades;

        public MatchCombo(MatchModel match_, JedisListModel jedis_, StadesListModel stades_)
        {
            match = match_;
            jedis = jedis_;
            stades = stades_;
        }

        public MatchModel Match
        {
            get { return match; }
            set {
                match = value;
                OnPropertyChanged("Match");
            }
        }

        public JedisListModel Jedis
        {
            get { return jedis; }
            set {
                jedis = value;
                OnPropertyChanged("Jedis");
            }
        }

        public StadesListModel Stades
        {
            get { return stades; }
            set {
                stades = value;
                OnPropertyChanged("Stades");
            }
        }

    }
}
