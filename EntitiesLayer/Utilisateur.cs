using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiesLayer
{
    public class Utilisateur
    {
        private string nom;
        public string Nom
        {
            get { return nom; }
            set { nom = value; }
        }
        
        private string prenom;
        public string Prenom
        {
            get { return prenom; }
            set { prenom = value; }
        }
        
        private string login;
        public string Login
        {
            get { return login; }
            set { login = value; }
        }
        
        private string password;
        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        public Utilisateur(string _nom, string _prenom, string _login, string _password)
        {
            nom = _nom;
            prenom = _prenom;
            login = _login;
            password = _password;
        }

    }
}
