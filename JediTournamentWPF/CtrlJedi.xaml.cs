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

using EntitiesLayer;
using JediTournamentWPF;
using System.Collections.ObjectModel;

namespace JediTournamentWPF
{
    /// <summary>
    /// Logique d'interaction pour UserControl1.xaml
    /// </summary>
    public partial class CtrlJedi : UserControl
    {
        public CtrlJedi()
        {
            InitializeComponent();

        }
        public CtrlJedi(Jedi jedi_)
        {
            InitializeComponent();
            this.DataContext = jedi_;
        }
    }
}