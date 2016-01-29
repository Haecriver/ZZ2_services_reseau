using EntitiesLayer;
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
using System.Windows.Shapes;

namespace JediTournamentWPF
{
    /// <summary>
    /// Logique d'interaction pour Fiche_Jedi.xaml
    /// </summary>
    public partial class Fiche_Jedi : Window
    {

        public event Action<String> ModifyJediClicked;
        public Fiche_Jedi()
        {
            InitializeComponent();
        }
        public Fiche_Jedi(Jedi j)
        {
            InitializeComponent();
            ControleJedi.DataContext = new JediModel(j);
        }
        public Fiche_Jedi(JediModel j)
        {
            InitializeComponent();
            ControleJedi.DataContext = j;
        }

        private void ModifyJedi_Click(object sender, RoutedEventArgs e)
        {
            ModifyJediClicked("modified");
        }
    }
}
