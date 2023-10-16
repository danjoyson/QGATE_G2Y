using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using Zebra.Sdk.Comm;

namespace prodProject
{
    public class DatabaseConnector
    {
        public string connectionString { get; set; }
        List<string> dataConsult = new List<string>();
        SqlConnection conn;
        public bool GetConnection()
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

        public List<string> ExecuteQuery(String dmlStatement, String attribute, String table, String condition, String value)
        {
            String queryString = "" + dmlStatement + " " + attribute + " FROM " + table + " WHERE " + condition + " = @value";
            List<string> result = new List<string>();
            try
            {

                conn.Open();
                SqlCommand cmd = new(queryString, conn);
                cmd.Parameters.Add(new SqlParameter("@value", value));  //Prevención de SQL Injection, mediante Parametrized Queries 

                SqlDataReader record = cmd.ExecuteReader();
                if (record.Read())
                {
                   
                        result.Add(record.GetInt16(1).ToString());  //idPiezaCatalog
                        result.Add(record.GetString(2));  //descripcion
                        result.Add(record.GetString(3)); //Inicio de cadena
                        result.Add(record.GetString(4)); //Fin de Cadena
                        //totalSteps = record.GetInt16(5);  Futura implementación para extraer la cantidad de pasos de revisión acorde a cada tipo de pieza
                        return result;
                }
                else
                {    
                    conn.Close();
                    return result;
                }
            }
            catch (Exception e1)
            {
                conn.Close();
                MessageBox.Show(e1.Message);
                //t.Start();
                return result;

            }
        }
        
        public SqlDataReader DataReader(string Query)
        {
            SqlCommand cmd = new SqlCommand(Query,conn);
            SqlDataReader dr = cmd.ExecuteReader();
            return dr;
        }
    }
}
