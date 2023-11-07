﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Security;
using System.Text;
using System.Threading.Tasks;

namespace prodProject
{
    public class Printer
    {
        public string IP { get; set; }
        public int DPI { get; set; }
        public int x { get; set; }
        public int y { get; set; }
        public string text { get; set; }
        string path = Application.StartupPath + @"\csvfilestest\PrinterSettings.csv";
        public Printer() { }

        public void WriteConfig(Printer p)
        {

        }

        public bool SaveConfig()
        {
            StreamWriter csvStream;
            IP = Encryptor.Encriptado(IP.ToString());
            try
            {
                using (csvStream = new StreamWriter(path))
                {
                    csvStream.WriteLine("Zebra IP" + ";"+IP+ ";" + DPI.ToString() + ";" + text);
                }
                csvStream.Close();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public Printer GetConfig()
        {
            Printer actual = new Printer();
            StreamReader sr;
            try
            {
                sr = new StreamReader(path);

                string separador = ";";
                string[] info = new string[5];
                string? linea;

                linea = sr.ReadLine();
                string[] fila = linea.Split(separador); //Parte la linea csv en un arreglo
                sr.Close();

                actual.IP = Decryptor.Desencriptado(fila[1]); //Desencriptado de la IP de la base de datos
                //actual.IP = fila[1];
                actual.DPI = Convert.ToInt32(fila[2]);
                //actual.x = Convert.ToInt32(fila[3]);
                //actual.y = Convert.ToInt32(fila[4]);
                actual.text = fila[3];
                return actual;
            }
            catch (Exception e)
            {
                MessageBox.Show("Ocurrió un error al obtener los datos de la impresora en PrinterSettings.csv: " + e.Message);
                return null;
            }
        }
    }
}