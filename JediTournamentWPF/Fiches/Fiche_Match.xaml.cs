using EntitiesLayer;
using JediTournamentWPF.Models;
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
using JediTournamentWPF.ListModels;

namespace JediTournamentWPF
{
    /// <summary>
    /// Logique d'interaction pour Fiche_Match.xaml
    /// </summary>
    public partial class Fiche_Match : Window
    {

        public event Action<MatchCombo> ModifyMatchClicked;
        public Fiche_Match()
        {
            InitializeComponent();
        }

        /*public Fiche_Match(Match m)
        {
            InitializeComponent();
            ControleMatch.DataContext = new MatchModel(m);
        }*/

        public Fiche_Match(MatchCombo m)
        {
            InitializeComponent();
            ControleMatch.DataContext = m;
        }

        private void ModifyMatch_Click(object sender, RoutedEventArgs e)
        {
            ModifyMatchClicked((MatchCombo)ControleMatch.DataContext);
            this.Close();
        }
    }
}
