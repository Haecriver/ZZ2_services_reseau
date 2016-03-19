using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiesLayer
{
    public class Utilisateur
    {
        private static int countId=1;
        public static int CountId
        {
            get { return countId; }
        }
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

        private int id;
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public Utilisateur()
        {

        }

        //Dans ce cas le mdp est deja hashe, pas besoin de le refaire
        public Utilisateur(int _id,string _nom, string _prenom, string _login, string _password)
        {

            if (_id > countId)
            {
                countId = _id;
            }
            id = _id;
            nom = _nom;
            prenom = _prenom;
            login = _login;
            password = _password;
        }
        public Utilisateur(string _nom, string _prenom, string _login, string _password)
        {
            countId++;
            Id = countId;

            nom = _nom;
            prenom = _prenom;
            login = _login;
            password = HashSH1.GetSHA1HashData(_password);
        }
    }
}
