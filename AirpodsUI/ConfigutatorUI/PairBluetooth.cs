using InTheHand.Net;
using InTheHand.Net.Sockets;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConfigutatorUI
{
    public partial class PairBluetooth : Form
    {
        List<BluetoothDeviceInfo> devices;
        bool isBusy = false;

        public PairBluetooth()
        {
            devices = new List<BluetoothDeviceInfo>();
            InitializeComponent();
            RefreshBluetoothDevices();
        }

        private void refresh_Click(object sender, EventArgs e)
        {
            RefreshBluetoothDevices();
        }

        private async void RefreshBluetoothDevices()
        {
            if (!isBusy)
            {
                isBusy = true;
                label1.Text = "Getting bluetooth devices...";
                await Task.Run(() =>
                {
                    BluetoothDeviceInfo[] devs = new BluetoothClient().DiscoverDevices();
                    devices = devs.ToList<BluetoothDeviceInfo>();
                });
                label1.Text = "Bluetooth Devices:";
                foreach (var i in devices)
                {
                    btDevices.Items.Add(i.DeviceName);
                }
                isBusy = false;
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
                    DeviceAddress = devices[btDevices.SelectedIndex].DeviceAddress.ToInt64().ToString(),
                    DeviceName = name.Text,
                    DeviceType = "Bluetooth",
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

        private void btDevices_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int index = btDevices.SelectedIndex;
                properties.Text = devices[index].DeviceAddress.ToInt64().ToString();
                name.Text = devices[index].DeviceName;
            }
            catch (Exception ee)
            {

            }
        }
    }
}
