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

        public void SuperposePid(string procName)
        {
            int targetProcessPID = -1;
            targetProcessPID = GetProcessID(procName);
            if (targetProcessPID != -1)
            {

                BringWindowToFrontByPID(targetProcessPID);

            }
            else
            {
                MessageBox.Show("The app cant get the PID");
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
                    //MessageBox.Show("Debería");


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

        public string GetCurrentProcessName()
        {
            Process procesoActual = Process.GetCurrentProcess();
            // Obtener el nombre del proceso
            string nombreDelProceso = procesoActual.ProcessName;
            currentProcess = nombreDelProceso;
            //MessageBox.Show("Nombre del proceso actual: " + nombreDelProceso);

            return currentProcess;

        }

        public void AddToMobisys(string text)
        {
            try
            {
                //EL código del if comentado será implementado para la siguiete modificación
                //Si el if se cumple debe mandar a la pantalla llamada menu Mobisys, sino se cumple continua con el código que esta despues del if 
                //ese código estaría en un else y ahí debe incrementarse el contador de piezas en 1
                //if(Form1.conatadorPiezas==Form1.estandar)
                currentProcess = GetCurrentProcessName();
                CopyToClipboard(text);
                //SuperposePid(mobisysProcessName);
                SuperposePid(mobisysProcessName);
                System.Threading.Thread.Sleep(2000);
                PasteFromClipboard();
                System.Threading.Thread.Sleep(3000);
                SuperposeProgram(currentProcess);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error tratando de añadir a mobisys");
            }
        }

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
