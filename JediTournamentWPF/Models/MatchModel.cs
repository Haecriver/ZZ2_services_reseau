using BiblioWPF.ViewModel;
using EntitiesLayer;
using JediTournamentWPF.ListModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JediTournamentWPF.Models
{
    public class MatchModel : ViewModelBase, INotifyPropertyChanged
    {
        private Match match;
        public MatchModel(Match match_)
        {
            match = match_;
        }

        public JediModel JediVainqueur
        {
            get { return new JediModel(match.JediVainqueur); }
            set {
                if (value != null)
                {
                    match.JediVainqueur = value.Jedi;
                }
                OnPropertyChanged("JediVainqueur");
            }
        }

        public JediModel Jedi1
        {
            get { return new JediModel(match.Jedi1); }
            set {
                if (value != null)
                {
                    match.Jedi1 = value.Jedi;
                }
                OnPropertyChanged("Jedi1");
            }
        }

        public JediModel Jedi2
        {
            get { return new JediModel(match.Jedi2); }
            set {
                if (value != null)
                {
                    match.Jedi2 = value.Jedi;
                }
                OnPropertyChanged("Jedi2");
            }
        }

        public EPhaseTournoi PhaseTournoi
        {
            get { return match.PhaseTournoi; }
            set {
                match.PhaseTournoi = value;
                OnPropertyChanged("PhaseTournoi");
            }
        }

        public Stade Stade
        {
            get { return match.Stade; }
            set {
                match.Stade = value;
                OnPropertyChanged("Stade");
            }
        }

        public override String ToString()
        {
            return match.ToString();
        }
    }
}
