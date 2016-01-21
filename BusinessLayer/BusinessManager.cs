using EntitiesLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
 

namespace BusinessLayer
{
    public enum Clicked
    {
        Jedis,
        Stades,
        Matchs,
        Caracteristiques,
        Bonus,
        Null
    };
    public class BusinessManager
    {
        private StubDataAccessLayer.DalManager data;

        public BusinessManager()
        {
            data = new StubDataAccessLayer.DalManager();
        }

        public List<Stade> getStades()  {return data.getAllStade();}
        public List<Jedi> getJedis() { return data.getAllJedi(); }
        public List<Match> getMatches() { return data.getAllMatch(); }
        public List<Caracteristique> getCaracteristique() { return data.getAllCaracteristic(); }

        public IEnumerable<String> getStringStades()
        {
            List<Stade> stades = data.getAllStade();
            IEnumerable<string> results = from stade in stades select stade.Planete + "(" + stade.NbPlaces + ")";
            return results;
        }

        public IEnumerable<String> getStringJedis()
        {
            List<Jedi> jedis = data.getAllJedi();
            IEnumerable<string> results = from jedi in jedis select jedi.Nom;
            return results;
        }

        public IEnumerable<String> getStringMatchs()
        {
            List<Match> matches = data.getAllMatch();
            IEnumerable<string> results = from match in matches select match.Jedi1+" vs "+ match.Jedi2+" in "+match.Stade.Planete;
            return results;
        }

        public IEnumerable<String> getStringCaracteristics()
        {
            List<Caracteristique> caracteristics = data.getAllCaracteristic();
            IEnumerable<string> results = from caracteristic in caracteristics select caracteristic.Nom;
            return results;
        }


        public IEnumerable<String> getStringObscurJedis()
        {
            List<Jedi> jedis = data.getAllJedi();
            IEnumerable<string> results = from jedi in jedis where jedi.IsSith select jedi.Nom;
            return results;
        }

        public IEnumerable<String> getStringJedis(int strengthPts, int lifePts)
        {
            List<Jedi> jedis = data.getAllJedi();
            IEnumerable<string> force = from jedi in jedis where jedi.Caracteristiques.Any(caract => (caract.Definition == EDefCaracteristique.Force && caract.Valeur > 3)) select jedi.Nom;
            IEnumerable<string> sante = from jedi in jedis where jedi.Caracteristiques.Any(caract => (caract.Definition == EDefCaracteristique.Sante && caract.Valeur > 50)) select jedi.Nom;
            IEnumerable<string> results = force.Intersect(sante);
            return results;
        }

        public IEnumerable<string> getStringSithMatchesOver200()
        {
            List<Match> matches = data.getAllMatch();
            IEnumerable<string> places = from match in matches where match.Stade.NbPlaces > 200 select match.Stade.Planete + ' ' + match.Jedi1.Nom + ' ' + match.Jedi2.Nom;
            IEnumerable<string> sith = from match in matches where match.Jedi1.IsSith && match.Jedi2.IsSith select match.Stade.Planete + ' ' + match.Jedi1.Nom + ' ' + match.Jedi2.Nom;
            IEnumerable<string> results = places.Intersect(sith);
            return results.ToList<String>();
        }

        public void ExportXML(Clicked click)
        {
            System.IO.StreamWriter stream;
            XmlSerializer ser;
            switch(click)
            {
                case (Clicked.Jedis):
                    stream = new System.IO.StreamWriter(@"C:\Users\garaux\Desktop\ListeJedis.txt");
                    ser = new XmlSerializer(typeof(List<Jedi>));
                    ser.Serialize(stream, data.getAllJedi());
                    stream.Close();
                    break;
                case (Clicked.Stades):
                    stream = new System.IO.StreamWriter(@"C:\Users\garaux\Desktop\ListeStades.txt");
                    ser = new XmlSerializer(typeof(List<Stade>));
                    ser.Serialize(stream, data.getAllStade());
                    stream.Close();
                    break;
                case (Clicked.Matchs):
                    stream = new System.IO.StreamWriter(@"C:\Users\garaux\Desktop\ListeMatchs.txt");
                    ser = new XmlSerializer(typeof(List<Match>));
                    ser.Serialize(stream, data.getAllMatch());
                    stream.Close();
                    break;
                case (Clicked.Caracteristiques):
                    stream = new System.IO.StreamWriter(@"C:\Users\garaux\Desktop\ListeCaracteristiques.txt");
                    ser = new XmlSerializer(typeof(List<Caracteristique>));
                    ser.Serialize(stream, data.getAllCaracteristic());
                    stream.Close();
                    break;
                default:
                    break;
            }
        }

        public bool CheckConnexionUser(string login, string password)
        {
            bool result;
            try
            {
                Utilisateur u = data.getUtilisateurByLogin(login);
                result = (u.Password == password);
            }
            catch (NullReferenceException)
            {
                result = false;
            }
            return result;
        }
    }

}
