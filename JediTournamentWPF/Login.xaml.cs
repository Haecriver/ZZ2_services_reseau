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

using BusinessLayer;

namespace JediTournamentWPF
{
    /// <summary>
    /// Logique d'interaction pour Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        private BusinessManager manager;
        public Login()
        {
            InitializeComponent();
            manager = new BusinessManager();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (manager.CheckConnexionUser(LoginInput.Text.ToLower(), PasswordInput.Password))
            {
                ErrorLabel.Visibility = Visibility.Hidden;
                MainWindow win = new MainWindow();
                win.Show();
                this.Close();
            }
            else
            {
                ErrorLabel.Visibility = Visibility.Visible;
            }
        }

        private void InputBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
