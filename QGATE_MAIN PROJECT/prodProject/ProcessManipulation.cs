using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Diagnostics;

namespace prodProject
{
    public class ProcessManipulation
    {
        //Driver necesario para acceder a los procesos del sistema
        [DllImport("user32.dll")]
        static extern bool SetForegroundWindow(IntPtr hWnd);
        private delegate bool EnumWindowsProc(IntPtr hWnd, IntPtr lParam);
        [DllImport("user32.dll")]
        private static extern bool EnumWindows(EnumWindowsProc enumProc, IntPtr lParam);

        [DllImport("user32.dll")]
        private static extern int GetWindowThreadProcessId(IntPtr hWnd, out int lpdwProcessId);
        public string currentProcess="";
        public string porcName = "MobisysClient100";
        private string mobisysProcessName = "MobisysClient100"; //Variable nombre de proceso que debe ser superpuesto al completar una revision de pieza
        private System.Timers.Timer scanMobisysTimer = new(60000);
        private System.Timers.Timer copyPasteTimer = new(3500);
        
        private const int SW_HIDE = 0;
        private const int SW_SHOW = 5;
        [DllImport("User32")]
        private static extern int ShowWindow(int hwnd, int nCmdShow);
        [DllImport("user32.dll")]
        public static extern void mouse_event(uint dwFlags, int dx, int dy, uint dwData, IntPtr dwExtraInfo);

        private const int MOUSEEVENTF_LEFTDOWN = 0x02;
        private const int MOUSEEVENTF_LEFTUP = 0x04;
        private const int RIGHTDOWN = 0x00000008;
        private const int RIGHTUP = 0x00000010;
        
        public ProcessManipulation()
        {
            
        }
        /// <summary>
        /// Devuelve el ID del proceso con el nombre especificado
        /// </summary>
        /// <param name="procName">Nombre del proceso</param>
        /// <returns></returns>
        public int GetProcessID(string procName)
        {
            int processID = -1; // Valor predeterminado en caso de que no se encuentre el proceso

            Process[] processes = Process.GetProcessesByName(procName);

            if (processes.Length > 0)
            {
                // Obtiene el PID del primer proceso con el nombre especificado
                processID = processes[0].Id;
            }
            else
            {
                Console.WriteLine($"No se encontró el proceso con nombre '{procName}'.");
            }

            return processID;
        }

        /// <summary>
        /// Coloca como ventana principal el proceso con el id especificado
        /// </summary>
        /// <param name="targetPID">id del programa a cambiar</param>
        public static void BringWindowToFrontByPID(int targetPID)
        {
            IntPtr targetWindowHandle = IntPtr.Zero;

            EnumWindows((hWnd, lParam) =>
            {
                int windowPID;
                GetWindowThreadProcessId(hWnd, out windowPID);

                if (windowPID == targetPID)
                {
                    targetWindowHandle = hWnd;
                    return false; // Detener la enumeración
                }

                return true; // Continuar enumerando
            }, IntPtr.Zero);

            if (targetWindowHandle != IntPtr.Zero)
            {
                SetForegroundWindow(targetWindowHandle);
            }
            else
            {
                MessageBox.Show($"No se encontró ninguna ventana para el proceso con PID {targetPID}.");
            }
        }

        /// <summary>
        /// Coloca como ventana principal el programa espeficiado
        /// </summary>
        /// <param name="procName">Nombre del programa que se desea colocar como principal</param>
        /// <returns></returns>
        public bool SuperposePid(string procName)
        {
            int targetProcessPID = -1;
            targetProcessPID = GetProcessID(procName);
            if (targetProcessPID != -1)
            {
                BringWindowToFrontByPID(targetProcessPID);
                return true;
            }
            else
            {
               
                return false;
            }
        }

        /// <summary>
        /// Coloca como ventana principal del sistema el programa quespecifica
        /// </summary>
        /// <param name="procName">Nombre del programa que se colocara como principal</param>
        public void SuperposeProgram(string procName)
        {
            string processName = procName;
            // Buscar el proceso por nombre
            Process[] processes = Process.GetProcessesByName(processName);

            if (processes.Length > 0)
            {
                // Obtener el identificador de la ventana principal del primer proceso encontrado
                IntPtr windowHandle = processes[0].MainWindowHandle;

                if (windowHandle != IntPtr.Zero)
                {

                    // Traer la ventana de Microsoft Teams al frente
                    SetForegroundWindow(windowHandle);
                }
                else
                {
                    MessageBox.Show($"La ventana principal de {processName} no se encontró.");
                }
            }
            else
            {
                MessageBox.Show($"{processName} no está en ejecución.");
            }
        }

        //Extrae el ID del proceso que se esta ejecutando actualmente (Mobisys)
        public string GetCurrentProcessName()
        {
            Process procesoActual = Process.GetCurrentProcess();
            // Obtener el nombre del proceso
            string nombreDelProceso = procesoActual.ProcessName;
            currentProcess = nombreDelProceso;
            //MessageBox.Show("Nombre del proceso actual: " + nombreDelProceso);

            return currentProcess;

        }

        /*Método para realizar la superoposición de Mobisys despues de revisar una pieza.
        y pegar el texto del portapapeles*/
        public bool AddToMobisys(string text)
        {
            bool processResult=false;
            try
            {
                //if(Form1.conatadorPiezas==Form1.estandar)
                currentProcess = GetCurrentProcessName();
                CopyToClipboard(text);
                //SuperposePid(mobisysProcessName);
                processResult = SuperposePid(mobisysProcessName);
                if (processResult)
                {
                    System.Threading.Thread.Sleep(2000);
                    PasteFromClipboard();
                    System.Threading.Thread.Sleep(3000);
                    SuperposeProgram(currentProcess);
                    return true;
                }
                else return false;



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al mostrar mobisys");
                return false;
            }
        }
       
        /// <summary>
        /// Oculta la ventana del proceso actual para realizar la inserción de la etiqueta dentro de mobisys
        /// </summary>
        /// <param name="text"> Valor de la etiqueta actual que se insertará en mobisys</param>
        /// <returns></returns>
        public bool HideShowProcess(string text)
        {
            try
            {
                CopyToClipboard(text);
                System.Threading.Thread.Sleep(400);
                Process p = Process.GetCurrentProcess();
                int hWnd;
                hWnd = p.MainWindowHandle.ToInt32();
                ShowWindow(hWnd, SW_HIDE);
                System.Threading.Thread.Sleep(300);
                Cursor.Position = new System.Drawing.Point(850, 300);
                mouse_event(MOUSEEVENTF_LEFTDOWN, 850, 300, 0, IntPtr.Zero);
                Thread.Sleep(300);
                mouse_event(MOUSEEVENTF_LEFTUP, 850, 300, 0, IntPtr.Zero);
                Thread.Sleep(300);
                PasteFromClipboard();
                System.Threading.Thread.Sleep(2500);
                ShowWindow(hWnd, SW_SHOW);
                return true;
            }catch(Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Copia en el clipboard del sistema el texto especificado
        /// </summary>
        /// <param name="text">Texto que sera almacenado en clipboard</param>
        public void CopyToClipboard(String text)
        {
            try
            {
                Clipboard.SetText(text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "No se puede copiar el texto");
            }
        }

        /// <summary>
        /// Ejecuta las teclas Ctrl+v virtuales para pegar el texto que se encuentra en el clipboard 
        /// </summary>
        public void PasteFromClipboard()
        {
            try
            {
                SendKeys.SendWait("^(v)");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "No se puede pegar el texto");
            }
        }

        /// <summary>
        /// Ejecuta los eventos de clic de mouse para entrar al menu de escaneo de contador automaticamente en mobisys,
        /// es necesario que previamente se haya puesto mobisys como ventana principal.
        /// </summary>
        /// <param name="c"> Instancia de formulario actual para obtener las dimensiones de la ventana</param>
        public void GoToMenuMobiSys(ContainerIdForm c)
        {

            Rectangle activeScreenDimensions = Screen.FromControl(c).Bounds;
            Size Size = new Size(activeScreenDimensions.Width + activeScreenDimensions.X, activeScreenDimensions.Height + activeScreenDimensions.Y);
            int width = Size.Width;
            int height = Size.Height;
            System.Threading.Thread.Sleep(2000);
            Cursor.Position = new System.Drawing.Point(width / 2, height - 10);
            mouse_event(MOUSEEVENTF_LEFTDOWN, width / 2, height - 10, 0, IntPtr.Zero);
            Thread.Sleep(1500);
            mouse_event(MOUSEEVENTF_LEFTUP, width / 2, height - 10, 0, IntPtr.Zero);
            System.Threading.Thread.Sleep(3000);
            Cursor.Position = new System.Drawing.Point(width / 2, (int)(height * (0.2)));
            mouse_event(MOUSEEVENTF_LEFTDOWN, width / 2, (int)(height * (0.2)), 0, IntPtr.Zero);
            Thread.Sleep(1000);
            mouse_event(MOUSEEVENTF_LEFTUP, width / 2, (int)(height * (0.2)), 0, IntPtr.Zero);
            System.Threading.Thread.Sleep(2500);
            Cursor.Position = new System.Drawing.Point(width / 2, (int)(height * (0.8)));
            mouse_event(MOUSEEVENTF_LEFTDOWN, width / 2, (int)(height * (0.8)), 0, IntPtr.Zero);
            Thread.Sleep(1000);
            mouse_event(MOUSEEVENTF_LEFTUP, width / 2, (int)(height * (0.8)), 0, IntPtr.Zero);
            System.Threading.Thread.Sleep(1500);
            Cursor.Position = new System.Drawing.Point(width / 2, (int)(height * (0.55)));
            mouse_event(MOUSEEVENTF_LEFTDOWN, width / 2, (int)(height * (0.55)), 0, IntPtr.Zero);
            Thread.Sleep(1000);
            mouse_event(MOUSEEVENTF_LEFTUP, width / 2, (int)(height * (0.55)), 0, IntPtr.Zero);
            System.Threading.Thread.Sleep(1100);
        }

        /// <summary>
        /// Ejecuta el proceso del nombre indicado con la configuración definida para solicitar permisos de administrador
        /// </summary>
        /// <param name="fileName">Direccion del archivo exe del proceso que se desea ejecutar</param>
        public void ExecuteAsAdmin(string fileName)
        {
            Process proc = new Process();
            proc.StartInfo.FileName = fileName;
            proc.StartInfo.UseShellExecute = false;
            proc.StartInfo.Arguments = "";
            proc.StartInfo.RedirectStandardOutput = true;
            proc.Start();
            Thread.Sleep(1000);
        }

        public void RunMobisys()
        {
            ExecuteAsAdmin("C:\\Program Files (x86)\\Mobisys GmbH\\Mobisys MSB Client\\MobisysClient100.exe");
        }



    }
}
