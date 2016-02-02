using EntitiesLayer;
using stadeTournamentWPF.Models;
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

namespace JediTournamentWPF.Fiches
{
    /// <summary>
    /// Logique d'interaction pour Fiche_Stade.xaml
    /// </summary>
    public partial class Fiche_Stade : Window
    {
        public event Action<StadeModel> ModifyStadiumClicked;
        public Fiche_Stade()
        {
            InitializeComponent();
        }
        public Fiche_Stade(Stade s):this()
        {
            ControleStadium.DataContext = new StadeModel(s);
        }
        public Fiche_Stade(StadeModel j):this()
        {
            ControleStadium.DataContext = j;
        }

        private void ModifyStadium_Click(object sender, RoutedEventArgs e)
        {
            ModifyStadiumClicked((StadeModel)ControleStadium.DataContext);
            this.Close();
        }
    }
}
