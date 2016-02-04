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
    /// Logique d'interaction pour Paris.xaml
    /// </summary>
    public partial class Paris : Window
    {
        private BettingManager bn;

        public Paris()
        {
            InitializeComponent();

             bn= new BettingManager(new BusinessManager());
             
            textBox.Text = bn.toString();

             Jedis1.ItemsSource = bn.Jedis;
             Jedis2.ItemsSource = bn.Jedis;
             BettingPlayer1.Text = "0";
             BettingPlayer2.Text = "0";

            
        }

        private void paris_Click_1(object sender, RoutedEventArgs e)
        {
            bn.lancerPhaseTournoi(Int32.Parse(BettingPlayer1.Text), (Jedi)Jedis1.SelectedItem, Int32.Parse(BettingPlayer2.Text), (Jedi)Jedis2.SelectedItem);
            Jedis1.ItemsSource = bn.Jedis;
            Jedis2.ItemsSource = bn.Jedis;
            textBox.Text = bn.toString();
            if (bn.End)
            {
                if (bn.Joueur1.Score > bn.Joueur2.Score)
                {
                    MessageBox.Show("Joueur 1 a gagne");
                }
                else if (bn.Joueur1.Score == bn.Joueur2.Score)
                {
                    MessageBox.Show("Egalite");

                }else
                {
                    MessageBox.Show("Joueur 2 a gagne");
                }
                Principale fenetre = new Principale();
                fenetre.Show();
                this.Close();
            }
        }
    }
}
