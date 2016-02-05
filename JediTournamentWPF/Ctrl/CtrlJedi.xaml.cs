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
using JediTournamentWPF.Fiches;
using JediTournamentWPF.Models;
using JediTournamentWPF.ListModels;

namespace JediTournamentWPF
{
    public partial class CtrlJedi : UserControl
    {
        private List<Caracteristique> caracteristiques;
        public CtrlJedi()
        {
            InitializeComponent();
        }

        public CtrlJedi(Jedi jedi_)
        {
            InitializeComponent();
            this.DataContext = jedi_;
            caracteristiques = new List<Caracteristique>(jedi_.Caracteristiques);
        }

        private void ListBox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (ListeCarac.SelectedIndex != -1)
            {
                if (((Caracteristique)ListeCarac.SelectedItem).Definition != EDefCaracteristique.Sante)
                {
                    Fiche_Caracteristique win = new Fiche_Caracteristique((Caracteristique)ListeCarac.SelectedItem);
                    win.ModifyCaractClicked += Win_ModifyCaractClicked;
                    win.Show();
                }
                else
                {
                    MessageBox.Show("Il est impossible de modifier une caractéristique de type Santé");
                }
            }
        }

        private void Win_ModifyCaractClicked(CaracteristiqueModel obj)
        {
            /*
            int index = ListeCarac.SelectedIndex;
            if (index != -1)
            {
                caracteristiques.RemoveAt(index);
                caracteristiques.Insert(index, obj.C);
                ((Jedi)DataContext).Caracteristiques = caracteristiques;
            }
            */
        }
    }
}