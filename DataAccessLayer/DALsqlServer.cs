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
            connectionString = "Data Source = (LocalDB)\\MSSQLLocalDB; AttachDbFilename = C:\\Users\\Pierre\\Documents\\GitHub\\ZZ2_services_reseau\\BaseDeDonnees\\bdd_jedi_tournament.mdf; Integrated Security = True; Connect Timeout = 30";
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
                Console.Out.WriteLine(sqlCommand.CommandText.ToString());
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
               // Console.Out.WriteLine(sqlDataAdapter.Container);
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

        public List<Jedi> testBDD()
        {
           /* List<String> liststr = SelectByDataReader("SELECT * FROM jedis;");
            Console.Out.Write(liststr[0]);*/

            List<Jedi> jedis = new List<Jedi>();
            DataTable jedis_en_dur = SelectByDataAdapter("SELECT * FROM jedis;");
            foreach (DataRow row in jedis_en_dur.Rows) // Loop over the rows.
            {
                jedis.Add(new Jedi((int)row.ItemArray.ElementAt(0),
                    (string)row.ItemArray.ElementAt(1),
                    (bool)row.ItemArray.ElementAt(2),
                    null));
            }

            return jedis;
        }
    }
}
