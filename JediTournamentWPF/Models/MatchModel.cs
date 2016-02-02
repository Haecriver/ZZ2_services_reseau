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

        public Jedi JediVainqueur
        {
            get { return match.JediVainqueur; }
            set {
                match.JediVainqueur = value;
                OnPropertyChanged("JediVainqueur");
            }
        }

        public Jedi Jedi1
        {
            get { return match.Jedi1; }
            set {
                match.Jedi1 = value;
                OnPropertyChanged("Jedi1");
            }
        }

        public Jedi Jedi2
        {
            get { return match.Jedi2; }
            set {
                match.Jedi2 = value;
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
