using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BiblioWPF.ViewModel;
using EntitiesLayer;
using BusinessLayer;

namespace JediTournamentWPF
{
    
    public class JediModel : ViewModelBase
    {
        private BusinessManager manager;
        private List<Jedi> allJedi;
        
        public JediModel(BusinessManager manager){
            this.manager = manager;
            allJedi = manager.getJedis();
        }

    }
}
