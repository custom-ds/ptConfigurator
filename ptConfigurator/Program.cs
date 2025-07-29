using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;
using System.Runtime.InteropServices;
using System.Diagnostics;

namespace ptConfigurator
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        /// 

        public static Configurator ATConfig = new Configurator();
        public static SerialData ATSerialData = new SerialData();

        [STAThread]
        static void Main()
        {
            bool createdNew;
            using (var mutex = new System.Threading.Mutex(true, "ptConfigurator_SingleInstanceMutex", out createdNew))
            {
                if (!createdNew)
                {
                    // Find the existing process
                    var current = Process.GetCurrentProcess();
                    var processes = Process.GetProcessesByName(current.ProcessName);
                    foreach (var process in processes)
                    {
                        if (process.Id != current.Id)
                        {
                            // Bring the main window to the foreground
                            IntPtr handle = process.MainWindowHandle;
                            if (handle != IntPtr.Zero)
                            {
                                ShowWindow(handle, SW_RESTORE);
                                SetForegroundWindow(handle);
                            }
                            break;
                        }
                    }

                    // Optionally, show a message
                    MessageBox.Show("ptConfigurator is already running.", "Single Instance", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                ATConfig = new Configurator();

                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new frmMain());
            }
        }



        public static void writeToProgramLog(string strSubject, string strLine)
        {
            try
            {

                StreamWriter srLog;

                string strPath = System.Environment.GetEnvironmentVariable("APPDATA");
                if (!strPath.EndsWith("\\")) strPath += "\\";

                strPath += "ptConfigurator\\Logs\\";

                if (!Directory.Exists(strPath))
                {
                    Directory.CreateDirectory(strPath);
                }




                srLog = File.AppendText(strPath + "Error Log.txt");
                srLog.WriteLine(DateTime.Now + " ~ " + strSubject + " ~ " + strLine);
                srLog.Close();
            }
            catch
            {
                //Console.WriteLine("There was an error trying to write to the program log file: " + ex.Message);
            }

        }




        [DllImport("user32.dll")]
        private static extern bool SetForegroundWindow(IntPtr hWnd);

        [DllImport("user32.dll")]
        private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        private const int SW_RESTORE = 9;
    }


}