using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BiblioWPF.ViewModel;
using EntitiesLayer;
using BusinessLayer;
using System.ComponentModel;
using System.Drawing;
using System.Collections.ObjectModel;

namespace JediTournamentWPF
{
    
    public class JediModel : ViewModelBase, INotifyPropertyChanged
    {
        private Jedi jedi;
        
        public JediModel(Jedi jedi_){
            jedi = jedi_;
        }

        public String Nom 
        {
            get
            {
                return jedi.Nom;
            }

            set
            {
                jedi.Nom = value;
                OnPropertyChanged("Nom");
            }
        }

        public bool Sith
        {
            get
            {
                return jedi.IsSith;
            }
            set
            {
                jedi.IsSith = value;
                OnPropertyChanged("Sith");
            }
        }

        public ObservableCollection<Caracteristique> Caracteristiques
        {
            get
            {
                return new ObservableCollection<Caracteristique>(jedi.Caracteristiques);
            }
            set
            {
                jedi.Caracteristiques = value.ToList<Caracteristique>();
                OnPropertyChanged("Caracteristiques");
            }
        }

        public override String ToString()
        {
            return jedi.ToString();
        }

        public Bitmap Image
        {
            get
            {
                return new Bitmap(jedi.Image);
            }
            set
            {
                jedi.Image = value.ToString();
                OnPropertyChanged("Image");
                //TODO: recuperer l'image
            }
        }

    }
}
