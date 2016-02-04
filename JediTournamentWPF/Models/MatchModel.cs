using BiblioWPF.ViewModel;
using EntitiesLayer;
using JediTournamentWPF.ListModels;
using stadeTournamentWPF.Models;
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
            set
            {
                if (value != null)
                {
                    match.JediVainqueur = value.Jedi;
                }
                OnPropertyChanged("JediVainqueur");
                OnPropertyChanged("Jedi1Win");
                OnPropertyChanged("Jedi2Win");
            }
        }

        public JediModel Jedi1
        {
            get { return new JediModel(match.Jedi1); }
            set
            {
                if (value != null && value!=Jedi2)
                {
                    match.Jedi1 = value.Jedi;
                }
                OnPropertyChanged("Jedi1");
            }
        }

        public JediModel Jedi2
        {
            get { return new JediModel(match.Jedi2); }
            set
            {
                if (value != null && value!=Jedi1)
                {
                    match.Jedi2 = value.Jedi;
                }
                OnPropertyChanged("Jedi2");
            }
        }

        public StadeModel Stade
        {
            get { return new StadeModel(match.Stade); }
            set
            {
                if (value != null)
                {
                    match.Stade = value.Stade;
                }
                OnPropertyChanged("Stade");
            }
        }
 
        public EPhaseTournoi PhaseTournoi
        {
            get { return match.PhaseTournoi; }
            set
            {
                if (this.PhaseTournoi == value)
                    return;

                match.PhaseTournoi = value;
                OnPropertyChanged("PhaseTournoi");
                OnPropertyChanged("IsFinale");
                OnPropertyChanged("IsQuart");
                OnPropertyChanged("IsHuitieme");
                OnPropertyChanged("IsDemi");
            }
        }

        /*******************************************Pour les boutons radio**********************************************/
        public bool IsFinale
        {
            get { return PhaseTournoi == EPhaseTournoi.Finale; }
            set { 
               PhaseTournoi= value ? match.PhaseTournoi=EPhaseTournoi.Finale : PhaseTournoi; 
            }
        }
 
        public bool IsHuitieme
        {
           get { return PhaseTournoi == EPhaseTournoi.HuitiemeFinale; }
            set { 
                PhaseTournoi= value ? match.PhaseTournoi=EPhaseTournoi.HuitiemeFinale : PhaseTournoi; 
            }
        }
 
        public bool IsDemi
        {
            get { return PhaseTournoi == EPhaseTournoi.DemiFinale; }
            set { 
                PhaseTournoi= value ? match.PhaseTournoi=EPhaseTournoi.DemiFinale : PhaseTournoi; 
            }
        }

        public bool IsQuart
        {
            get { return PhaseTournoi == EPhaseTournoi.QuartFinale; }
            set { 
                PhaseTournoi= value ? match.PhaseTournoi=EPhaseTournoi.QuartFinale : PhaseTournoi; 
            }
        }

        public bool Jedi1Win
        {
            get { return JediVainqueur.Jedi==Jedi1.Jedi; }
            set
            {
                JediVainqueur = value ? JediVainqueur=Jedi1 : JediVainqueur;
            }
        }

        public bool Jedi2Win
        {
            get { return JediVainqueur.Jedi==Jedi2.Jedi; }
            set
            {
                JediVainqueur = value ? JediVainqueur=Jedi2 : JediVainqueur;
            }
        }

        /**********************To string***********************/
        public override String ToString()
        {
            return match.ToString();
        }
    }
}
