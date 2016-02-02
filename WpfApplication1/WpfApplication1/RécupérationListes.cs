using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApplication1
{

    class RécupérationListes : INotifyPropertyChanged //*
    {
        //*
        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

        #region Champs Privés

        // Instanciation des collections d'objets
        private ObservableCollection<Département> mListeDépartement = new ObservableCollection<Département>();
        private ObservableCollection<Ville> mListeVille = new ObservableCollection<Ville>();
        private ObservableCollection<MatchModel> mListeMatch = new ObservableCollection<MatchModel>();

        #endregion // Champs Privés

        public ObservableCollection<Département> listeDépartement { get { return mListeDépartement; } }
        public ObservableCollection<Ville> listeVille { get { return mListeVille; } }
        public ObservableCollection<MatchModel> listeMatch { get { return mListeMatch; }}

        // Récupération des objets
        public void GetDépartements()
        {
            Département tmpDépartement = new Département(31, "Haute Garonne");
            tmpDépartement.AddVille(new Ville(0, "Toulouse"));
            tmpDépartement.AddVille(new Ville(1, "Muret"));
            tmpDépartement.AddVille(new Ville(2, "Castelnaudary"));

            listeDépartement.Add(tmpDépartement);
            tmpDépartement = new Département(34, "Hérault");
            tmpDépartement.AddVille(new Ville(0, "Montpellier"));
            tmpDépartement.AddVille(new Ville(1, "Béziers"));
            tmpDépartement.AddVille(new Ville(2, "Clapiers"));
            listeDépartement.Add(tmpDépartement);

        }

        public void GetMatchs()
        {
            Jedi Anakin = new Jedi(0, "Anakin", true);
            Jedi Luke = new Jedi(1, "Luke", false);
            Jedi Yoda = new Jedi(2, "Yoda", false);
            Jedi Sushi = new Jedi(3, "Sushi", true);
            Jedi Burrito = new Jedi(4, "Burrito", false);

            listeMatch.Add(new MatchModel(new Match(0, Anakin, Luke, EPhaseTournoi.QuartFinale, "Etoile noire")));
            listeMatch.Add(new MatchModel(new Match(0, Yoda, Luke, EPhaseTournoi.HuitiemeFinale, "Dagoba")));
            listeMatch.Add(new MatchModel(new Match(0, Sushi, Burrito, EPhaseTournoi.Finale, "Maison")));
        }

        public void GetVilles()
        {
            foreach (var d in listeDépartement)
            {
                foreach (var v in d.VillesDuDépartement)
                {
                    listeVille.Add(v);
                }
            }
        }

        public RécupérationListes()
        {
            GetDépartements();
            GetVilles();
            GetMatchs();
        }


        private Département _DépartementSelectionne = null;
        public Département DépartementSelectionne
        {
            get { return _DépartementSelectionne; }
            set
            {
                _DépartementSelectionne = value;
                OnPropertyChanged("DépartementSelectionne");
            }
        }

        private Ville _VilleSelectionne = null;
        public Ville VilleSelectionne
        {
            get { return _VilleSelectionne; }
            set
            {
                _VilleSelectionne = value;
                OnPropertyChanged("VilleSelectionne");
            }
        }
    }
}