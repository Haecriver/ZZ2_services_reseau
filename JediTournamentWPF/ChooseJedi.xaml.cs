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
using System.Windows.Shapes;

namespace JediTournamentWPF
{
    /// <summary>
    /// Logique d'interaction pour ChooseJedi.xaml
    /// </summary>
    public partial class ChooseJedi : Window
    {
        private Jedi jediChoisi;

        public ChooseJedi()
        {
            InitializeComponent();
            BusinessManager manager = new BusinessManager();
            JedisListModel jedis = new JedisListModel(manager.getJedis());
            SelectorJedi.DataContext = jedis;
            SelectorJedi.ItemsSource = jedis.Jedis;
        }



        private void ChoixJedi_Click(object sender, RoutedEventArgs e)
        {
            if(SelectorJedi.SelectedItem!=null)
            {
                jediChoisi = ((JediModel)SelectorJedi.SelectedItem).Jedi;
                Jeux jeux = new Jeux(jediChoisi);
                jeux.Show();
                this.Close();
            }
        }

        private void Retour_Click(object sender, RoutedEventArgs e)
        {
            Principale fenetre = new Principale();
            fenetre.Show();
            this.Close();

        }
    }
}
