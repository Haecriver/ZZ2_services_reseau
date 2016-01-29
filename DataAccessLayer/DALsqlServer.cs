using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;
using EntitiesLayer;
using System.ComponentModel;

namespace DataAccessLayer
{
    class DALSqlServer : IDAL
    {
        protected string connectionString;
        protected string user = "pichevalie1";

        public DALSqlServer()
        {
            // connectionString = "Data Source=(LocalDB)\\v11.0;AttachDbFilename=C:\\Users\\"+user+"\\Source\\Repos\\ZZ2_services_reseau\\BaseDeDonnees\\bdd_jedi_tournament2.mdf;Integrated Security=True;Connect Timeout=30";
            connectionString = "Data Source = (LocalDB)\\MSSQLLocalDB; AttachDbFilename = C:\\Users\\Pierre\\Documents\\GitHub\\ZZ2_services_reseau\\BaseDeDonnees\\bdd_jedi_tournament_2014.mdf; Integrated Security = True; Connect Timeout = 30";
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

        private Jedi getJediById(int jediId)
        {
            Jedi res;
            List<Jedi> jedis = new List<Jedi>();
            DataTable jedis_en_dur = SelectByDataAdapter("SELECT * FROM jedi WHERE numjedi="+jediId+";");
            foreach (DataRow row in jedis_en_dur.Rows) // Loop over the rows.
            {
                List<Caracteristique> caracts = new List<Caracteristique>();
                DataTable caracts_en_dur = SelectByDataAdapter("SELECT * FROM caracteristic,link_jedi_caracteristic" +
                                                               " WHERE caracteristic.numcaract = link_jedi_caracteristic.numcaracteristic" +
                                                               " AND link_jedi_caracteristic.numjedi =" + jediId + ";");
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

            try
            {
                res = jedis[0];
            }
            catch (Exception)
            {
                throw new Exception("Jedi ID doesn't exist !");
            }

            return res;
        }

        //EST CE QU'ON STOCK LES JEDIS POUR LES METTRE ENSUITE DANS LES MATCHES ?
        //SINON IL Y AURA PLUSIEUR FOIS LA MEME INSTANCE D'UN JEDI
        public List<Match> getAllMatch()
        {
            List<Match> matches = new List<Match>();
            DataTable matches_en_dur = SelectByDataAdapter("SELECT * FROM match;");
            foreach (DataRow row in matches_en_dur.Rows) // Loop over the rows.
            {
                matches.Add(new Match((int)row.ItemArray.ElementAt(0),
                    getJediById((int)row.ItemArray.ElementAt(1)),
                    getJediById((int)row.ItemArray.ElementAt(2)),
                    Match.stringToEPhase((string)row.ItemArray.ElementAt(3)),
                    getStadeById((int)row.ItemArray.ElementAt(4))
                    ));
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

        public Stade getStadeById(int stadeId)
        {
            Stade res;
            List<Stade> stades = new List<Stade>();
            DataTable stade_en_dur = SelectByDataAdapter("SELECT * FROM stade WHERE numstade="+stadeId+";");
            foreach (DataRow row in stade_en_dur.Rows) // Loop over the rows.
            {
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

            try
            {
                res = stades[0];
            }
            catch (Exception)
            {
                throw new Exception("Stade ID doesn't exist !");
            }

            return res;
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
                users.Add(new Utilisateur((int)row.ItemArray.ElementAt(0),
                        (string)row.ItemArray.ElementAt(1),
                        (string)row.ItemArray.ElementAt(2),
                        (string)row.ItemArray.ElementAt(3),
                        (string)row.ItemArray.ElementAt(4)));
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
                users.Add(new Utilisateur((int)row.ItemArray.ElementAt(0),
                        (string)row.ItemArray.ElementAt(1),
                        (string)row.ItemArray.ElementAt(2),
                        (string)row.ItemArray.ElementAt(3),
                        (string)row.ItemArray.ElementAt(4)));
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

        //request = Select * de la table qu'on veut modifier
        //authors = ce que l'ont veut inserer ou modifer
        private int UpdateByCommandBuilder(string request, DataTable authors)
        {
            int result;

            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(request, sqlConnection);
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);

                SqlCommandBuilder sqlCommandBuilder = new SqlCommandBuilder(sqlDataAdapter);

                sqlDataAdapter.UpdateCommand = sqlCommandBuilder.GetUpdateCommand();
                sqlDataAdapter.InsertCommand = sqlCommandBuilder.GetInsertCommand();
                sqlDataAdapter.DeleteCommand = sqlCommandBuilder.GetDeleteCommand();

                sqlDataAdapter.MissingSchemaAction = MissingSchemaAction.AddWithKey;

                result = sqlDataAdapter.Update(authors);
            }

            return result;
        }


        public void updateJedi(List<Jedi> jedis)
        {
            DataTable dataTableJedi = new DataTable();
            dataTableJedi.Columns.Add("numjedi", typeof(int));
            dataTableJedi.Columns.Add("nom", typeof(string));
            dataTableJedi.Columns.Add("sith", typeof(int));

            DataTable dataTableCar = new DataTable();
            dataTableCar.Columns.Add("numjedi", typeof(int));
            dataTableCar.Columns.Add("numcaracteristic", typeof(int));

            foreach (Jedi jedi in jedis)
            {
                dataTableJedi.Rows.Add(jedi.Id, jedi.Nom, jedi.IsSith);

                foreach (Caracteristique c in jedi.Caracteristiques)
                {
                    dataTableCar.Rows.Add(jedi.Id, c.Id);
                }
            }
            UpdateByCommandBuilder("SELECT * FROM jedi;", dataTableJedi);
            UpdateByCommandBuilder("SELECT * FROM link_jedi_caracteristic;", dataTableCar);
        }
        public void updateMatch(List<Match> matches)
        {
            DataTable dataTableMatch = new DataTable();
            dataTableMatch.Columns.Add("nummatch", typeof(int));
            dataTableMatch.Columns.Add("numjedi1", typeof(int));
            dataTableMatch.Columns.Add("numjedi2", typeof(int));
            dataTableMatch.Columns.Add("phase", typeof(string));
            dataTableMatch.Columns.Add("numstade", typeof(int));

            foreach (Match match in matches)
            {
                dataTableMatch.Rows.Add(match.Id, match.Jedi1.Id, match.Jedi2.Id, match.PhaseTournoi.ToString(), match.Stade.Id);
            }

            UpdateByCommandBuilder("SELECT * FROM match;", dataTableMatch);
        }
        public void updateStade(List<Stade> stades)
        {
            DataTable dataTableStade = new DataTable();
            dataTableStade.Columns.Add("numstade", typeof(int));
            dataTableStade.Columns.Add("nbplace", typeof(int));
            dataTableStade.Columns.Add("planete", typeof(string));

            DataTable dataTableCar = new DataTable();
            dataTableCar.Columns.Add("numstade", typeof(int));
            dataTableCar.Columns.Add("numcaracteristic", typeof(int));

            foreach (Stade stade in stades)
            {
                dataTableStade.Rows.Add(stade.Id, stade.NbPlaces, stade.Planete);
                foreach (Caracteristique c in stade.Caracteristiques)
                {
                    dataTableCar.Rows.Add(stade.Id, c.Id);
                }
            }
            UpdateByCommandBuilder("SELECT * FROM stade;", dataTableStade);
            UpdateByCommandBuilder("SELECT * FROM link_stade_caracteristic;", dataTableCar);
        }
        public void updateCaracteristique(List<Caracteristique> caracteristiques)
        {
            DataTable dataTableCar = new DataTable();
            dataTableCar.Columns.Add("numcaract", typeof(int));
            dataTableCar.Columns.Add("def", typeof(string));
            dataTableCar.Columns.Add("nom", typeof(string));
            dataTableCar.Columns.Add("typecar", typeof(string));
            dataTableCar.Columns.Add("valeur", typeof(int));

            foreach (Caracteristique caracteristique in caracteristiques)
            {
                dataTableCar.Rows.Add(caracteristique.Id,
                    caracteristique.Definition.ToString(),
                    caracteristique.Nom,
                    caracteristique.Type.ToString(),
                    caracteristique.Valeur);
            }

            UpdateByCommandBuilder("SELECT * FROM caracteristic;", dataTableCar);
        }
        public void updateUtilisateur(List<Utilisateur> utilisateurs)
        {
            DataTable dataTableUtilisateur = new DataTable();
            dataTableUtilisateur.Columns.Add("numuser", typeof(int));
            dataTableUtilisateur.Columns.Add("nom", typeof(string));
            dataTableUtilisateur.Columns.Add("prenom", typeof(string));
            dataTableUtilisateur.Columns.Add("loginuser", typeof(string));
            dataTableUtilisateur.Columns.Add("passworduser", typeof(string));

            foreach (Utilisateur utilisateur in utilisateurs)
            {
                dataTableUtilisateur.Rows.Add(utilisateur.Id,
                    utilisateur.Nom,
                    utilisateur.Prenom,
                    utilisateur.Login,
                    utilisateur.Password);

               /* var row = dataTableUtilisateur.NewRow();
                row["numuser"] = utilisateur.Id;
                row["nom"] = utilisateur.Nom;
                row["prenom"] = utilisateur.Prenom;
                row["loginuser"] = utilisateur.Login;
                row["passworduser"] = utilisateur.Password;
                dataTableUtilisateur.Rows.Add(row);*/
            }
            UpdateByCommandBuilder("SELECT * FROM utilisateur;", dataTableUtilisateur);
        }

    }
}
