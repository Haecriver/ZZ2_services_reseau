using BusinessLayer;
using EntitiesLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    /// Logique d'interaction pour Jeux.xaml
    /// </summary>
    public partial class Jeux : Window
    {
        private Jedi jedi;
        private PlayingManager pm;

        public Jeux(Jedi _jedi)
        {
            InitializeComponent();
            jedi = _jedi;
            pm = new PlayingManager(new BusinessManager());
            pm.LancerMatch(jedi);
        }

        private void Force_Click(object sender, RoutedEventArgs e)
        {
            pm.utiliserForce();
            Refresh();
        }
        private void Chance_Click(object sender, RoutedEventArgs e)
        {
            pm.utiliserChance();
            Refresh();
        }
        private void Defense_Click(object sender, RoutedEventArgs e)
        {
            pm.utiliserDefense();
            Refresh();
        }

        private void Window_Loaded_1(object sender, RoutedEventArgs e)
        {
            textBoxJedi.Text = "Match Courant : \n" + pm.title();
        }

        private void Refresh(){
            textBoxJedi.Text = "Match Courant : \n" + pm.title() + "\nResultat dernier match : \n" + pm.StatLastTurn;
            if (pm.End)
            {
                if (pm.Win)
                {
                    MessageBox.Show("Vous avez gagne !!");
                }
                else
                {
                    MessageBox.Show("Vous avez perdu !!");
                }

                Principale fenetre = new Principale();
                fenetre.Show();
                this.Close();
            }
        }

        private void Window_Closing_1(object sender, CancelEventArgs e)
        {
            
        }
    }
}
