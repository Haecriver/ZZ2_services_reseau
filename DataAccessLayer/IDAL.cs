﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using EntitiesLayer;

namespace DataAccessLayer
{
    public interface IDAL
    {
        Jedi testBDD();
        List<Jedi> getAllJedi();
        List<Match> getAllMatch();
        List<Stade> getAllStade();
        List<Caracteristique> getAllCaracteristic();
        List<Utilisateur> getAllUtilisateur();
        Utilisateur getUtilisateurByLogin(string login);

    }

}
