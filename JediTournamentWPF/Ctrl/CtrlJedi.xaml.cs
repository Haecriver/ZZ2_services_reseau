using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using EntitiesLayer;
using JediTournamentWPF;
using System.Collections.ObjectModel;
using JediTournamentWPF.Fiches;
using JediTournamentWPF.Models;

namespace JediTournamentWPF
{
    public partial class CtrlJedi : UserControl
    {
        public CtrlJedi()
        {
            InitializeComponent();
        }

        public CtrlJedi(Jedi jedi_)
        {
            InitializeComponent();
            this.DataContext = jedi_;
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void ListBox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Fiche_Caracteristique win = new Fiche_Caracteristique(new CaracteristiqueModel((Caracteristique) (ListeCarac.SelectedItem)));
            win.ModifyCaractClicked += Win_ModifyCaractClicked; ;
            win.Show();
        }

        private void Win_ModifyCaractClicked(CaracteristiqueModel obj)
        {
            int index = ListeCarac.SelectedIndex;
            if (index != -1)
            {
                ListeCarac.Items.RemoveAt(index);
                ListeCarac.Items.Insert(index, obj);
            }
        }
    }
}