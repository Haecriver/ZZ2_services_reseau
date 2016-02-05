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
using EntitiesLayer;
using JediTournamentWPF.Models;

namespace JediTournamentWPF.Fiches
{
    /// <summary>
    /// Logique d'interaction pour Fiche_Caracteristique.xaml
    /// </summary>
    public partial class Fiche_Caracteristique : Window
    {
        public event Action<CaracteristiqueModel> ModifyCaractClicked;

        public Fiche_Caracteristique()
        {
            InitializeComponent();
        }

        public Fiche_Caracteristique(Caracteristique selectedItem)
        {
            InitializeComponent();
            ControleCaracteristique.DataContext = new CaracteristiqueModel(selectedItem);
        }

        private void ModifyCaract_Click(object sender, RoutedEventArgs e)
        {
            ModifyCaractClicked((CaracteristiqueModel)ControleCaracteristique.DataContext);
            this.Close();
        }
    }
}
