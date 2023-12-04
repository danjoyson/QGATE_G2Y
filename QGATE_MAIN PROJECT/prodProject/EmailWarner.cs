using DataSecurity;
using System.Net;
using System.Net.Mail;

//Clase de envío automático de correos electrónicos
namespace prodProject
{
    internal class EmailWarner
    {
        private string emailSenderAddress;
        private string? emailSenderPassword;
        Encryption decryptor = new Encryption();
        public EmailWarner()
        {
            getEmailSettings(); //Obtener cuenta y contraseña del enviador de correos (Desde el archivo de configuración)
        }

        /// <summary>
        /// Envia correo de NOK a los correos especificados en la lista
        /// </summary>
        /// <returns></returns>
        public async Task SendNOKWarning()
        {
            try
            {
                SmtpClient client = new SmtpClient("smtp.office365.com");


                MailMessage mail = new MailMessage();
                mail.From = new MailAddress(this.emailSenderAddress);

                CsvReader cr = new();
                if (cr.SetNOKRecipientsList(mail)) //Agrega las direcciones de correo a donde se enviarán las notificaciones
                {
                    mail.Subject = "Aviso: Pieza NOK / QMX Digital Q-Gate System";

                    String formatDateTime = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"); //Fecha y hora actuales            
                    mail.Body = formatDateTime + "\nLa pieza " + Form1.etiqueta + "\nDescripción: " + Form1.descripcion
                        + "\nHa fallado en el punto de inspección No. " + Form1.formSlideCont +
                        " \nFavor de acudir al área correspondiente y contactar al supervisor en turno para más detalles. Gracias. \nDigital Q-Gate System / JQMX";


                    client.Port = 587; //Puerto indicado por la página de Outlook
                    client.Credentials = new NetworkCredential(this.emailSenderAddress, this.emailSenderPassword);
                    client.EnableSsl = true;

                    await client.SendMailAsync(mail); //Envío asíncrono, para no congelar la aplicación mientras se envía la notificación
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Ocurrió un error al enviar el e-mail: " + e.Message);
            }
        }


        /// <summary>
        /// Envia un correo a la administración del sistema con el código de desbloqueo de la aplicación
        /// </summary>
        /// <param name="randomCode">Código de desbloqueo que se enviará por mail</param>
        /// <returns></returns>
        public bool SendBlockedWarning(string randomCode)
        {
            try
            {
                SmtpClient client = new SmtpClient("smtp.office365.com");


                MailMessage mail = new MailMessage();
                mail.From = new MailAddress(this.emailSenderAddress);

                CsvReader cr = new();
                if (cr.SetBWarningRecipientsList(mail))
                {
                    mail.Priority = MailPriority.High;
                    mail.Subject = " BLOQUEO NOK / QMX Digital Q-Gate System G2Y";

                    String formatDateTime = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"); //Fecha y hora actuales

                    mail.Body = "\nCódigo de desbloqueo: " + randomCode 
                    + "\n\nLa misma pieza ha generado 3 NOK \nPieza: " + Form1.etiqueta + "\nDescripción: " + Form1.descripcion
                    + "\n\nHa fallado en el punto de inspección No. " + Form1.formSlideCont +
                    " \nFavor de asegurarse de desbloquear la máquina. Gracias. " +
                    "\nDigital Q-Gate System / JQMX " + formatDateTime;

                    client.Port = 587; //Puerto default de Outlook
                    client.Credentials = new NetworkCredential(this.emailSenderAddress, this.emailSenderPassword);
                    client.EnableSsl = true;
                    client.Send(mail);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return false;
            }
        }

        /// <summary>
        /// Genera código aleatorio para desbloqueo de aplicación.
        /// </summary>
        /// <returns></returns>
        public string GenerateRandomUnblockCode()
        {
            var seed = Environment.TickCount;
            var random = new Random(seed);
            string randomCode = random.Next(0, 9).ToString();
            for (int i = 0; i < 3; i++)
            {
                randomCode += random.Next(0, 9).ToString();
            }

            return randomCode;
        }

        /// <summary>
        /// Obtiene los datos de la cuenta emisora de mails
        /// </summary>
        /// <returns></returns>
        private bool getEmailSettings()
        {
            string startup = Application.StartupPath;
            string path = startup + @"\csvfiles2\EmailSettings.csv";
            StreamReader sr;
            try
            {
                sr = new StreamReader(path);

                string separador = ";";
                string[] info = new string[2];
                string? linea;
                int i = 0;
                while ((linea = sr.ReadLine()) != null || i < 2)
                {
                    string[] fila = linea.Split(separador); //Parte la linea csv en un arreglo, donde 0 els el nombre de la fila y 1 es el índice de la información
                    info[i] = fila[1];
                    i++;
                }

                this.emailSenderAddress = decryptor.Desencriptado(info[0]); //Desencriptado del email
                this.emailSenderPassword = decryptor.Desencriptado(info[1]); //Desencriptado de la contraseña


                sr.Close();
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show("Ocurrió un error al cargar los datos del archivo EmailSettings.csv.\n" + e.Message);
                return false;

            }
        }
    }
}
