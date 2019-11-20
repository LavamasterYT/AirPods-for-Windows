using InTheHand.Net.Sockets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;
using InTheHand.Net;

namespace AirPodsSetup
{
    class Program
    {
        static BluetoothClient client = new BluetoothClient();
        static string address = "";

        static void Main(string[] args)
        {
            Console.WriteLine("I somehow had enough time to do this.... I will make a proper setup later.");
            Console.WriteLine();
            Console.WriteLine("Make sure your AirPods are connected to your PC, then press any key to continue");
            Console.ReadKey();
            FirstPortion();
        }

        static void FirstPortion()
        {
            do
            {
                Console.Clear();
                Console.WriteLine("Please type in the bluetooth address of your AirPods, then press enter. (The device address are those numbers after the |)");
                Console.WriteLine();
                GetBluetoothDevices();
                address = Console.ReadLine();
                if (address != "refresh") break;
            }
            while (true);
            SecondPortion();
        }

        static void SecondPortion()
        {
            Console.Clear();
            Console.WriteLine("Checking address");
            Console.WriteLine();
            BluetoothDeviceInfo[] devices = client.DiscoverDevices();
            foreach (var i in devices)
            {
                if (BluetoothAddress.TryParse(address, out BluetoothAddress result))
                {
                    if (i.DeviceAddress == BluetoothAddress.Parse(address))
                    {
                        RegistryKey reg = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\AirPods Service");
                        reg.SetValue("btAddress", address);
                        ThirdPortion();
                    }
                }
            }
            Console.WriteLine("No device with that address exists...");
            Console.ReadKey(true);
            Environment.Exit(0);
        }

        static void ThirdPortion()
        {
            Console.WriteLine("Technically, you are done. Unzip \"data.zip\" and run AirPodsService.exe and let it run in the background.");
            Console.WriteLine("You can add it to your list of start up programs if you want!");
            Console.ReadKey(true);
        }

        static void GetBluetoothDevices()
        {
            Console.WriteLine("Type in \"refresh\" to refresh the list");
            Console.WriteLine("Getting bluetooth devices");
            Console.WriteLine();
            BluetoothDeviceInfo[] devices = client.DiscoverDevices();
            foreach (var i in devices)
            {
                Console.WriteLine($"{i.DeviceName} | {i.DeviceAddress}");
            }
        }
    }
}
