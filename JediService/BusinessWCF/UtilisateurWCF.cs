using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


using EntitiesLayer;
using System.Runtime.Serialization;

namespace JediService.BusinessWCF
{
    [DataContract]
    public class UtilisateurWCF : EntityObjectWCF
    {
        private string nom;
        private string prenom;
        private string login;
        private string password;

        public UtilisateurWCF(Utilisateur user) : base(user)
        {
            this.nom = user.Nom;
            this.Prenom = user.Prenom;
            this.Login = user.Login;
            this.Password = user.Password;
        }

        public Utilisateur toUtilisateur()
        {
           return new Utilisateur(Id,Nom,Prenom,Login,Password);
        }

        [DataMember]
        public string Nom
        {
            get { return nom; }
            set { nom = value; }
        }

        [DataMember]
        public string Prenom
        {
            get { return prenom; }
            set { prenom = value; }
        }

        [DataMember]
        public string Login
        {
            get { return login; }
            set { login = value; }
        }

        [DataMember]
        public string Password
        {
            get { return password; }
            set { password = value; }
        }
    }
}