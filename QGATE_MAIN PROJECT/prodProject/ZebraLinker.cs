using Org.BouncyCastle.Crypto.Engines;
using System.Runtime.Intrinsics.Arm;
using System.Text;
using Zebra.Sdk.Comm;    //Biblioteca directamente descargada de la página oficial de Zebra Technologies
using Zebra.Sdk.Printer; //Biblioteca directamente descargada de la página oficial de Zebra Technologies


namespace prodProject
{
    internal class ZebraLinker
    {
        private readonly string PrinterIpAddress;
        private string date;
        private Connection printerConn;

        /// <summary>
        /// Asigna la ip de la impresora y genera la instancia para la conexión
        /// </summary>
        /// <param name="printerIpAddress">Ip de la impresora</param>
        public ZebraLinker(string printerIpAddress)
        {
            PrinterIpAddress = printerIpAddress;
            this.date = DateTime.Now.ToString("dd/MM/yyyy");
            this.printerConn = new TcpConnection(PrinterIpAddress, TcpConnection.DEFAULT_ZPL_TCP_PORT);
            
        }

        /// <summary>
        /// Imprime la etiqueta de caja de la pieza
        /// </summary>
        /// <param name="etiqueta">Etiqueta de la pieza</param>
        /// <param name="descripcion">Descripcion del estandar de la pieza</param>
        /// <param name="num">Fin de cadena del estandar de pieza </param>
        /// <param name="dpi">Numero de puntos de impresión</param>
        public void PrintBoxLabelZPL(string etiqueta, string descripcion, string num, int dpi)
        {
            //Texto de la etiqueta de caja con el número de parte.
            string PieceIdentifierString = Form1.inicioDeCadena + Form1.piezaText.Substring(0,3) + "." + Form1.piezaText.Substring(3, 7) + "." + Form1.finDeCadena;
            try
            {
                printerConn.Open();
                ZebraPrinter printer = ZebraPrinterFactory.GetInstance(printerConn);
                PrinterStatus printerStatus = printer.GetCurrentStatus();
                string zplData = "";
                if(printerStatus.isReadyToPrint)
                {
                    //Codigo zpl de la etiqueta de caja
                    switch (dpi)
                    {
                        case 203:
                            zplData = "^XA^FO290,80^BQN,2,4^FDMA," + PieceIdentifierString + "^FS^FO40,25^AA,30,10^FD"+ descripcion +"^FS^FO40,60^AA,30,15^FD" + PieceIdentifierString + "^FS^FO40,100^AQ,1,1^FDPiezas: 1^FS^FO255,85^AQ,70,40^FD1^FS^FO40,150^AA,26,8^FDFECHA: " + this.date + "^FS^XZ";
                            break;

                        case 300:
                            zplData = "^XA^FO55,40^AF,1,1^FD" + descripcion + "^FS^FO55,90^AA,35,16^FD" + PieceIdentifierString + "^FS^FO55,155^AQ,1,1^FDPiezas: 1^FS^FO285,140^AQ,100,70^FD1^FS^FO55,205^AA,26,8^FDFECHA: " + this.date + "^FS^FO390,90^BQN,2,7^FDMA," + PieceIdentifierString + "^FS^XZ";
                            break;

                        default: //600 dpi
                            zplData = "^XA^FO800,200^BQN,2,10^FDMA," + PieceIdentifierString + "^FS^FO110,100^AA,50,30^FD" + descripcion + "^FS^FO110,180^AA,60,30^FD" + PieceIdentifierString + "^FS^FO110,270^AQ,80,80^FDPiezas: 1^FS^FO575,250^AQ,140,60^FD1^FS^FO110,400^AA,60,30^FDFECHA: " + this.date + "^FS^XZ";
                            break;
                    }

                    Form1.lastZPLCommand = zplData;
                    printerConn.Write(Encoding.UTF8.GetBytes(zplData));
                }
                else
                {
                    MessageBox.Show("La impresora está ocupada.");
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al imprimir:" + ex.Message);
            }
            finally
            {
                printerConn.Close();
            }

        }

        /// <summary>
        /// Imprime la etiqueta de pieza NOK
        /// </summary>
        /// <param name="dpi">Dpi de la impresora actual</param>
        /// <returns>True si realiza el proceso de impresión</returns>
        public bool printOkNokLabelZPL(int dpi)
        {
            try
            {    
                    printerConn.Open();
                    ZebraPrinter printer = ZebraPrinterFactory.GetInstance(printerConn);
                    PrinterStatus printerStatus = printer.GetCurrentStatus();
                    string zplData = "";

                    if (printerStatus.isReadyToPrint)
                    {
                        //Codigo zpl de la etiqueta NOK
                        switch (dpi)
                        {
                            case 203:
                                zplData = "^XA^FO90,45^AQ,150,150^FDNOK^FS^XZ";
                                break;

                            case 300:
                                zplData = "^XA^FO150,45^AQ,200,200^FDNOK^FS^XZ";
                                break;

                            default: //600 dpi
                                zplData = "^XA^FO440,170^AQ,300,300^FDNOK^FS^XZ";
                                break;
                        }
                        Form1.lastZPLCommand = zplData; //Guarda la última impresión realizada
                        printerConn.Write(Encoding.UTF8.GetBytes(zplData));
                    }
                    return true;
               
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                printerConn.Close();
            }
        }


        /// <summary>
        /// Obtiene el status de la impresora Zebra.
        /// </summary>
        public void GetPrinterStatus()
        {
            try
            {
                printerConn.Open();
                ZebraPrinter printer = ZebraPrinterFactory.GetInstance(printerConn);
                PrinterStatus printerStatus = printer.GetCurrentStatus();
                if (printerStatus.isReadyToPrint)
                {
                    MessageBox.Show("Ready To Print");
                    
                }
                else if (printerStatus.isPaused)
                {
                    MessageBox.Show("Cannot Print because the printer is paused.");
                }
                else if (printerStatus.isHeadOpen)
                {
                    MessageBox.Show("Cannot Print because the printer head is open.");
                }
                else if (printerStatus.isPaperOut)
                {
                    MessageBox.Show("Cannot Print because the paper is out.");
                }
                else
                {
                    MessageBox.Show("Cannot Print.");
                }
                MessageBox.Show("Largo de etiqueta en DPI: " + printerStatus.labelLengthInDots);

            }
            catch(Exception ex)
            {
                MessageBox.Show("Ocurrió un error: " + ex.Message);
            }
            finally
            {
                printerConn.Close();
            }
        }

        /// <summary>
        /// Muestra el valor de dpi de la impresora Zebra.
        /// </summary>
        public void GetLabelWidth()
        {
            try
            {
                printerConn.Open();
                var instance = ZebraPrinterFactory.GetInstance(printerConn);
                var stat = instance.GetCurrentStatus();
                var printer = ZebraPrinterFactory.CreateLinkOsPrinter(instance);

                var settings = printer.GetAllSettings();
                var pw = settings["ezpl.label_length_max"];

                MessageBox.Show(pw.Value);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error: " + ex.Message);
            }
            finally
            {
                printerConn.Close();
            }
        }

        /// <summary>
        /// Prueba de calibración de la impresora Zebra.
        /// </summary>
        public void CalibratePrinter()
        {
            try
            {
                printerConn.Open();
                ZebraPrinter printer = ZebraPrinterFactory.GetInstance(printerConn);
                printer.Calibrate();

            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                printerConn.Close();
            }
        }

        /// <summary>
        /// Imprime una etiqueta de prueba
        /// </summary>
        /// <param name="dpi">Dpi de la impresora actual</param>
        public void PrintTest(int dpi)
        {
            try
            {
                printerConn.Open();
                ZebraPrinter printer = ZebraPrinterFactory.GetInstance(printerConn);
                PrinterStatus printerStatus = printer.GetCurrentStatus();
                string zplData = null;
                if (printerStatus.isReadyToPrint)
                {
                    //Codigo zpl de la etiqueta de caja
                    switch (dpi)
                    {
                        case 203:
                            zplData = "^XA^FO290,80^BQN,2,4^FDMA,V123.4567890.12^FS^FO40,25^AA,30,10^FDAXxxxxxxxx YYY YYY YYY^FS^FO40,60^AA,30,15^FDV123.4567890.12^FS^FO40,100^AQ,1,1^FDPiezas: 1^FS ^FO255,85^AQ,70,40^FD1^FS^FO40,150^AA,26,8^FDFECHA: 23/06/2023^FS^XZ";
                            break;

                        case 300:
                            zplData = "^XA^FO55,40^AF,1,1^FDXxxxxxxxx YYY YYY YYY^FS^FO55,90^AA,35,16^FDV123.4567890.12^FS^FO55,155^AQ,1,1^FDPiezas: 1^FS^FO285,140^AQ,100,70^FD1^FS^FO55,205^AA,26,8^FDFECHA: dd/MM/AAAA^FS^FO390,90^BQN,2,7^FDMA,V123.4567890.12^FS^XZ";
                                break;

                        default: //600 dpi
                            zplData = "^XA^FO800,200^BQN,2,10^FDMA,V123.4567890.12^FS^FO110,100^AA,50,30^FDXxxxxxxxx YYY YYY YYY^FS^FO110,180^AA,60,30^FDV123.4567890.12^FS^FO110,270^AQ,80,80^FDPiezas: 1^FS^FO575,250^AQ,140,60^FD1^FS^FO110,400^AA,60,30^FDFECHA: dd/MM/AAAA^FS^XZ";
                            break;
                    }

                    printerConn.Write(Encoding.UTF8.GetBytes(zplData));
                }
                else
                {
                    MessageBox.Show("La impresora está ocupada.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al imprimir:" + ex.Message);
            }
            finally
            {
                printerConn.Close();
            }

        }

        /// <summary>
        /// Reimprime una etiqueta recibiendo el codigo zpl y el dpi
        /// </summary>
        /// <param name="dataString"></param>
        public void ReprintLabel(string dataString)
        {
            try
            {
                printerConn.Open();
                ZebraPrinter printer = ZebraPrinterFactory.GetInstance(printerConn);
                PrinterStatus printerStatus = printer.GetCurrentStatus();
                if (printerStatus.isReadyToPrint)
                {
                    printerConn.Write(Encoding.UTF8.GetBytes(dataString));
                }
                else
                {
                    MessageBox.Show("La impresora está ocupada.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al imprimir:" + ex.Message);
            }
            finally
            {
                printerConn.Close();
            }
        }
    }
}
