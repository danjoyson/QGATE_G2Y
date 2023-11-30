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
        private const int SW_HIDE = 0;
        private const int SW_SHOW = 5;
        [DllImport("User32")]
        private static extern int ShowWindow(int hwnd, int nCmdShow);
        [DllImport("user32.dll")]
        public static extern void mouse_event(uint dwFlags, int dx, int dy, uint dwData, IntPtr dwExtraInfo);

        private const int MOUSEEVENTF_LEFTDOWN = 0x02;
        private const int MOUSEEVENTF_LEFTUP = 0x04;
        System.Timers.Timer t = new System.Timers.Timer(5500);
        public int hWnd;
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
                IntPtr windowHandle = processes[0].MainWindowHandle;

                if (windowHandle != IntPtr.Zero)
                {

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


        /// <summary>
        /// Obtiene el ID del proceso de Mobisys
        /// </summary>
        /// <returns></returns>
        public string GetCurrentProcessName()
        {
            Process procesoActual = Process.GetCurrentProcess();
            string nombreDelProceso = procesoActual.ProcessName;
            currentProcess = nombreDelProceso;
            return currentProcess;

        }

        /// <summary>
        /// Realiza el proceso de inserción de etiqueta
        /// </summary>
        /// <param name="text">Numero de etiqueta</param>
        /// <returns></returns>
        public bool AddToMobisys(string text)
        {
            bool processResult=false;
            try
            {
                currentProcess = GetCurrentProcessName();
                CopyToClipboard(text);
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
                //t.Start();
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

        private static void TimerCallback(Object o)
        {
        }

    }
}
