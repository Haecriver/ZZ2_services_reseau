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

namespace JediTournamentWPF.Ctrl
{
    /// <summary>
    /// Logique d'interaction pour CtrlCaracteristique.xaml
    /// </summary>
    public partial class CtrlCaracteristique : UserControl
    {
        public CtrlCaracteristique()
        {
            InitializeComponent();
        }

        public CtrlCaracteristique(Caracteristique c_)
        {
            InitializeComponent();
            this.DataContext = c_;
        }
    }
}
