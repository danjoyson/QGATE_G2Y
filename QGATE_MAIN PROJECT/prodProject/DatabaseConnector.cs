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

        /*public bool ExecuteQuery(String dmlStatement, String attribute, String table, String condition, String value)
        {
            String queryString = "" + dmlStatement + " " + attribute + " FROM " + table + " WHERE " + condition + " = @value";
            try
            {

                conn.Open();
                //MessageBox.Show("Connection Granted");
                //conn.connectionString = queryString;
                SqlCommand cmd = new(queryString, conn);
                cmd.Parameters.Add(new SqlParameter("@value", value));  //Prevención de SQL Injection, mediante Parametrized Queries 

                SqlDataReader record = cmd.ExecuteReader();
                if (record.Read())
                {
                    if (attribute.Equals("claveComp, idPieza, descripcion, inicioCadena, finCadena"))
                    {
                        idPiezaCatalog = record.GetInt16(1);
                        descripcion = record.GetString(2);
                        inicioDeCadena = record.GetString(3);
                        finDeCadena = record.GetString(4);
                        //totalSteps = record.GetInt16(5);  Futura implementación para extraer la cantidad de pasos de revisión acorde a cada tipo de pieza
                    }
                    else
                    {
                        BlockNumOp();
                    }
                    conn.Close();
                    return true;
                }
                else
                {

                    if (attribute.Equals("claveComp, idPieza, descripcion, inicioCadena, finCadena"))
                    {
                        messageLabel.Text = "Número de pieza no encontrado en la Base de Datos";
                        piezaTxtBox.Clear();
                        t.Start();
                        messageLabel.Location = new Point(ClientSize.Width / 2 - messageLabel.Width / 2, 311);
                    }

                    else
                    {
                        messageLabel.Text = "Número de operador no encontrado en la Base de Datos";
                        opeTxtBox.Clear();
                        t.Start();
                        messageLabel.Location = new Point(ClientSize.Width / 2 - messageLabel.Width / 2, 311);
                    }

                    conn.Close();
                    return false;
                }
            }
            catch (Exception e1)
            {
                conn.Close();
                MessageBox.Show(e1.Message);
                t.Start();
                return false;

            }
        }
        */
        public SqlDataReader DataReader(string Query)
        {
            SqlCommand cmd = new SqlCommand(Query,conn);
            SqlDataReader dr = cmd.ExecuteReader();
            return dr;
        }
    }
}
