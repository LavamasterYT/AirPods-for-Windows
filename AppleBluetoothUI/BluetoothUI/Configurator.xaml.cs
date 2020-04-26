using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Microsoft.Win32;
using Newtonsoft.Json;
using InTheHand.Net.Bluetooth;
using System.IO;
using InTheHand.Net.Sockets;
using IWshRuntimeLibrary;
using System.Reflection;

namespace BluetoothUI
{
    /// <summary>
    /// Interaction logic for Configurator.xaml
    /// </summary>
    public partial class Configurator : Window
    {
        RegistryKey reg;
        Dictionary<string, long> BluetoothDevices;

        string logFilePath;

        public Configurator()
        {
            BluetoothDevices = new Dictionary<string, long>();
            InitializeComponent();
            if (Registry.CurrentUser.OpenSubKey(@"SOFTWARE\AppleBluetoothUI") == null)
            {
                Registry.CurrentUser.CreateSubKey(@"SOFTWARE\AppleBluetoothUI");
            }
            reg = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\AppleBluetoothUI", true);
            UpdateTemplateInfo();
            logFilePath = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "ABUI/Logs/");
            if (!System.IO.Directory.Exists(logFilePath))
                System.IO.Directory.CreateDirectory(logFilePath);
        }

        private void start_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process[] p = System.Diagnostics.Process.GetProcessesByName("BluetoothService");
            if (p.Length < 1)
            {
                System.Diagnostics.Process.Start("BluetoothService.exe");
            }
            else
                MessageBox.Show("Process already running!");
        }

        private void stop_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process[] p = System.Diagnostics.Process.GetProcessesByName("BluetoothService");
            if (p.Length > 0)
                foreach (var i in p)
                    i.Kill();
        }

        private void test_Click(object sender, RoutedEventArgs e)
        {
            new LightUI().Show();
        }

        private void close_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start("README.txt");
        }

        private async void refresh_Click(object sender, RoutedEventArgs e)
        {
            BluetoothDevices.Clear();
            applyBt.IsEnabled = false;
            refresh.IsEnabled = false;
            BluetoothClient bc = new BluetoothClient();
            BluetoothDeviceInfo[] bdi = await Task.Run(() => bc.DiscoverDevices());
            foreach (BluetoothDeviceInfo i in bdi)
            {
                BluetoothDevices.Add(i.DeviceName, i.DeviceAddress.ToInt64());
            }
            foreach (KeyValuePair<string, long> entry in BluetoothDevices)
            {
                ListBoxItem lbi = new ListBoxItem();
                lbi.Selected += Lbi_Selected;
                lbi.Content = entry.Key;
                btDevices.Items.Add(lbi);
            }
            refresh.IsEnabled = true;
        }

        private void Lbi_Selected(object sender, RoutedEventArgs e)
        {
            applyBt.IsEnabled = true;
        }

        private void apply_Click_1(object sender, RoutedEventArgs e)
        {
            foreach (ListBoxItem lbi in btDevices.Items)
            {
                if (lbi.IsSelected)
                {
                    reg.SetValue("DeviceAddress", long.Parse(BluetoothDevices[lbi.Content.ToString()].ToString()));
                    reg.SetValue("DeviceName", lbi.Content);
                    MessageBox.Show("Bluetooth Device is applied!");
                }
            }
        }

        private void template_Checked(object sender, RoutedEventArgs e)
        {
            RadioButton rb = sender as RadioButton;
            if (rb.Name == "gen1" && rb.IsChecked == true)
            {
                try
                { 
                    tempInfo.Items.Clear();
                    reg.SetValue("TemplateName", "AirPods Generation 1");
                    reg.SetValue("UsingImage", 0);
                    reg.SetValue("AssetLocation", @"Templates\Assets\ag1.mp4");
                    reg.SetValue("UsingStaticText", 0);
                    reg.SetValue("StaticText", "AirPods");
                    reg.SetValue("ButtonText", "Done");
                    UpdateTemplateInfo(); 
                }
                catch (Exception el) { }
            }
            else if (rb.Name == "other" && rb.IsChecked == true)
            {
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.Filter = "Template files (*.json)|*.json|All files (*.*)|*.*";
                ofd.ShowDialog();
                string jsonFile = ofd.FileName;
                try
                {
                    tempInfo.Items.Clear();
                    CustomTemplate ct = JsonConvert.DeserializeObject<CustomTemplate>(System.IO.File.ReadAllText(jsonFile));
                    reg.SetValue("TemplateName", ct.templatename);
                    reg.SetValue("UsingImage", ct.usingimage);
                    reg.SetValue("AssetLocation", ct.iconlocation);
                    reg.SetValue("UsingStaticText", ct.statictext);
                    reg.SetValue("StaticText", ct.staticname);
                    reg.SetValue("ButtonText", ct.buttontext);
                    UpdateTemplateInfo();
                }
                catch (Exception ee)
                {
                    using (System.IO.StreamWriter sw = new System.IO.StreamWriter(System.IO.Path.Combine(logFilePath, "jsonerr-" + DateTime.Now.ToString("MM-dd-yyyy HH-mm-ss"))))
                    {
                        sw.WriteLine(Convert.ToString(ee));
                    }
                    MessageBox.Show("Not a valid JSON/Template file!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    other.IsChecked = false;
                    gen1.IsChecked = true;
                }
                try { tempInfo.Items.Clear(); UpdateTemplateInfo(); } catch (Exception el) { }
            }
        }

        public void UpdateTemplateInfo()
        {
            try
            {
                string templateName = reg.GetValue("TemplateName").ToString();
                string usingImage = reg.GetValue("UsingImage").ToString();
                string assetLocation = reg.GetValue("AssetLocation").ToString();
                string staticText = reg.GetValue("UsingStaticText").ToString();
                string staticName = reg.GetValue("StaticText").ToString();
                string buttonText = reg.GetValue("ButtonText").ToString();
                tempInfo.Items.Add(templateName + " Template Info");
                tempInfo.Items.Add("Using Image = " + usingImage);
                tempInfo.Items.Add("Asset Location = " + assetLocation);
                tempInfo.Items.Add("Using Static Text = " + staticText);
                tempInfo.Items.Add("Static Name = " + staticName);
                tempInfo.Items.Add("Button Text = " + buttonText);
                
            }
            catch (Exception lol)
            {
                reg.SetValue("TemplateName", "AirPods Generation 1");
                reg.SetValue("UsingImage", 0);
                reg.SetValue("AssetLocation", @"Templates\Assets\ag1.mp4");
                reg.SetValue("UsingStaticText", 0);
                reg.SetValue("StaticText", "AirPods");
                reg.SetValue("ButtonText", "Done");
                UpdateTemplateInfo();
                return;
            }
        }

        private void addToStartUp_Click(object sender, RoutedEventArgs e)
        {
            string dir = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) + "\\Microsoft\\Windows\\Start Menu\\Programs\\Startup\\";
            string path = dir + "BluetoothService.lnk";
            string serviceExecutable = System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\BluetoothService.exe";

            try
            {
                if (System.IO.File.Exists(path))
                {
                    System.IO.File.Delete(path);
                    MessageBox.Show("Shortcut removed at " + path + "!");
                }
                else
                {
                    CreateShortcut("BluetoothService", dir, serviceExecutable);
                    MessageBox.Show("Created shortcut to start up programs at " + path + "!");
                }
            }
            catch (Exception el)
            {
                MessageBox.Show("Unable to create the shortcut, try running as administrator since the Startup folder is only available to administrators.");
            }
        }

        public static void CreateShortcut(string shortcutName, string shortcutPath, string targetFileLocation)
        {
            string shortcutLocation = System.IO.Path.Combine(shortcutPath, shortcutName + ".lnk");
            WshShell shell = new WshShell();
            IWshShortcut shortcut = (IWshShortcut)shell.CreateShortcut(shortcutLocation);

            shortcut.Description = "My shortcut description";   // The description of the shortcut
            shortcut.IconLocation = @"c:\myicon.ico";           // The icon of the shortcut
            shortcut.TargetPath = targetFileLocation;                 // The path of the file that will launch when the shortcut is run
            shortcut.Save();                                    // Save the shortcut
        }
    }
}
