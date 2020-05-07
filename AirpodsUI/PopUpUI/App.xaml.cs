using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows;

namespace PopUpUI
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            try
            {
                Directory.SetCurrentDirectory(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
                if (e.Args.Length == 2)
                {
                    MainWindow wnd = new MainWindow(e.Args[0], e.Args[1]);
                    wnd.Show();
                }
                else
                {
                    throw new ArgumentNullException("e.Args[0], e.Args[1]", "There were no arguments specified launching the pop up");
                }
            }
            catch (Exception ee)
            {
                string loglocation = Path.Combine(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "AirPodsUI"), "Logs");
                MessageBox.Show("AirPodsUI has crashed, check error information and report it to me: " + loglocation, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                using (StreamWriter sw = new StreamWriter(Path.Combine(loglocation, DateTime.Now.ToString("MM-dd-yyyy-hh-mm-ss") + ".txt")))
                {
                    sw.WriteLine(Convert.ToString(ee));
                }
                Environment.Exit(-1);
            }
        }

        private void Application_DispatcherUnhandledException(object sender, System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e)
        {
            string loglocation = System.IO.Path.Combine(System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "AirPodsUI"), "Logs");
            MessageBox.Show("AirPodsUI has crashed, check error information and report it to me: " + loglocation, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            using (StreamWriter sw = new StreamWriter(System.IO.Path.Combine(loglocation, DateTime.Now.ToString("MM-dd-yyyy-hh-mm-ss") + ".txt")))
            {
                sw.WriteLine(Convert.ToString(e.Exception));
            }
            Environment.Exit(-1);
        }
    }
}
