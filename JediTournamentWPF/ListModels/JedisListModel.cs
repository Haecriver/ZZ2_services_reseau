using BiblioWPF.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JediTournamentWPF
{
    public class JedisListModel : ViewModelBase, INotifyPropertyChanged
    {
        private ObservableCollection<JediModel> _jedis;
        public ObservableCollection<JediModel> Jedis
        {
            get { return _jedis; }
            private set { 
                _jedis = value;
                OnPropertyChanged("Jedis");
            }
        }

        private JediModel _selectedItem;
        public JediModel SelectedItem
        {
            get { return _selectedItem; }
            private set { 
                _selectedItem = value;
                OnPropertyChanged("SelectedJedi");
            }
        }
        
        //Constructeur
        public JedisListModel(List<EntitiesLayer.Jedi> jedisList) {
            _jedis = new ObservableCollection<JediModel>();
            foreach (EntitiesLayer.Jedi j in jedisList) {
                _jedis.Add(new JediModel(j));
            }
        }
    }
}
