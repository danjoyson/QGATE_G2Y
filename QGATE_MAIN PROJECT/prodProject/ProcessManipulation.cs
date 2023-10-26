﻿using System;
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
        public string porcName = "";
        private string mobisysProcessName = "MobisysClient100"; //Variable nombre de proceso que debe ser superpuesto al completar una revision de pieza
        private System.Timers.Timer scanMobisysTimer = new(60000);
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
        public static int GetProcessID(string procName)
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

        public void HideShowProcess(string text)
        {           
            CopyToClipboard(text);
            //superposeProgram(mobisysProcessName);
            System.Threading.Thread.Sleep(1000);
            Process p = Process.GetCurrentProcess();
            int hWnd;
            hWnd = p.MainWindowHandle.ToInt32();
            ShowWindow(hWnd, SW_HIDE);
            System.Threading.Thread.Sleep(2000);
            Cursor.Position = new System.Drawing.Point(850, 400);
            mouse_event(MOUSEEVENTF_LEFTDOWN, 850, 400, 0, IntPtr.Zero);
            Thread.Sleep(1000);
            mouse_event(MOUSEEVENTF_LEFTUP, 850, 400, 0, IntPtr.Zero);
            Thread.Sleep(1000);
            PasteFromClipboard();
            System.Threading.Thread.Sleep(3000);
            ShowWindow(hWnd, SW_SHOW);

            /*Rectangle activeScreenDimensions = Screen.FromControl(this).Bounds;
            Size Size = new Size(activeScreenDimensions.Width + activeScreenDimensions.X, activeScreenDimensions.Height + activeScreenDimensions.Y);
            MessageBox.Show("Width :" + Size.Width.ToString() + "Height :" + Size.Height.ToString());*/
        }

        //Método para el proceso de superposición, copiar texto al clipboard del sistema 
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

        //Método para pegar el texto que se encuentra en el clipboard del sistema 
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


    }
}