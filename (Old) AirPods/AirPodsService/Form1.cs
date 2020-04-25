using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using InTheHand.Net;
using System.IO;
using InTheHand.Net.Sockets;
using Microsoft.Win32;

namespace AirPodsService
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        async void MainService()
        {
            try
            {
                bool hasConnected = false;

                //Main registry variable
                RegistryKey reg = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\AirPods Service", true);

                //Creates a bluetooth client
                BluetoothClient client = new BluetoothClient();

                //Bluetooth address
                BluetoothAddress address = null;

                //Checks to see if the bluetooth address in the registry is valid
                if (BluetoothAddress.TryParse(Convert.ToString(reg.GetValue("btAddress")), out BluetoothAddress result))
                {
                    //Sets the address
                    address = result;
                }
                else
                {
                    //Exits since its invalid
                    this.Close();
                }

                //Main loop
                while (true)
                {
                    //Get array of nearby bluetooth devices
                    BluetoothDeviceInfo[] deviceInfo = client.DiscoverDevices();

                    //Go through each item in deviceInfo array
                    foreach (var device in deviceInfo)
                    {
                        //Checks to see if its your AirPods and if they are connected
                        if (device.DeviceAddress == address && device.Connected)
                        {
                            //Checks if they have been connected before, this is to avoid the window popping up multiple times
                            if (!hasConnected)
                            {
                                //Writes the AirPods name to the registry
                                reg.SetValue("name", device.DeviceName);

                                hasConnected = true;

                                //Assuming the pop up executable is in the same folder, start it
                                System.Diagnostics.Process.Start(System.IO.Path.Combine(System.IO.Directory.GetCurrentDirectory(), "AirPods Window.exe"));

                                //Break the foreach loop
                                break;
                            }
                        }
                        else if (device.DeviceAddress == address)
                        {
                            hasConnected = false;
                        }
                    }

                    //Needed so it doesn't crash
                    await Task.Delay(500);
                }
            }
            catch (Exception e)
            {

                if (!Directory.Exists(@"C:\Users\" + Environment.UserName + @"\Documents\AirPods Logs"))
                {
                    Directory.CreateDirectory(@"C:\Users\" + Environment.UserName + @"\Documents\AirPods Logs");
                }
                string fileName = DateTime.Now.ToString("MM-dd-yyyy HH-mm-ss");
                using (StreamWriter sw = new StreamWriter(@"C:\Users\" + Environment.UserName + @"\Documents\AirPods Logs\log " + fileName + ".txt"))
                {
                    sw.WriteLine(Convert.ToString(e));
                }
                this.Close();
            }
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            this.Hide();
            MainService();
        }
    }
}