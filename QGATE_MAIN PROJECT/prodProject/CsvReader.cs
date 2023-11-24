﻿using System.Net.Mail;

//Esta clase se encarga de leer y almacenar datos de los archivos .csv
namespace prodProject
{
    internal class CsvReader
    {
        

        public CsvReader()
        {
        }

        /*
         * -------------------------------------------------------------------------------------------------------------------------------- 
         * Función para obtener y setear los datos de la BD desde un archivo CSV (IP, Puerto, Nombre de base de datos, Usuario y Contraseña; EN ESE ORDEN)
         * 1. Obtiene los textos del archivo .csv mediante un StreamReader
         * 2. Separa los datos en un arreglo
         * 2. Llama al méotodo de desencriptado para todos los datos.
         * 3. Forma la cadena de conexión con la base de datos.
         * --------------------------------------------------------------------------------------------------------------------------------
         */
        public static string SetConnectionString()
        {
            string path = Application.StartupPath + @"\csvfiles2\DatabaseSettings.csv";
            StreamReader sr;
            string connectData="";
            try
            {
                sr = new StreamReader(path);

                string separador = ";";
                string[] info = new string[5];
                string? linea=null;
                int i = 0;
                while ((linea = sr.ReadLine()) != null || i < 5)
                {
                    string[] fila = linea.Split(separador); //Parte la linea csv en un arreglo
                    info[i] = fila[1];
                    i++;
                }

                info[0] = Decryptor.Desencriptado(info[0]); // Desencriptado de la IP de Base de Datos
                info[1] = Decryptor.Desencriptado(info[1]); // Desencriptado del puerto de la Base de Datos
                info[3] = Decryptor.Desencriptado(info[3]); // Desencriptado de User ID de la Base de Datos
                info[4] = Decryptor.Desencriptado(info[4]); // Desencriptado de la contraseña de la BD

                connectData = "Data Source=" + info[0] + "," + info[1] + ";Initial Catalog=" + info[2] + "; encrypt = true; trustServerCertificate = true; User ID=" + info[3] + ";Password=" + info[4];
                sr.Close();
                return connectData;
            }
            catch (Exception e)
            {
                MessageBox.Show("Ocurrió un error al cargar los datos del archivo DatabaseSettings.csv.\n" + e.Message);
                return connectData;
            }
        }

        /*
         * --------------------------------------------------------------------------------------------------------------------------------
         * Funcion para settear la lista de distribución de los emails de notificación NOK desde el archivo csv
         * --------------------------------------------------------------------------------------------------------------------------------
         */
        public bool SetNOKRecipientsList(MailMessage mail)
        {
            string path = Application.StartupPath + @"\csvfiles2\NOKNotificationList.csv";
            StreamReader sr;
            try
            {
                sr = new StreamReader(path);

                string? linea=null;
                while ((linea = sr.ReadLine()) != null)
                {
                    mail.To.Add(linea);
                }            
                sr.Close();
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show("Ocurrió un error: " + e.Message);
                return false;
            }
        }

        /*
         * --------------------------------------------------------------------------------------------------------------------------------
         * Función para settear la lista de distribución de los emails de: notificación de bloqueo y generación de código de desbloqueo
         * --------------------------------------------------------------------------------------------------------------------------------
         */
        public bool SetBWarningRecipientsList(MailMessage mail)
        {
            string path = Application.StartupPath + @"\csvfiles2\BlockedWarningList.csv";
            StreamReader sr;
            try
            {

                using (sr = new StreamReader(path))
                {
                    string? linea;
                    while ((linea = sr.ReadLine()) != null)
                    {
                        mail.To.Add(linea);
                    }
                    sr.Close();
                    return true;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Ocurrió un error: " + e.Message);
                return false;
            }
        }

        /*
         * --------------------------------------------------------------------------------------------------------------------------------
         * Función para obtener y desencriptar la IP de la impresora del archivo .csv
         * --------------------------------------------------------------------------------------------------------------------------------
         */
        public string[] GetPrinterIP()
        {
            string path = Application.StartupPath + @"\csvfiles2\PrinterSettings.csv";
            StreamReader sr;
            try
            {
                using (sr = new StreamReader(path)) 
                { 
                string separador = ";";
                string[] info = new string[5];
                string? linea;

                linea = sr.ReadLine();
                string[] fila = linea.Split(separador); //Parte la linea csv en un arreglo
                sr.Close();

                fila[1] = Decryptor.Desencriptado(fila[1]); //Desencriptado de la IP de la base de datos
                return fila;
                }
                
            }
            catch (Exception e)
            {
                MessageBox.Show("Ocurrió un error al obtener los datos de la impresora en PrinterSettings.csv: " + e.Message);
                return null;
            }
        }

        

    }
}
