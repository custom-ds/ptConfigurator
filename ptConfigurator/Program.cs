using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;

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
            ATConfig = new Configurator();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmMain());
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




    }


}