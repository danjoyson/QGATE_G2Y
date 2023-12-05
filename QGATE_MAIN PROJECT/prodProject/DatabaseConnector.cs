using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using Zebra.Sdk.Comm;
using Newtonsoft.Json.Linq;
using Org.BouncyCastle.Asn1.Cms;
using System.Drawing.Text;

namespace prodProject
{
    public class DatabaseConnector
    {
        public string connectionString { get; set; }
        List<string> dataConsult = new List<string>();
        SqlConnection conn;
        Pieza p = new Pieza();
        public DatabaseConnector()
        {
            connectionString = CsvReader.SetConnectionString();
            connectionString = connectionString + "; Connection Timeout = 30";
            conn = new SqlConnection(connectionString);
            
        }

        /// <summary>
        /// Inserta pieza registrada a la BD
        /// </summary>
        /// <param name="pz">Objeto tipo pieza</param>
        public void InsertaPieza(Pieza pz)
        {
            try
            {
                conn.Open();
                string query = "INSERT INTO Pieza VALUES (@idPieza, @descripcion, @claveComp, @inicioCadena, @finCadena , @pasos , @puntoReescaneo);";
                SqlCommand cmd = new(query, conn);
                cmd.Parameters.AddWithValue("@idPieza", pz.id);
                cmd.Parameters.AddWithValue("@descripcion", pz.descripcion);
                cmd.Parameters.AddWithValue("@claveComp", pz.claveComp);
                cmd.Parameters.AddWithValue("@inicioCadena", pz.inicioCadena);
                cmd.Parameters.AddWithValue("@finCadena", pz.finCadena);
                cmd.Parameters.AddWithValue("@pasos",pz.pasos);
                cmd.Parameters.AddWithValue("@puntoReescaneo",pz.puntoReescaneo);
                cmd.ExecuteNonQuery(); 

                MessageBox.Show("Pieza guardada correctamente en la base de datos");
                
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

        /// <summary>
        /// Busca el ultimo id de pieza registrado en la BD
        /// </summary>
        /// <returns>Máximo Id de pieza </returns>

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

        /// <summary>
        /// Inserta registro de operador a la BD
        /// </summary>
        /// <param name="operador">Objeto tipo operador</param>
        public void InsertaOperador(Operador operador)
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
                cmd.Parameters.Add(new SqlParameter("@numOperador", operador.numOperador));
                cmd.Parameters.Add(new SqlParameter("@nombre",operador.nombre));
                cmd.Parameters.Add(new SqlParameter("@apellido", operador.apellido));
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
                cmd.Parameters.Add(new SqlParameter("@value", claveComp.Substring(2, 7)));
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
        public bool InsertaRegInspeccion(string queryString,string numEtiqueta,int serial,int numOperador,int idPieza)
        {
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
                conn.Close();

                return true;
            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.Message, "Error insertando operador-pieza a la bd");
                return false;
            }
        }

        /// <summary>
        /// Verifica si una pieza ya fue ingresada previamente.
        /// </summary>
        /// <param name="etiqueta"> Etiqueta de pieza ingresada</param>
        /// <returns>Retorna el tiempo restante para volver a ingresar la pieza</returns>
        public DateTime CheckReingreso(string etiqueta)
        {
            String queryString = "SELECT MAX(fecha) FROM Operador_Pieza WHERE numEtiqueta = @value";
            DateTime dateRead=DateTime.Now;
            try
            {
                conn.Open();
                SqlCommand cmd = new(queryString, conn);
                cmd.Parameters.Add(new SqlParameter("@value", etiqueta));  //Prevención de SQL Injection, mediante consultas parametrizadas 
                SqlDataReader record = cmd.ExecuteReader();
                if (record.Read())
                {
                    dateRead = record.GetDateTime(0);       //Fecha y hora del último NOK de la pieza
                    conn.Close();
                    return dateRead;
                }
                conn.Close();
                return dateRead;
            }
            catch (Exception e)
            {
                conn.Close();
                MessageBox.Show(e.Message,"Error al verificar tiempo de reingreso");
                return dateRead;
            }

        }

        /// <summary>
        /// Identifica el serial de la pieza y genera uno nuevo incrementando en 1
        /// </summary>
        /// <param name="etiqueta"></param>
        /// <returns></returns>
        public int GenerateDBSerial(string etiqueta)
        {
            String query = "SELECT MAX(serial) FROM Operador_Pieza WHERE numEtiqueta = '" + etiqueta + "';";
            int serial=0;
            try
            {
                conn.Open();

                SqlCommand cmd = new(query, conn);
                SqlDataReader record = cmd.ExecuteReader();
                if (record.Read())
                {
                    serial = record.GetInt16(0) + 1;
                    conn.Close();
                    return serial;
                }
                return serial;
            }
            catch (SqlNullValueException)
            {
                serial = 1;
                return serial;
            }
            catch (Exception e1)
            {

                MessageBox.Show("Error generando serial :", e1.Message);
                serial = -2;
                return serial;
            }
            finally
            {
                conn.Close();
            }

        }

        /// <summary>
        /// Verifica que el status de la pieza ingresadan si ya a sido validada previamente
        /// </summary>
        /// <returns>Status serial de pieza 0 pieza liberada, 1 pieza ya revisada con error, -1 pieza no revisada previamente,-2 error en la consulta a bd</returns>
        public int CheckNotSerialZero(string etiqueta)
        {
            String queryString = "SELECT MIN(serial) FROM Operador_Pieza WHERE numEtiqueta = @value";
            try
            {
                conn.Open();
                SqlCommand cmd = new(queryString, conn);
                cmd.Parameters.Add(new SqlParameter("@value", etiqueta));  //Prevención de SQL Injection, mediante Parametrized Queries 
                SqlDataReader record = cmd.ExecuteReader();
                if (record.Read())
                {
                    if (record.GetInt16(0) == 0)
                    {
                        return 0;
                    }
                }
                conn.Close();
                return 1; //Llama a la función para revisar el tiempo de reingreso de la pieza

            }
            catch (SqlNullValueException)
            {
                conn.Close();
                return -1;
            }

            catch (Exception e)
            {
                conn.Close();
                MessageBox.Show(e.Message);
                return -2;
            }

        }

        /// <summary>
        /// Obtiene los datos de variante de la pieza espeficada
        /// </summary>
        /// <returns>Devuelve los datos de la pieza revisada si existe.</returns>
        public Pieza? GetPiezaInfo(String value)
        {
            String queryString = "" + "SELECT" + " " + "claveComp, idPieza, descripcion, inicioCadena, finCadena, pasos, puntoReescaneo" + " FROM " + "Pieza" + " WHERE " + "claveComp" + " = @value";

            try
            {
                conn.Open();
                SqlCommand cmd = new(queryString, conn);
                cmd.Parameters.Add(new SqlParameter("@value", value));  //Prevención de SQL Injection, mediante Parametrized Queries 

                SqlDataReader record = cmd.ExecuteReader();
                if (record.Read())
                {                   
                        p.claveComp = record.GetString(0);
                        p.id = record.GetInt16(1);
                        p.descripcion = record.GetString(2);
                        p.inicioCadena = record.GetString(3);
                        p.finCadena = record.GetString(4);
                        p.pasos = record.GetInt16(5);
                        p.puntoReescaneo = record.GetInt16(6);
                    conn.Close();
                    return p;
                }
                else
                {
                    conn.Close();
                    return null;
                }
            }
            catch (Exception e1)
            {
                conn.Close();
                MessageBox.Show(e1.Message);
                return null;
            }
        }

        /// <summary>
        /// Verifica que el numero de operador especificado exista en la BD
        /// </summary>
        /// <returns>True si encuentra el operador en la BD</returns>
        public bool CheckOperador(String value)
        {
            String queryString = "" + "SELECT" + " " + "numOperador" + " FROM " + "Operador" + " WHERE " + "numOperador" + " = @value";

            try
            {
                conn.Open();
                SqlCommand cmd = new(queryString, conn);
                cmd.Parameters.Add(new SqlParameter("@value", value));

                SqlDataReader record = cmd.ExecuteReader();
                if (record.Read())
                {
                    conn.Close();
                    return true; //Significa que el operador exite en la bd y se debe bloquear en pantalla para usarlo por un lapso de tiempo
                }
                else
                {
                    conn.Close();
                    return false;//Significa que no se encontro el operador en la bd
                }
            }
            catch (Exception e1)
            {
                conn.Close();
                MessageBox.Show(e1.Message);
                return false;
            }
        }
    }
}
