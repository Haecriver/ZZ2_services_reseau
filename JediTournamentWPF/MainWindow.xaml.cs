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
        private static Clicked click = Clicked.Null;
        private BusinessManager manager;
        bool bonus = false;

        public MainWindow()
        {
            InitializeComponent();
            manager = new BusinessManager();
        }

        private void StadesButton_Click(object sender, RoutedEventArgs e)
        {
            //Selector.Items.Clear();
            click = Clicked.Stades;
            Selector.ItemsSource = manager.getStades();
        }

        private void JedisButton_Click(object sender, RoutedEventArgs e)
        {
            //Selector.Items.Clear();
            click = Clicked.Jedis;
            Selector.ItemsSource = manager.getJedis();            
        }

        private void MatchsButton_Click(object sender, RoutedEventArgs e)
        {
            click = Clicked.Matchs;
            Selector.ItemsSource = manager.getMatchs();
        }

        private void CaracteristiquesButton_Click(object sender, RoutedEventArgs e)
        {
            click = Clicked.Caracteristiques;
            Selector.ItemsSource = manager.getCaracteristics();
        }

        private void BonusButton_Click(object sender, RoutedEventArgs e)
        {
            bonus = !bonus;
            if (bonus)
            {
                yodapng.Visibility = Visibility.Visible;
            }
            else
            {
                yodapng.Visibility = Visibility.Hidden;
            }
            click = Clicked.Bonus;
        }

        private void Selector_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }

        private void ExportButton_Click(object sender, RoutedEventArgs e)
        {
            //Selector.Items.Clear();
            manager.ExportXML(click);
                
            
        }
    }
}
