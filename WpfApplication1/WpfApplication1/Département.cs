using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApplication1
{
    class Département : INotifyPropertyChanged
    {
        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

        private int id;
        private string name;
        private ObservableCollection<Ville> villesDuDépartement;

        public int Id
        {
            get
            {
                return id;
            }
            set
            {
                id = value;
                OnPropertyChanged("Id");
            }
        }
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
                OnPropertyChanged("Name");
            }
        }

        public ObservableCollection<Ville> VillesDuDépartement
        {
            get
            {
                return villesDuDépartement;
            }
            set
            {
                villesDuDépartement = value;
                OnPropertyChanged("VillesDuDépartement");
            }
        }
        public Département(int id, string name)
        {
            Id = id;
            Name = name;
            villesDuDépartement = new ObservableCollection<Ville>();
        }

        public void AddVille(Ville v)
        {
            villesDuDépartement.Add(v);
        }
    }
}
