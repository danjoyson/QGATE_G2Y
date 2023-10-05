using System.Diagnostics;

namespace prodProject
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

            //Prevención de múltiples ejecuciones de instancia
            String thisprocessname = Process.GetCurrentProcess().ProcessName;

            if (Process.GetProcesses().Count(p => p.ProcessName == thisprocessname) > 1) //Si ya hay una instancia abierta
            {
                DialogResult result = MessageBox.Show("La aplicación ya está abierta. ¿Quiere cerrarla y abrir una nueva?", "AVISO", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                
                if(result == DialogResult.Yes)
                {
                    
                    Process current = Process.GetCurrentProcess(); //Obtiene el proceso actual                    
                    Process[] processes = Process.GetProcessesByName(current.ProcessName); //Obtiene todos los procesos con el mismo nombre

                    foreach (Process process in processes) //Para cada proceso en el arreglo...
                    {
                        if (process.Id != current.Id)
                        {
                            process.Kill(); //Cierra el proceso cuando sea distinto al actual
                        }
                    }

                    ApplicationConfiguration.Initialize();
                    //Prueba para verificacion de formularios, el formulario de inicio es form1
                    Application.Run(new menuMobisys());
                }
                else
                {
                    return;
                }
            }
            else //Si no hay más aplicaciones abiertas
            {
                ApplicationConfiguration.Initialize();
                Application.Run(new menuMobisys());
            }

        }
    }
}