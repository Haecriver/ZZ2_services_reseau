using EntitiesLayer;
using JediTournamentWPF.ListModels;
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
    /// Logique d'interaction pour CtrlMatch.xaml
    /// </summary>
    public partial class CtrlMatch : UserControl
    {
        public CtrlMatch()
        {
            InitializeComponent();
        }
        public CtrlMatch(MatchCombo match_)
        {
            InitializeComponent();
            this.DataContext = match_;

        }
    }
}
