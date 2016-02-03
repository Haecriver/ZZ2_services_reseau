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
using System.Windows.Forms;
using JediTournamentWPF.Models;
using JediTournamentWPF.ListModels;
using JediTournamentWPF.Fiches;
using stadeTournamentWPF.Models;

namespace JediTournamentWPF
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private static Clicked click = Clicked.Null;
        private BusinessManager manager;
        private JedisListModel jedis;
        private MatchListModel matchs;
        private StadesListModel stades;
        private MatchCombo matchCombo;

        bool bonus = false;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void StadesButton_Click(object sender, RoutedEventArgs e)
        {
            //Selector.Items.Clear();
            click = Clicked.Stades;
            Selector.DataContext = stades;
            Selector.ItemsSource = stades.Stades;
        }

        private void JedisButton_Click(object sender, RoutedEventArgs e)
        {
            //Selector.Items.Clear();
            click = Clicked.Jedis;
            Selector.DataContext = jedis;
            Selector.ItemsSource = jedis.Jedis;
        }

        private void MatchsButton_Click(object sender, RoutedEventArgs e)
        {
            click = Clicked.Matchs;
            Selector.DataContext = matchs;
            Selector.ItemsSource = matchs.Matchs;
        }

        private void CaracteristiquesButton_Click(object sender, RoutedEventArgs e)
        {
            click = Clicked.Caracteristiques;
            Selector.ItemsSource = manager.getStringCaracteristics();
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
            FolderBrowserDialog folderBrowser = new FolderBrowserDialog();
            folderBrowser.Description = "Choisissez où créer le fichier.\nAttention, si le fichier existe déjà, il sera remplacé !";
            folderBrowser.ShowDialog();
            //manager.ExportXML(click, folderBrowser.SelectedPath);
        }

        private void Selector_MouseDoubleClick_1(object sender, MouseButtonEventArgs e)
        {
            //Console.WriteLine(Selector.SelectedItem);
            if (click == Clicked.Jedis) 
            {
                //Jedi j = (Jedi)Selector.SelectedItem;
                Fiche_Jedi win = new Fiche_Jedi((JediModel)Selector.SelectedItem);
                win.ModifyJediClicked += win_ModifyJediClicked;
                win.Show();
            }
            if(click==Clicked.Matchs)
            {
                matchCombo = new MatchCombo((MatchModel)Selector.SelectedItem, jedis, stades);
                Fiche_Match win = new Fiche_Match(matchCombo);
                win.ModifyMatchClicked += win_ModifyMatchClicked;
                win.Show();
            }
            if(click==Clicked.Stades)
            {
                Fiche_Stade win = new Fiche_Stade((StadeModel)Selector.SelectedItem);
                win.ModifyStadiumClicked += win_ModifyStadiumClicked;
                win.Show();
            }
        }

        void win_ModifyJediClicked(JediModel j)
        {
            int index = Selector.SelectedIndex;
            jedis.Jedis.RemoveAt(index);
            jedis.Jedis.Insert(index,j);
        }

        void win_ModifyMatchClicked(MatchCombo mc)
        {
            int index = Selector.SelectedIndex;
            MatchModel m = mc.Match;
            matchs.Matchs.RemoveAt(index);
            matchs.Matchs.Insert(index, m);
        }

        void win_ModifyStadiumClicked(StadeModel s)
        {
            int index = Selector.SelectedIndex;
            stades.Stades.RemoveAt(index);
            stades.Stades.Insert(index, s);
        }

        private void Jedi_Tournament_2016_Loaded(object sender, RoutedEventArgs e)
        {
            manager = new BusinessManager();
            jedis = new JedisListModel(manager.getJedis());
            stades = new StadesListModel(manager.getStades());
            matchs = new MatchListModel(manager.getMatches());
        }
    }
}
