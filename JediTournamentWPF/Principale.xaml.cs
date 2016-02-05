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
    /// Logique d'interaction pour Principale.xaml
    /// </summary>
    public partial class Principale : Window
    {
        public Principale()
        {
            InitializeComponent();
        }

        private void Gestion_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            main.Show();
            this.Close();
        }

        private void Jouer_Click(object sender, RoutedEventArgs e)
        {
            ChooseJedi main = new ChooseJedi();
            main.Show();
            this.Close();
        }

        private void Paris_Click(object sender, RoutedEventArgs e)
        {
            Paris main = new Paris();
            main.Show();
            this.Close();
        }
    }
}
