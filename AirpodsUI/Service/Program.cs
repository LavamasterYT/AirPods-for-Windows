using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Devices.Bluetooth;
using System.Management;
using Microsoft.Win32;
using System.Windows;
using System.IO;
using USBClassLibrary;
using System.Reflection;
using System.Runtime.CompilerServices;
using Usb.Net.Windows;

namespace Service
{
    class Program
    {
        static PairedDevices devices;
        static List<string> BTtemplateLocations;
        static List<string> BTdeviceNames;
        static List<ulong> BTAddresses;
        static List<USBDeviceInfo> USBdevicesOLD;
        static List<USBDeviceInfo> USBdevicesNEW;

        static void Main()
        {
            Directory.SetCurrentDirectory(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
            Console.WriteLine(Directory.GetCurrentDirectory());
            try
            {
                if (int.Parse(Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows NT\CurrentVersion").GetValue("ReleaseId").ToString()) >= 1904)
                {
                    string appDocs = CombinePaths(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "\\AirPodsUI");
                    devices = new PairedDevices();
                    BTtemplateLocations = new List<string>();
                    BTdeviceNames = new List<string>();
                    BTAddresses = new List<ulong>();
                    USBdevicesOLD = new List<USBDeviceInfo>();
                    USBdevicesNEW = new List<USBDeviceInfo>();

                    try
                    {
                        string json = String.Empty;
                        using (StreamReader sr = new StreamReader(CombinePaths(appDocs, "PairedDevices.json")))
                        {
                            string line = "";
                            while ((line = sr.ReadLine()) != null)
                            {
                                json += line;
                            }
                        }
                        devices = PairedDevices.FromJson(json);
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show("There are no paired devices. Run the configurator to pair devices.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        throw new Exception("There are no paired devices.");
                    }

                    MainLoop().GetAwaiter().GetResult();
                }
                else
                {
                    MessageBox.Show("You must be on Windows 10 1903 or later in order to run this program", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (Exception e)
            {
                string loglocation = System.IO.Path.Combine(System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "AirPodsUI"), "Logs");
                MessageBox.Show("AirPodsUI Service has crashed, check error information and report it to me: " + loglocation, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                using (StreamWriter sw = new StreamWriter(System.IO.Path.Combine(loglocation, DateTime.Now.ToString("MM-dd-yyyy-hh-mm-ss") + ".txt")))
                {
                    sw.WriteLine(Convert.ToString(e));
                }
                Environment.Exit(-1);
            }
        }

        static async Task MainLoop()
        {
            List<BluetoothDevice> btDevices = new List<BluetoothDevice>();

            foreach (var i in devices.Devices)
            {
                if (i.DeviceType == "Bluetooth")
                {
                    BluetoothDevice bd = await BluetoothDevice.FromBluetoothAddressAsync((ulong)long.Parse(i.DeviceAddress));
                    bd.ConnectionStatusChanged += Bd_ConnectionStatusChanged;
                    btDevices.Add(bd);
                    BTtemplateLocations.Add(i.TemplateLocation);
                    BTdeviceNames.Add(i.DeviceName);
                    BTAddresses.Add(bd.BluetoothAddress);
                }
            }

            USBdevicesOLD = GetUSBDevices();
            USBdevicesNEW = GetUSBDevices();

            while (true)
            {
                USBdevicesNEW = GetUSBDevices();

                Console.WriteLine("Checking if a new USB device is connected...");

                if (USBdevicesOLD != USBdevicesNEW)
                {
                    if (USBdevicesOLD.Count > USBdevicesNEW.Count)
                        Console.WriteLine("Device disconnected");
                    else if (USBdevicesOLD.Count < USBdevicesNEW.Count)
                    {
                        Console.WriteLine("Device Connected");
                        int index = 0;
                        for (int i = 0; i < USBdevicesNEW.Count; i++)
                        {
                            if (i == USBdevicesNEW.Count - 1)
                            {
                                index = i;
                                break;
                            }
                            else if (USBdevicesNEW[i].DeviceID == USBdevicesOLD[i].DeviceID)
                                Console.WriteLine("No difference in this interation...");
                            else
                            {
                                index = i;
                                Console.WriteLine("DIFFERENCE, index is " + i);
                                break;
                            }
                        }
                        int deviceIndex = 0;
                        for (int i = 0; i < devices.Devices.Count; i++)
                        {
                            if (USBdevicesNEW[index].DeviceID == devices.Devices[i].DeviceAddress)
                            {
                                deviceIndex = i;
                            }
                        }
                        StartProcess(devices.Devices[deviceIndex].DeviceName, devices.Devices[deviceIndex].TemplateLocation);
                    }
                }

                USBdevicesOLD = Copy(USBdevicesNEW);

                await Task.Delay(500);
            }
        }

        private static void Bd_ConnectionStatusChanged(BluetoothDevice sender, object args)
        {
            if (sender.ConnectionStatus == BluetoothConnectionStatus.Connected)
            {
                for (int i = 0; i < BTAddresses.Count; i++)
                {
                    if (BTAddresses[i] == sender.BluetoothAddress)
                    {
                        StartProcess(BTdeviceNames[i], BTtemplateLocations[i]);
                        break;
                    }
                }
            }
        }

        private static List<USBDeviceInfo> Copy(List<USBDeviceInfo> old)
        {
            List<USBDeviceInfo> list = new List<USBDeviceInfo>();
            foreach (var i in old)
            {
                USBDeviceInfo info = i;
                list.Add(info);
            }
            return list;
        }

        private static List<USBDeviceInfo> GetUSBDevices()
        {
            List<USBDeviceInfo> usbDeviceInfos = new List<USBDeviceInfo>();
            ManagementObjectSearcher device_searcher = new ManagementObjectSearcher("SELECT * FROM Win32_USBHub");
            foreach (ManagementObject usb_device in device_searcher.Get())
            {
                usbDeviceInfos.Add(new USBDeviceInfo(usb_device.Properties["DeviceID"].Value.ToString(), usb_device.Properties["PNPDeviceID"].Value.ToString(), usb_device.Properties["Name"].Value.ToString()));
            }
            return usbDeviceInfos;
        }

        private static void StartProcess(string arg1, string arg2)
        {
            System.Diagnostics.Process.Start("PopUpUI.exe", $"\"{arg2}\" \"{arg1}\"");
        }

        public static string CombinePaths(string path1, string path2)
        {
            if (path1.EndsWith("\\") && !path2.StartsWith("\\"))
                return path1 + path2;
            else if (!path1.EndsWith("\\") && path2.StartsWith("\\"))
                return path1 + path2;
            else if (!path1.EndsWith("\\") && !path1.StartsWith("\\"))
                return path1 + "\\" + path2;
            else
                return path1 + path2;
        }
    }

    class USBDeviceInfo
    {
        public USBDeviceInfo(string deviceID, string pnpDeviceID, string description)
        {
            this.DeviceID = deviceID;
            this.PnpDeviceID = pnpDeviceID;
            this.Description = description;
        }
        public string DeviceID { get; private set; }
        public string PnpDeviceID { get; private set; }
        public string Description { get; private set; }
    }
}
