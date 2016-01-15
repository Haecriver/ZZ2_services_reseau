using BusinessLayer;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace JediTournamentWPF
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private BusinessManager manager;
        public MainWindow()
        {
            InitializeComponent();
            manager = new BusinessManager();
        }

        private void StadesButton_Click(object sender, RoutedEventArgs e)
        {
            //Selector.Items.Clear();
            Selector.ItemsSource = manager.getStades();
        }

        private void JedisButton_Click(object sender, RoutedEventArgs e)
        {
            //Selector.Items.Clear();
            Selector.ItemsSource = manager.getJedis();            
        }

        private void MatchsButton_Click(object sender, RoutedEventArgs e)
        {
            Selector.ItemsSource = manager.getMatchs();
        }

        private void CaracteristiquesButton_Click(object sender, RoutedEventArgs e)
        {
            Selector.ItemsSource = manager.getCaracteristics();
        }

        private void BonusButton_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void ExportJedisButton_Click(object sender, RoutedEventArgs e)
        {
            //Selector.Items.Clear();
            manager.ExportJedis();
        }
    }
}
