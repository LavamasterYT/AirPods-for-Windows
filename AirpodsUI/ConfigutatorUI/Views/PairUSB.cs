using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Management;
using System.IO;

namespace ConfigutatorUI
{
    public partial class PairUSB : Form
    {
        List<USBDeviceInfo> devices;

        public PairUSB()
        {
            InitializeComponent();
            devices = GetUSBDevices();
            foreach (var i in devices)
            {
                usbDevices.Items.Add(i.Description);
            }
        }

        private void refresh_Click(object sender, EventArgs e)
        {
            devices.Clear();
            devices = GetUSBDevices();
            usbDevices.Items.Clear();
            foreach (var i in devices)
            {
                usbDevices.Items.Add(i.Description);
            }
        }

        private void add_Click(object sender, EventArgs e)
        {
            try
            {
                string path = MainFormModel.CombinePathsStatic(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "\\AirPodsUI");
                string file = MainFormModel.CombinePathsStatic(path, "PairedDevices.json");

                string contents = "";

                using (StreamReader sr = new StreamReader(file))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                        contents += line;
                }

                PairedDevices pdevices = new PairedDevices();
                pdevices = PairedDevices.FromJson(contents);

                pdevices.Devices.Add(new Device()
                {
                    DeviceAddress = devices[usbDevices.SelectedIndex].DeviceID,
                    DeviceName = name.Text,
                    DeviceType = "USB",
                    TemplateLocation = ""
                });

                string result = Serialize.ToJson(pdevices);

                using (StreamWriter sw = new StreamWriter(file))
                {
                    sw.WriteLine(result);
                }
                this.Close();
            }
            catch (Exception ee)
            {
                MessageBox.Show("Unable to add to list", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private List<USBDeviceInfo> GetUSBDevices()
        {
            List<USBDeviceInfo> usbDeviceInfos = new List<USBDeviceInfo>();
            ManagementObjectSearcher device_searcher = new ManagementObjectSearcher("SELECT * FROM Win32_USBHub");
            foreach (ManagementObject usb_device in device_searcher.Get())
            {
                usbDeviceInfos.Add(new USBDeviceInfo(usb_device.Properties["DeviceID"].Value.ToString(), usb_device.Properties["PNPDeviceID"].Value.ToString(), usb_device.Properties["Name"].Value.ToString()));
            }
            return usbDeviceInfos;
        }

        private void usbDevices_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                vid.Text = devices[usbDevices.SelectedIndex].DeviceID;
                name.Text = devices[usbDevices.SelectedIndex].Description;
            }
            catch (Exception ee)
            {

            }
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
