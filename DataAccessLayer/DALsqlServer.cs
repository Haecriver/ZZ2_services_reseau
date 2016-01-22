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
            this.connectionString="Data Source=(localdb)\\Projects;Initial Catalog=master;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False";
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

        public List<Jedi> testBDD()
        {
            List<Jedi> jedis = new List<Jedi>();
            DataTable jedis_en_dur = SelectByDataAdapter("SELECT * FROM jedis");
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
