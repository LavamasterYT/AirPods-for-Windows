using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConfigutatorUI
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Directory.SetCurrentDirectory(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.ThreadException += Application_ThreadException;
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
            try
            {
                Application.Run(new MainForm());
            }
            catch (Exception e)
            {
                string loglocation = System.IO.Path.Combine(System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "AirPodsUI"), "Logs");
                MessageBox.Show("AirPodsUI has crashed, check error information and report it to me: " + loglocation, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                using (StreamWriter sw = new StreamWriter(System.IO.Path.Combine(loglocation, DateTime.Now.ToString("MM-dd-yyyy-hh-mm-ss") + ".txt")))
                {
                    sw.WriteLine(Convert.ToString(e));
                }
                Environment.Exit(-1);
            }
        }

        private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            string loglocation = System.IO.Path.Combine(System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "AirPodsUI"), "Logs");
            MessageBox.Show("AirPodsUI has crashed, check error information and report it to me: " + loglocation, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            using (StreamWriter sw = new StreamWriter(System.IO.Path.Combine(loglocation, DateTime.Now.ToString("MM-dd-yyyy-hh-mm-ss") + ".txt")))
            {
                sw.WriteLine(Convert.ToString(e.ExceptionObject));
            }
            Environment.Exit(-1);
        }

        private static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            string loglocation = System.IO.Path.Combine(System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "AirPodsUI"), "Logs");
            MessageBox.Show("AirPodsUI has crashed, check error information and report it to me: " + loglocation, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            using (StreamWriter sw = new StreamWriter(System.IO.Path.Combine(loglocation, DateTime.Now.ToString("MM-dd-yyyy-hh-mm-ss") + ".txt")))
            {
                sw.WriteLine(Convert.ToString(e.Exception));
            }
            Environment.Exit(-1);
        }
    }
}
