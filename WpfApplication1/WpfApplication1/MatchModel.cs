using System;
using System.ComponentModel;

namespace WpfApplication1

{
    class MatchModel : INotifyPropertyChanged
    {
        private Match match;

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        public MatchModel(Match match_)
        {
            match = match_;
        }

        public Jedi Jedi1
        {
            get { return match.Jedi1; }
            set
            {
                match.Jedi1 = value;
                OnPropertyChanged("Jedi1");
            }
        }

        public Jedi Jedi2
        {
            get { return match.Jedi2; }
            set
            {
                match.Jedi2 = value;
                OnPropertyChanged("Jedi2");
            }
        }

        public String Stade
        {
            get { return match.Stade; }
            set
            {
                match.Stade = value;
                OnPropertyChanged("PhaseTournoi");
            }
        }

        public EPhaseTournoi PhaseTournoi
        {
            get { return match.PhaseTournoi; }
            set
            {
                match.PhaseTournoi = value;
                OnPropertyChanged("Stade");
            }
        }

    }
}
