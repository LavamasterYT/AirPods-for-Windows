using System;
using System.IO;
using System.Net;
using Microsoft.Win32;
using System.Threading;
using System.Windows.Forms;
using InTheHand.Net.Sockets;

namespace BluetoothService
{
    static class Program
    {
        static void Main()
        {
            bool checkforupdates = true;

            try
            {
                RegistryKey reg1 = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\AppleBluetoothUI");
                string temp;
                temp = reg1.GetValue("AssetLocation").ToString();
                temp = reg1.GetValue("ButtonText").ToString();
                temp = reg1.GetValue("DeviceAddress").ToString();
                temp = reg1.GetValue("DeviceName").ToString();
                temp = reg1.GetValue("StaticText").ToString();
                temp = reg1.GetValue("UsingImage").ToString();
                temp = reg1.GetValue("TemplateName").ToString();
                temp = reg1.GetValue("UsingStaticText").ToString();
                temp = reg1.GetValue("UpdateCheck", 1).ToString();
                if (temp == "0")
                    checkforupdates = false;
            }
            catch (Exception e)
            {
                MessageBox.Show("Please pair a bluetooth device!");
                System.Diagnostics.Process.Start("BluetoothUI.exe");
                Environment.Exit(0);
                return;
            }

            if (checkforupdates)
            {
                string version = "0.3";
                string temppath = Path.Combine(Path.GetTempPath(), "APBUI");
                string file = Path.Combine(temppath, "version.txt");

                if (!Directory.Exists(temppath))
                    Directory.CreateDirectory(temppath);

                try
                {
                    using (WebClient wc = new WebClient())
                    {
                        wc.DownloadFile("https://raw.githubusercontent.com/LavamasterYT/AirPods-for-Windows/master/version.txt", file);
                    }

                    using (StreamReader sr = new StreamReader(file))
                    {
                        string line = sr.ReadLine();
                        if (line != version)
                            MessageBox.Show($"A new update ({line}) is available to download.");
                    }

                    Directory.Delete(temppath, true);
                }
                catch (Exception e)
                {
                    MessageBox.Show("Unable to check for updates");
                }
            }

            bool hasConnected = false;

            //Main registry variable
            RegistryKey reg = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\AppleBluetoothUI", true);

            //Creates a bluetooth client
            BluetoothClient client = new BluetoothClient();

            //Bluetooth address
            long address = 0;

            //Checks to see if the bluetooth address in the registry is valid
            if (long.TryParse(reg.GetValue("DeviceAddress").ToString(), out long result))
            {
                //Sets the address
                address = result;
            }
            else
            {
                //Exits since its invalid
                Environment.Exit(0);
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
                    if (device.DeviceAddress.ToInt64() == address && device.Connected)
                    {
                        //Checks if they have been connected before, this is to avoid the window popping up multiple times
                        if (!hasConnected)
                        {
                            hasConnected = true;

                            //Assuming the pop up executable is in the same folder, start it
                            System.Diagnostics.Process.Start(System.IO.Path.Combine(System.IO.Directory.GetCurrentDirectory(), "BluetoothUI.exe"), "-show");

                            //Break the foreach loop
                            break;
                        }
                    }
                    else if (device.DeviceAddress.ToInt64() == address)
                    {
                        hasConnected = false;
                    }
                }

                //Needed so it doesn't crash
                Thread.Sleep(500);
            }
        }
    }
}
