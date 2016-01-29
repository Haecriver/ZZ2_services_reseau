using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;
using EntitiesLayer;

namespace DataAccessLayer
{
    class DALSqlServer : IDAL
    {
        protected string connectionString;

        public DALSqlServer()
        {
            // this.connectionString="Data Source=(localdb)\\Projects;Initial Catalog=master;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False";
            connectionString = "Data Source=(LocalDB)\\v11.0;AttachDbFilename=C:\\Users\\pipissavy\\Source\\Repos\\ZZ2_services_reseau\\BaseDeDonnees\\bdd_jedi_tournament2.mdf;Integrated Security=True;Connect Timeout=30";
            SqlConnection connection = new SqlConnection(connectionString);
            // Test de la connection
            try
            {
                connection.Open();
                connection.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private DataTable SelectByDataAdapter(string request)
        {
            DataTable dataTable = new DataTable();

            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(request, sqlConnection);
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                sqlDataAdapter.Fill(dataTable);
            }
            return dataTable;
        }

        private List<String> SelectByDataReader(string request)
        {
            List<string> results = new List<string>();

            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(request, sqlConnection);
                sqlConnection.Open();
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

                while (sqlDataReader.Read())
                {
                    results.Add(String.Format("{0} {1}",
                        sqlDataReader.GetString(1),
                        sqlDataReader.GetGuid(0).ToString()));
                }
                sqlConnection.Close();
            }
            return results;
        }

        public Jedi testBDD()
        {
           /* List<String> liststr = SelectByDataReader("SELECT * FROM jedis;");
            Console.Out.Write(liststr[0]);*/

            List<Jedi> jedis = new List<Jedi>();
            DataTable jedis_en_dur = SelectByDataAdapter("SELECT * FROM jedi WHERE nom LIKE 'Armand';");
            foreach (DataRow row in jedis_en_dur.Rows) // Loop over the rows.
            {
                jedis.Add(new Jedi((int)row.ItemArray.ElementAt(0),
                    (string)row.ItemArray.ElementAt(1),
                    (bool)row.ItemArray.ElementAt(2),
                    null));
            }

            return jedis[0];
        }

        public List<Jedi> getAllJedi()
        {
            List<Jedi> jedis = new List<Jedi>();
            DataTable jedis_en_dur = SelectByDataAdapter("SELECT * FROM jedi;");
            foreach (DataRow row in jedis_en_dur.Rows) // Loop over the rows.
            {
                int jediId = (int)row.ItemArray.ElementAt(0);

                List<Caracteristique> caracts = new List<Caracteristique>();
                DataTable caracts_en_dur = SelectByDataAdapter("SELECT * FROM caracteristic,link_jedi_caracteristic" +
                                                               " WHERE caracteristic.numcaract = link_jedi_caracteristic.numcaracteristic" +
                                                               " AND link_jedi_caracteristic.numjedi =" + jediId +";" );
                foreach (DataRow row2 in caracts_en_dur.Rows) // Loop over the rows.
                {
                    caracts.Add(new Caracteristique((int)row2.ItemArray.ElementAt(0),
                        Caracteristique.stringToEDef((string)row2.ItemArray.ElementAt(1)),
                        (string)row2.ItemArray.ElementAt(2),
                        Caracteristique.stringToEType((string)row2.ItemArray.ElementAt(3)),
                        (int)row2.ItemArray.ElementAt(4)));
                }

                jedis.Add(new Jedi((int)row.ItemArray.ElementAt(0),
                    (string)row.ItemArray.ElementAt(1),
                    (bool)row.ItemArray.ElementAt(2),
                     caracts));
            }

            return jedis;
        }

        //EST CE QU'ON STOCK LES JEDIS POUR LES METTRE ENSUITE DANS LES MATCHES ?
        //SINON IL Y AURA PLUSIEUR FOIS LA MEME INSTANCE D'UN JEDI
        public List<Match> getAllMatch()
        {
            List<Match> matches = new List<Match>();
            DataTable matches_en_dur = SelectByDataAdapter("SELECT * FROM match;");
            foreach (DataRow row in matches_en_dur.Rows) // Loop over the rows.
            {
                //STUB
                matches.Add(new Match((int)row.ItemArray.ElementAt(0),
                    new Jedi(1, "test", true, null),
                    new Jedi(2, "toto", false, null),
                    Match.stringToEPhase((string)row.ItemArray.ElementAt(3)),
                    new Stade(1,50,"testpla", null)));
            }

            return matches;
        }

        public List<Stade> getAllStade(){
            List<Stade> stades = new List<Stade>();
            DataTable stade_en_dur = SelectByDataAdapter("SELECT * FROM stade;");
            foreach (DataRow row in stade_en_dur.Rows) // Loop over the rows.
            {
                int stadeId = (int)row.ItemArray.ElementAt(0);

                List<Caracteristique> caracts = new List<Caracteristique>();
                DataTable caracts_en_dur = SelectByDataAdapter("SELECT * FROM caracteristic,link_jedi_caracteristic" +
                                                               " WHERE caracteristic.numcaract = link_jedi_caracteristic.numcaracteristic" +
                                                               " AND link_jedi_caracteristic.numjedi =" + stadeId + ";");
                foreach (DataRow row2 in caracts_en_dur.Rows) // Loop over the rows.
                {
                    caracts.Add(new Caracteristique((int)row2.ItemArray.ElementAt(0),
                        Caracteristique.stringToEDef((string)row2.ItemArray.ElementAt(1)),
                        (string)row2.ItemArray.ElementAt(2),
                        Caracteristique.stringToEType((string)row2.ItemArray.ElementAt(3)),
                        (int)row2.ItemArray.ElementAt(4)));
                }

                stades.Add(new Stade((int)row.ItemArray.ElementAt(0),
                    (int)row.ItemArray.ElementAt(1),
                    (string)row.ItemArray.ElementAt(2),
                     caracts));
            }

            return stades;
        }


        public List<Caracteristique> getAllCaracteristic()
        {
            List<Caracteristique> caracts = new List<Caracteristique>();
            DataTable caracts_en_dur = SelectByDataAdapter("SELECT * FROM caracteristic;");
            foreach (DataRow row in caracts_en_dur.Rows) // Loop over the rows.
            {
                //STUB
                caracts.Add(new Caracteristique((int)row.ItemArray.ElementAt(0),
                        Caracteristique.stringToEDef((string)row.ItemArray.ElementAt(1)),
                        (string)row.ItemArray.ElementAt(2),
                        Caracteristique.stringToEType((string)row.ItemArray.ElementAt(3)),
                        (int)row.ItemArray.ElementAt(4)));
            }

            return caracts;
        }

        public List<Utilisateur> getAllUtilisateur()
        {
            List<Utilisateur> users = new List<Utilisateur>();
            DataTable users_en_dur = SelectByDataAdapter("SELECT * FROM utilisateur;");
            foreach (DataRow row in users_en_dur.Rows) // Loop over the rows.
            {
                //STUB
                users.Add(new Utilisateur((string)row.ItemArray.ElementAt(0),
                        (string)row.ItemArray.ElementAt(1),
                        (string)row.ItemArray.ElementAt(2),
                        (string)row.ItemArray.ElementAt(3)));
            }
            return users;
        }

        public Utilisateur getUtilisateurByLogin(string login)
        {
            List<Utilisateur> users = new List<Utilisateur>();
            Utilisateur res;
            DataTable users_en_dur = SelectByDataAdapter("SELECT * FROM utilisateur WHERE loginuser LIKE '" + login + "';");
            foreach (DataRow row in users_en_dur.Rows) // Loop over the rows.
            {
                //STUB
                users.Add(new Utilisateur((string)row.ItemArray.ElementAt(0),
                        (string)row.ItemArray.ElementAt(1),
                        (string)row.ItemArray.ElementAt(2),
                        (string)row.ItemArray.ElementAt(3)));
            }

            try {
                res = users[0];
            }
            catch (Exception)
            {
                throw new KeyNotFoundException();
            }
            return res;
        }

      /*  public void addJedi(Jedi jedi)
        {

        }

        public void addMatch(Match match)
        {

        }

        public void addStade(Stade stade)
        {

        }

        public void addCaracteristique(Caracteristique caracteristique)
        {

        }

        public void addUtilisateur(Utilisateur utilisateur)
        {

        }*/
    }
}
