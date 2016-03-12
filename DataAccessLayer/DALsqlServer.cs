using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;
using EntitiesLayer;
using System.IO;

namespace DataAccessLayer
{
    class DALSqlServer : IDAL
    {
        protected string connectionString;

        public DALSqlServer()
        {
               /*connectionString = "Data Source=(LocalDB)\\v11.0;" +
                //  "Data Source=(LocalDB)\\MSSQLLocalDB; "+
                 "AttachDbFilename= " + Path.GetDirectoryName(Path.GetDirectoryName(Path.GetDirectoryName(System.Environment.CurrentDirectory))) +
                  "\\BaseDeDonnees\\bdd_jedi_tournament_new.mdf;" +
                //  "\\BaseDeDonnees\\bdd_jedi_tournament_localDBv11.mdf;" +
                 "Integrated Security=True;" +
                 "Connect Timeout=30";*/
            //connectionString = "Data Source=(LocalDB)\\v11.0;AttachDbFilename=C:\\Users\\pichevalie1\\Source\\Repos\\ZZ2_services_reseau_WebServices2\\BaseDeDonnees\\bdd_jedi_tournament_new.mdf;Integrated Security=True;Connect Timeout=30";
            connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Pierre\\Documents\\GitHub\\ZZ2_services_reseau_WebServices\\BaseDeDonnees\\bdd_jedi_tournament_localDBv11.mdf;Integrated Security=True;Connect Timeout=30";
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
                DataTable caracts_en_dur = SelectByDataAdapter("SELECT * FROM caracteristic,link_stade_caracteristic" +
                                                               " WHERE caracteristic.numcaract = link_stade_caracteristic.numcaracteristic" +
                                                               " AND link_stade_caracteristic.numcaracteristic =" + jediId + ";");
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
                DataTable caracts_en_dur = SelectByDataAdapter("SELECT * FROM caracteristic,link_stade_caracteristic" +
                                                               " WHERE caracteristic.numcaract = link_stade_caracteristic.numcaracteristic" +
                                                               " AND link_stade_caracteristic.numstade =" + stadeId + ";");
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
                DataTable caracts_en_dur = SelectByDataAdapter("SELECT * FROM caracteristic,link_stade_caracteristic" +
                                                               " WHERE caracteristic.numcaract = link_stade_caracteristic.numcaracteristic" +
                                                               " AND link_stade_caracteristic.numstade =" + stadeId + ";");
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
                Console.WriteLine("dalmanager " + ((string)row.ItemArray.ElementAt(4)));
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


        public void updateJedi(List<Jedi> _jedis)
        {
            List<Jedi> jedis = new List<Jedi>(_jedis);
            DataTable dataTableJedi = SelectByDataAdapter("SELECT * FROM jedi;");
            DataTable dataTableCarToUpdate = new DataTable();

            foreach (DataRow row in dataTableJedi.Rows)
            {
                Jedi jedi = jedis.Find(x => x.Id == row.Field<int>("numjedi"));
                
                if (jedi != null)
                {
                    DataTable dataTableCar = SelectByDataAdapter("SELECT * FROM link_jedi_caracteristic " +
                                                                   "WHERE link_jedi_caracteristic.numjedi =" + jedi.Id + ";");
                    List<Caracteristique> caracts = new List<Caracteristique>(jedi.Caracteristiques);

                    //Update
                    row.SetField("nom", jedi.Nom);
                    row.SetField("sith", jedi.IsSith);
                    
                    //Gestion des caracteristiques
                    foreach(DataRow rowCar in dataTableCar.Rows)
                    {
                        Caracteristique car = caracts.Find(x => x.Id == rowCar.Field<int>("numcaracteristic"));                        
                        
                        if(car != null)
                        {
                            //Update
                            //Rien a faire
                            caracts.Remove(car);
                        }
                        else
                        {
                            //Delete
                            rowCar.Delete();
                        }
                       
                    }
                    foreach (Caracteristique car in caracts)
                    {
                        //Add
                        dataTableCar.Rows.Add(jedi.Id, car.Id);
                    }

                    dataTableCarToUpdate.Merge(dataTableCar);
                    jedis.Remove(jedi);

                }
                else
                {
                    //Delete
                    row.Delete();

                    //Les caracteristiques sont alors supprimees en cascade
                }
                
            }
            //Ajout
            foreach (Jedi jedi in jedis)
            {
                DataTable dataTableCar = SelectByDataAdapter("SELECT * FROM link_jedi_caracteristic " +
                                                              "WHERE link_jedi_caracteristic.numjedi =" + jedi.Id + ";");
                dataTableJedi.Rows.Add(jedi.Id, 
                    jedi.Nom, 
                    jedi.IsSith);
                foreach (Caracteristique c in jedi.Caracteristiques)
                {
                    dataTableCar.Rows.Add(jedi.Id, c.Id);
                }
                dataTableCarToUpdate.Merge(dataTableCar);
            }

            UpdateByCommandBuilder("SELECT * FROM jedi;", dataTableJedi);
            UpdateByCommandBuilder("SELECT * FROM link_jedi_caracteristic;", dataTableCarToUpdate);
        }

        public void updateMatch(List<Match> _matches)
        {
            List<Match> matches = new List<Match>(_matches);
            DataTable dataTableMatch = SelectByDataAdapter("SELECT * FROM match;");

            foreach (DataRow row in dataTableMatch.Rows)
            {
                Match match = matches.Find(x => x.Id == row.Field<int>("nummatch"));
                if (match != null)
                {
                    //Update
                    row.SetField("numjedi1", match.Jedi1.Id);
                    row.SetField("numjedi2", match.Jedi2.Id);
                    row.SetField("phase", match.PhaseTournoi.ToString());
                    row.SetField("numstade", match.Stade.Id);
                    matches.Remove(match);
                }
                else
                {
                    //Delete
                    row.Delete();
                }
            }
            //Ajout
            foreach (Match match in matches)
            {
                dataTableMatch.Rows.Add(match.Id,
                     match.Jedi1.Id,
                     match.Jedi2.Id,
                     match.PhaseTournoi.ToString(),
                     match.Stade.Id);
            }

            UpdateByCommandBuilder("SELECT * FROM match;", dataTableMatch);

        }

        public void updateStade(List<Stade> _stades)
        {
            List<Stade> stades = new List<Stade>(_stades);
            DataTable dataTableStade = SelectByDataAdapter("SELECT * FROM stade;");
            DataTable dataTableCarToUpdate = new DataTable();

            foreach (DataRow row in dataTableStade.Rows)
            {
                Stade stade = stades.Find(x => x.Id == row.Field<int>("numstade"));

                if (stade != null)
                {
                    DataTable dataTableCar = SelectByDataAdapter("SELECT * FROM link_stade_caracteristic " +
                                                                   "WHERE link_stade_caracteristic.numstade =" + stade.Id + ";");
                    List<Caracteristique> caracts = new List<Caracteristique>(stade.Caracteristiques);

                    //Update
                    row.SetField("nbplace", stade.NbPlaces);
                    row.SetField("planete", stade.Planete);

                    //Gestion des caracteristiques
                    foreach (DataRow rowCar in dataTableCar.Rows)
                    {
                        Caracteristique car = caracts.Find(x => x.Id == rowCar.Field<int>("numcaracteristic"));

                        if (car != null)
                        {
                            //Update
                            //Rien a faire
                            caracts.Remove(car);
                        }
                        else
                        {
                            //Delete
                            rowCar.Delete();
                        }

                    }
                    foreach (Caracteristique car in caracts)
                    {
                        //Add
                        dataTableCar.Rows.Add(stade.Id, car.Id);
                    }

                    dataTableCarToUpdate.Merge(dataTableCar);
                    stades.Remove(stade);

                }
                else
                {
                    //Delete
                    row.Delete();

                    //Les caracteristiques sont alors supprimees en cascade
                }

            }
            //Ajout
            foreach (Stade stade in stades)
            {
                DataTable dataTableCar = SelectByDataAdapter("SELECT * FROM link_stade_caracteristic " +
                                                              "WHERE link_stade_caracteristic.numstade =" + stade.Id + ";");
                dataTableStade.Rows.Add(stade.Id,
                    stade.NbPlaces,
                    stade.Planete);
                foreach (Caracteristique c in stade.Caracteristiques)
                {
                    dataTableCar.Rows.Add(stade.Id, c.Id);
                }
                dataTableCarToUpdate.Merge(dataTableCar);
            }

            UpdateByCommandBuilder("SELECT * FROM stade;", dataTableStade);
            UpdateByCommandBuilder("SELECT * FROM link_stade_caracteristic;", dataTableCarToUpdate);
        }

        public void updateCaracteristique(List<Caracteristique> _caracteristiques)
        {
            List<Caracteristique> caracteristiques = new List<Caracteristique>(_caracteristiques);
            DataTable dataTableCar = SelectByDataAdapter("SELECT * FROM caracteristic;");

            foreach (DataRow row in dataTableCar.Rows)
            {
                Caracteristique caracteristique = caracteristiques.Find(x => x.Id == row.Field<int>("numcaract"));
                if (caracteristique != null)
                {
                    //Update
                    row.SetField("def", caracteristique.Definition.ToString());
                    row.SetField("nom", caracteristique.Nom);
                    row.SetField("typecar", caracteristique.Type.ToString());
                    row.SetField("valeur", caracteristique.Valeur);
                    caracteristiques.Remove(caracteristique);
                }
                else
                {
                    //Delete
                    row.Delete();
                }
            }
            //Ajout
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

        public void updateUtilisateur(List<Utilisateur> _utilisateurs)
        {
            List<Utilisateur> utilisateurs = new List<Utilisateur>(_utilisateurs);
            DataTable dataTableUtilisateur = SelectByDataAdapter("SELECT * FROM utilisateur;");

            foreach (DataRow row in dataTableUtilisateur.Rows)
            {
                Utilisateur utilisateur = utilisateurs.Find(x => x.Id == row.Field<int>("numuser"));
                if (utilisateur != null)
                {
                    //Update
                    row.SetField("loginuser", utilisateur.Login);
                    row.SetField("nom", utilisateur.Nom);
                    row.SetField("prenom", utilisateur.Prenom);
                    row.SetField("passworduser", utilisateur.Password);
                    utilisateurs.Remove(utilisateur);
                }
                else
                {
                    //Delete
                    row.Delete();
                }
            }
            //Ajout
            foreach (Utilisateur utilisateur in utilisateurs)
            {
                dataTableUtilisateur.Rows.Add(utilisateur.Id,
                   utilisateur.Nom,
                   utilisateur.Prenom,
                   utilisateur.Login,
                   utilisateur.Password);
            }
            UpdateByCommandBuilder("SELECT * FROM utilisateur;", dataTableUtilisateur);
        }
    }
}
