using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data.SqlTypes;

namespace prodProject
{
    public class DatabaseConnector
    {
        public string connectionString { get; set; }
        SqlConnection conn;
        private bool OpenConnection()
        {
            try
            {
                conn = new SqlConnection(connectionString);
                return true;
            }catch (Exception ex)
            {
                MessageBox.Show("Database connection error", ex.Message);
                return false;
            }
            
        }

        private bool CloseConnection()
        {
            try
            {
                conn.Close();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Clossing connection error",ex.Message);
                return false;
            }
           
        }


        //Método ejecutar una consulta en sql, se debe adaptar para la manipulación de consultas parametrizadas.

        public void ExecuteQuery(string Query)
        {
            SqlCommand cmd = new SqlCommand(Query,conn);
        }

        public SqlDataReader DataReader(string Query)
        {
            SqlCommand cmd = new SqlCommand(Query,conn);
            SqlDataReader dr = cmd.ExecuteReader();
            return dr;
        }
    }
}
