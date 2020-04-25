using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Diagnostics;
using System.Threading;
using Microsoft.Win32;
using InTheHand.Net.Sockets;

namespace BluetoothConsoleService
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Getting program configuration...");
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
            }
            catch (Exception e)
            {
                Console.WriteLine("Please pair a bluetooth device!");
                System.Diagnostics.Process.Start("BluetoothUI.exe");
                Console.ReadKey(true);
                Environment.Exit(-1);
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
                Console.WriteLine("The bluetooth address is invalid. Please repair your bluetooth device.");
                Console.ReadKey(true);
                Environment.Exit(-1);
            }

            //Main loop
            while (true)
            {
                Console.WriteLine("Scanning bluetooth devices... Please wait.");
                //Get array of nearby bluetooth devices
                BluetoothDeviceInfo[] deviceInfo = client.DiscoverDevices();

                //Go through each item in deviceInfo array
                foreach (var device in deviceInfo)
                {
                    Console.WriteLine("Discovered devices:");
                    Console.WriteLine($"{device.DeviceName} | {device.DeviceAddress}");

                    //Checks to see if its your AirPods and if they are connected
                    if (device.DeviceAddress.ToInt64() == address && device.Connected)
                    {
                        Console.WriteLine("This device is connected and matches the address paired!");
                        //Checks if they have been connected before, this is to avoid the window popping up multiple times
                        if (!hasConnected)
                        {
                            Console.WriteLine("This device has not been connected before, opening pop up!");
                            hasConnected = true;

                            //Assuming the pop up executable is in the same folder, start it
                            System.Diagnostics.Process.Start(System.IO.Path.Combine(System.IO.Directory.GetCurrentDirectory(), "BluetoothUI.exe"), "-show");

                            //Break the foreach loop
                            break;
                        }
                    }
                    else if (device.DeviceAddress.ToInt64() == address)
                    {
                        Console.WriteLine("Device has been disconnected.");
                        hasConnected = false;
                    }
                }

                //Needed so it doesn't crash
                Thread.Sleep(500);
            }
        }
    }
}
