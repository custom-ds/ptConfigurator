using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;

namespace ArduinoTrack_Configurator
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        /// 

        public static Configurator ATConfig = new Configurator();


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

                strPath += "ArduinoTrack Configurator\\Logs\\";

                if (!Directory.Exists(strPath))
                {
                    Directory.CreateDirectory(strPath);
                }




                srLog = File.AppendText(strPath + "Error Log.txt");
                srLog.WriteLine(DateTime.Now + " ~ " + strSubject + " ~ " + strLine);
                srLog.Close();
            }
            catch (Exception ex)
            {
                //Console.WriteLine("There was an error trying to write to the program log file: " + ex.Message);
            }

        }     
    }


}