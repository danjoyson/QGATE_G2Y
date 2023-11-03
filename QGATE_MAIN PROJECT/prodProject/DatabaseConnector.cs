﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using Zebra.Sdk.Comm;
using Newtonsoft.Json.Linq;
using Org.BouncyCastle.Asn1.Cms;

namespace prodProject
{
    public class DatabaseConnector
    {
        public string connectionString { get; set; }
        List<string> dataConsult = new List<string>();
        SqlConnection conn;

        public DatabaseConnector()
        {
            connectionString = CsvReader.SetConnectionString();
            connectionString = connectionString + "; Connection Timeout = 30";
            conn = new SqlConnection(connectionString);
            
        }
        public bool GetConnection()
        {
            try
            {
                conn = new SqlConnection(connectionString + "; Connection Timeout = 30");
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

        /*
        * -----------------------------------------------------------------------------------------------------------------------------------
        * Función para ingresar la pieza en la Base de Datos.
        * 1. Se forma el string de consulta (query) con los datos necesarios para la base de datos.
        * 2. Se ingresan los valores de forma parametrizada.
        * 3. Se ejecuta la consulta
        * 
        * En caso de haber alguna excepción, como incumplir algura restricción de clave primaria, se mostrará un mensaje de error en pantalla.
        * ----------------------------------------------------------------------------------------------------------------------------------- 
        */
        public void InsertaPieza(int id,string descripcion,string clave,string inicioCadena,string finCadena,string pasos,string puntoReescaneo)
        {
            try
            {
                conn.Open();
                string query = "INSERT INTO Pieza VALUES (@idPieza, @descripcion, @claveComp, @inicioCadena, @finCadena , @pasos , @puntoReescaneo);";
                SqlCommand cmd = new(query, conn);
                cmd.Parameters.AddWithValue("@idPieza", id);
                cmd.Parameters.AddWithValue("@descripcion", descripcion);
                cmd.Parameters.AddWithValue("@claveComp", clave);
                cmd.Parameters.AddWithValue("@inicioCadena", inicioCadena);
                //Se cambio el numero de inicio de subcadena de fin de cadena para que no truene cuando se meta una cadena distinta, se toma el tamaño de la cadena -2 porque se desea extraer los ultimos 2 caracteres.
                cmd.Parameters.AddWithValue("@finCadena", finCadena);
                cmd.Parameters.AddWithValue("@pasos",Int16.Parse(pasos));
                cmd.Parameters.AddWithValue("@puntoReescaneo",Int16.Parse(puntoReescaneo));
                cmd.ExecuteNonQuery(); //Ejecución de query

                MessageBox.Show("Pieza guardada correctamente en la base de datos");
                DialogResult dialog = MessageBox.Show("Recuerde agregar las imágenes de la pieza en la carpeta de la aplicación para el correcto funcionamiento del programa. Procedimiento del manual de usuario.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (SqlException sqlEx)
            {
                conn.Close();
                if (sqlEx.Number == 2627 || sqlEx.Number == 2601) //Error de duplicado de Primary Key
                {
                    conn.Close();
                    MessageBox.Show("Ocurrió un error al tratar de guardar el registro: No se pueden ingresar claves de pieza duplicadas");
                }
                else
                {
                    conn.Close();
                    MessageBox.Show("Ocurrió un error al tratar de guardar el registro: " + sqlEx.Number);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ha ocurrido un error al insertar el registro en la Base de Datos: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }

            
        }
        /*
        * ---------------------------------------------------------------------------------------------------------------------------------------
        * Función para obtener el último ID del catalogo de piezas agregado a la base de datos, en caso de no haber piezas se le otoga el ID = 1
        * ---------------------------------------------------------------------------------------------------------------------------------------
        */

        public int GetIdPieza()
        {
            int nextId = -1;
            try
            {
                conn.Open();
                String query = "SELECT MAX (idPieza) FROM Pieza;";
                SqlCommand cmd = new(query, conn);
                SqlDataReader record = cmd.ExecuteReader();

                if (record.Read())
                {
                    nextId = record.GetInt16(0) + 1;
                }
                

            }
            catch (SqlNullValueException)
            {
                //omitir excepción generada cuando no se encuentra una pieza en la DB (ingreso por primera vez, por ende idPieza = 1)
                nextId = 1;
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al tratar de abrir la Base de datos: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
            return nextId;
        }

        /*
        * --------------------------------------------------------------------------------------------------------------------------------
        *  Función de conexión al servidor de SQL y query DML INSERT INTO para ingresar un registro nuevo a la tabla Operador
        *  Recibe el dmlStatement: INSERT INTO
        *  1. Se conecta a la Base de Datos y envía la consulta de inserción formada de forma parametrizada.
        *  2. En caso de alguna excepción, muestra un mensaje en pantalla.
        *  --------------------------------------------------------------------------------------------------------------------------------
        */
        public void InsertaOperador(string numOperador,string nombre,string apellido)
        {
            try
            {
                try
                {
                    conn.Open();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }


                string query = "INSERT INTO Operador VALUES(@numOperador, @nombre, @apellido);";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.Add(new SqlParameter("@numOperador", numOperador));
                cmd.Parameters.Add(new SqlParameter("@nombre",nombre));
                cmd.Parameters.Add(new SqlParameter("@apellido", apellido));
                cmd.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("Registro guardado exitosamente");
            }
            catch (SqlException sqlEx)
            {
                conn.Close();
                if (sqlEx.Number == 2627) //Error de duplicado de Primary Key
                {
                    conn.Close();
                    MessageBox.Show("Ocurrió un error al tratar de guardar el registro: El número de Operador ya existe en la Base de Datos.");
                }
                else
                {
                    conn.Close();
                    MessageBox.Show("Ocurrió un error al tratar de guardar el registro: " + sqlEx.Number);
                }
            }
            catch (Exception ex)
            {
                conn.Close();
                MessageBox.Show("Ocurrió un error al tratar de guardar el registro: " + ex.Message);
            }
        }

        /// <summary>
        /// Vacía los registros de las piezas inspeccionadas del dia anterior 
        /// </summary>
        public void VaciarDb()
        {
            string query = "DELETE FROM Operador_Pieza WHERE fecha < DATEADD(dd,-1, GETDATE());";
            try
            {
                conn.Open();

                SqlCommand cmd = new(query,conn);
                cmd.ExecuteNonQuery();
                conn.Close();

            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.Message);
            }
        }


    /// <summary>
    ///Elimina de la tabla operador en la BD el registro con el numero especificado 
    /// </summary>
    /// <param name="numOperador"> identificador del registro a eliminar</param>
        public void EliminaOperador(string numOperador)
        {
            try
            {
                conn.Open();

                string query = "DELETE FROM Operador WHERE numOperador = @value;";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.Add(new SqlParameter("@value", numOperador));
                cmd.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("Registro eliminado exitosamente");
            }
            catch (Exception ex)
            {
                conn.Close();
                MessageBox.Show("Ocurrió un error al tratar de eliminar el registro: " + ex.Message);
            }
        }
       
        /// <summary>
        /// Elimina de la BD el registro especificado
        /// </summary>
        /// <param name="claveComp"> clave de la pieza que se eliminara</param>
        public void EliminaPieza(string claveComp)
        {
            try
            {
                conn.Open();
                string query = "DELETE FROM Pieza WHERE claveComp = @value;";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.Add(new SqlParameter("@value", claveComp.Substring(1, 3) + claveComp.Substring(5, 7)));
                cmd.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("Registro eliminado exitosamente.");
            }
            catch (Exception ex)
            {
                conn.Close();
                MessageBox.Show("Ocurrió un error al tratar de eliminar el registro: " + ex.Message);
            }
        }

        /// <summary>
        /// Inserta el registro de la pieza revisada a la base de datos
        /// </summary>
        /// <param name="numEtiqueta"> numero de Etiqueta inspeccionado</param>
        /// <param name="serial"> numero de veces que ha sido revisada esa pieza</param>
        /// <param name="numOperador">Numero de operador que reviso la pieza</param>
        /// <param name="idPieza"></param>
        /// <returns></returns>
        public bool InsertaRegInspeccion(string numEtiqueta,int serial,string numOperador,string idPieza)
        {
            String queryString;

            if (serial == 0) //Si la pieza es OK, GUARDA 11 OK'S
            {
                //queryString = "INSERT INTO Operador_Pieza VALUES(@numEtiqueta, @serial, @numOperador, @idPieza, @fecha, 'OK', 'OK', 'OK' , 'OK', 'OK', 'OK', 'OK', 'OK', 'OK', 'OK', 'OK');";
                queryString = "INSERT INTO Operador_Pieza VALUES(@numEtiqueta, @serial, @numOperador, @idPieza, @fecha";
                //Se modifica el query ya que no en todos los casos son 11 OK, depende de el numero de pasos de cada pieza, por eso se hizo dinamico.
                //Prueba temporal por guardar en la misma BD, se colocan los 11 por el numero de campos en la BD actual (Form1.numPasos-1

                for (int i = 0; i < Form1.numPasos; i++)
                {
                    queryString += ",'OK' ";
                }
                for (int i = Form1.numPasos; i < 11; i++) queryString += ", NULL";
                queryString += ");";

            }
            else //Si la pieza es NOK, guarda n NOK's a partir de donde se haya quedado el contador de slide
            {
                queryString = "INSERT INTO Operador_Pieza VALUES(@numEtiqueta, @serial, @numOperador, @idPieza, @fecha";

                for (int i = 0; i < Form1.formSlideCont - 1; i++)
                {
                    queryString += ",'OK' ";
                }

                queryString += ", 'NOK'";

                //Debe ser el limite del for Form1.numPasos, como prueba se puso 11 para validar en la bd
                for (int j = Form1.formSlideCont + 1; j <= 11; j++)
                {
                    queryString += ", NULL";
                }

                queryString += ");";
            }


            try
            {
                conn.Open();
                SqlCommand cmd = new(queryString, conn);
                cmd.Parameters.AddWithValue("@numEtiqueta",numEtiqueta);
                cmd.Parameters.AddWithValue("@serial", serial);
                cmd.Parameters.AddWithValue("@numOperador", numOperador);
                cmd.Parameters.AddWithValue("@idPieza", idPieza);
                String formatDateTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"); //Fecha y Hora actuales con formato adecuado para SQL server
                cmd.Parameters.AddWithValue("@fecha", formatDateTime);

                cmd.ExecuteNonQuery(); //Ejecuta la consulta de inserción.
                Form1.conn.Close();

                return true;
            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.Message, "Error insertando operador-pieza a la bd");
                return false;
            }
        }

        /// <summary>
        /// Devuelve el tiempo restante para volver a 
        /// inspeccionar una pieza previamente revisada
        /// </summary>
        /// <returns> Tiempo restante</returns>
        public DateTime ChecaReingresoPieza()
        {
            DateTime actual = DateTime.Now;
            return actual;
        }
        public SqlDataReader DataReader(string Query)
        {
            SqlCommand cmd = new SqlCommand(Query,conn);
            SqlDataReader dr = cmd.ExecuteReader();
            return dr;
        }
    }
}
