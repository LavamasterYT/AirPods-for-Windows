using IWshRuntimeLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConfigutatorUI
{
    public partial class MainForm : Form
    {
        #region public bool ControlsEnabled = false;
        private bool _controlsEnabled = false;

        public bool ControlsEnabled
        {
            get
            {
                return _controlsEnabled;
            }
            set
            {
                _controlsEnabled = value;
                if (_controlsEnabled)
                {

                }
            }
        }
        #endregion

        private MainFormModel mfm;

        public MainForm()
        {
            mfm = new MainFormModel();
            InitializeComponent();
            foreach (var i in mfm.templates)
            {
                templateList.Items.Add(i.TemplateName);
            }

            #region Load Default Model
            templateName.Text = DefaultTemplate.TemplateName;
            usingImage.Checked = DefaultTemplate.UsingImage;
            useDeviceName.Checked = DefaultTemplate.UseDeviceName;
            loop.Checked = DefaultTemplate.LoopAnimation;
            assetLocation.Text = DefaultTemplate.AssetLocation;
            defaultName.Text = DefaultTemplate.DefaultDeviceName;
            buttonText.Text = DefaultTemplate.ButtonText;
            windowBackground.BackColor = mfm.FromHex(DefaultTemplate.WindowBackground);
            windowForeground.BackColor = mfm.FromHex(DefaultTemplate.WindowForeground);
            buttonBackground.BackColor = mfm.FromHex(DefaultTemplate.ButtonBackground);
            buttonForeground.BackColor = mfm.FromHex(DefaultTemplate.ButtonForeground);
            tint.BackColor = mfm.FromHex(DefaultTemplate.Tint);
            #endregion

            foreach (var i in mfm.devices.Devices)
            {
                deviceList.Items.Add(i.DeviceName);
            }
        }

        private void startStopServiceButton_Click(object sender, EventArgs e)
        {
            throw new Exception();
        }

        private void templateList_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int index = templateList.SelectedIndex;
                UpdateFromTemplate(mfm.templates[index]);
                applySelectedToDevice.Enabled = true;
            }
            catch (Exception eq)
            {

            }
        }

        private void windowBackground_DoubleClick(object sender, EventArgs e)
        {
            windowBackground.BackColor = GetColor();
        }

        private void windowForeground_DoubleClick(object sender, EventArgs e)
        {
            windowForeground.BackColor = GetColor();
        }

        private void buttonBackground_DoubleClick(object sender, EventArgs e)
        {
            buttonBackground.BackColor = GetColor();
        }

        private void buttonForeground_DoubleClick(object sender, EventArgs e)
        {
            buttonForeground.BackColor = GetColor();
        }

        private void tint_DoubleClick(object sender, EventArgs e)
        {
            tint.BackColor = GetColor();
        }

        private Color GetColor()
        {
            ColorDialog cd = new ColorDialog();
            if (cd.ShowDialog() == DialogResult.OK)
            {
                return cd.Color;
            }
            else
            {
                return Color.White;
            }
        }

        private void UpdateFromTemplate(Template template)
        {
            templateName.Text = template.TemplateName;
            usingImage.Checked = template.UsingImage;
            useDeviceName.Checked = template.UseDeviceName;
            loop.Checked = template.LoopAnimation;
            assetLocation.Text = template.AssetLocation;
            defaultName.Text = template.DefaultDeviceName;
            buttonText.Text = template.ButtonText;
            windowBackground.BackColor = mfm.FromHex(template.WindowBackground);
            windowForeground.BackColor = mfm.FromHex(template.WindowForeground);
            buttonBackground.BackColor = mfm.FromHex(template.ButtonBackground);
            buttonForeground.BackColor = mfm.FromHex(template.ButtonForeground);
            tint.BackColor = mfm.FromHex(template.Tint);
        }

        private void openReadMe_Click(object sender, EventArgs e)
        {
            try
            {
                string executingDir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                Process.Start(mfm.CombinePaths(executingDir, "README.txt"));
            }
            catch (Exception ee)
            {
                MessageBox.Show("Unable to find README.txt.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void addTemplate_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.DefaultExt = ".json";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                mfm.AddTemplate(ofd.FileName);
                templateList.Items.Clear();
                foreach (var i in mfm.templates)
                {
                    templateList.Items.Add(i.TemplateName);
                }
            }
        }

        private void refreshTemplates_Click(object sender, EventArgs e)
        {
            templateList.Items.Clear();
            mfm.templates.Clear();
            mfm.RefreshTemplates();
            foreach (var i in mfm.templates)
            {
                templateList.Items.Add(i.TemplateName);
            }
        }

        private async void save_Click(object sender, EventArgs e)
        {
            Template template = new Template();
            template.TemplateName = templateName.Text;
            template.UsingImage = usingImage.Checked;
            template.UseDeviceName = useDeviceName.Checked;
            template.LoopAnimation = loop.Checked;
            template.AssetLocation = assetLocation.Text;
            template.DefaultDeviceName = defaultName.Text;
            template.ButtonText = buttonText.Text;
            template.WindowBackground = HexConverter(windowBackground.BackColor);
            template.WindowForeground = HexConverter(windowForeground.BackColor);
            template.ButtonBackground = HexConverter(buttonBackground.BackColor);
            template.ButtonForeground = HexConverter(buttonForeground.BackColor);
            template.Tint = HexConverter(tint.BackColor);
            string result = Serialize1.ToJson(template);

            string path = mfm.CombinePaths(mfm.appDocs, "Templates\\" + RemoveIllegalCharacters(template.TemplateName) + ".json");

            string fileName = Save.NextAvailableFilename(path);

            using (StreamWriter sw = new StreamWriter(fileName))
            {
                await sw.WriteLineAsync(result);
            }
            MessageBox.Show("Saved at " + fileName + "!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private string RemoveIllegalCharacters(string input)
        {
            string regexSearch = new string(Path.GetInvalidFileNameChars()) + new string(Path.GetInvalidPathChars());
            Regex r = new Regex(string.Format("[{0}]", Regex.Escape(regexSearch)));
            return r.Replace(input, "");
            
        }

        private String HexConverter(System.Drawing.Color c)
        {
            return "#" + c.R.ToString("X2") + c.G.ToString("X2") + c.B.ToString("X2");
        }

        private void saveTo_Click(object sender, EventArgs e)
        {
            try
            {
                Template template = new Template();
                template.TemplateName = templateName.Text;
                template.UsingImage = usingImage.Checked;
                template.UseDeviceName = useDeviceName.Checked;
                template.LoopAnimation = loop.Checked;
                template.AssetLocation = assetLocation.Text;
                template.DefaultDeviceName = defaultName.Text;
                template.ButtonText = buttonText.Text;
                template.WindowBackground = HexConverter(windowBackground.BackColor);
                template.WindowForeground = HexConverter(windowForeground.BackColor);
                template.ButtonBackground = HexConverter(buttonBackground.BackColor);
                template.ButtonForeground = HexConverter(buttonForeground.BackColor);
                template.Tint = HexConverter(tint.BackColor);
                string result = Serialize1.ToJson(template);
                using (StreamWriter sw = new StreamWriter(mfm.TemplateLocations[templateList.SelectedIndex]))
                    sw.WriteLine(result);
                refreshTemplates_Click(null, null);
            }
            catch (Exception ee)
            {
                MessageBox.Show("Unable to save template", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void applySelectedToDevice_Click(object sender, EventArgs e)
        {
            try
            {
                int index = deviceList.SelectedIndex;
                mfm.devices.Devices[index].TemplateLocation = mfm.TemplateLocations[templateList.SelectedIndex];
                string result = Serialize.ToJson(mfm.devices);
                using (StreamWriter sw = new StreamWriter(mfm.CombinePaths(mfm.appDocs, "PairedDevices.json")))
                {
                    sw.WriteLine(result);
                }
                MessageBox.Show("Successfully applied template!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            catch (Exception ee)
            {
                MessageBox.Show("Unable to apply template to device.");
            }
        }

        private void convert_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    OldTemplate ot = OldTemplate.FromJson(System.IO.File.ReadAllText(ofd.FileName));

                    templateName.Text = ot.Templatename;
                    usingImage.Checked = ot.Usingimage == 0 ? false : true;
                    useDeviceName.Checked = ot.Statictext == 0 ? false : true;
                    loop.Checked = DefaultTemplate.LoopAnimation;
                    assetLocation.Text = ot.Iconlocation;
                    defaultName.Text = ot.Staticname;
                    buttonText.Text = ot.Buttontext;
                    windowBackground.BackColor = mfm.FromHex(DefaultTemplate.WindowBackground);
                    windowForeground.BackColor = mfm.FromHex(DefaultTemplate.WindowForeground);
                    buttonBackground.BackColor = mfm.FromHex(DefaultTemplate.ButtonBackground);
                    buttonForeground.BackColor = mfm.FromHex(DefaultTemplate.ButtonForeground);
                    tint.BackColor = mfm.FromHex(DefaultTemplate.Tint);
                }
                catch (Exception ee)
                {
                    MessageBox.Show("Unable to convert to the new format.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void pairUSB_Click(object sender, EventArgs e)
        {
            PairUSB pairUSB = new PairUSB();
            pairUSB.ShowDialog();
        }

        private void pairBT_Click(object sender, EventArgs e)
        {
            PairBluetooth pairBluetooth = new PairBluetooth();
            pairBluetooth.ShowDialog();
        }

        private void refreshDevices_Click(object sender, EventArgs e)
        {
            mfm.devices.Devices.Clear();
            deviceList.Items.Clear();
            mfm.RefreshDevices();
            foreach (var i in mfm.devices.Devices)
            {
                deviceList.Items.Add(i.DeviceName);
            }
        }

        private void removeDevice_Click(object sender, EventArgs e)
        {
            try
            {
                mfm.RemoveDeviceAt(deviceList.SelectedIndex);
                deviceList.Items.Clear();

                foreach (var i in mfm.devices.Devices)
                    {
                        deviceList.Items.Add(i.DeviceName);
                    }
                }
            catch (Exception ee)
            {
                MessageBox.Show("Unable to remove device.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void removeTemplate_Click(object sender, EventArgs e)
        {
            try
            {
                mfm.RemoveTemplateAt(templateList.SelectedIndex);
                templateList.Items.RemoveAt(templateList.SelectedIndex);
            }
            catch (Exception ee)
            {
                MessageBox.Show("Unable to remove template.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void testUI_Click(object sender, EventArgs e)
        {
            try
            {
                string executingDir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                string args = "";
                args += "\"" + mfm.TemplateLocations[templateList.SelectedIndex] + "\" \"" + dummyName.Text + "\"";
                Process.Start(mfm.CombinePaths(executingDir, "PopUpUI.exe"), args);
            }
            catch (Exception ee)
            {
                MessageBox.Show("Please save your template before testing the UI.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void addToStartup_Click(object sender, EventArgs e)
        {
            try
            {
                if (System.IO.File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) + "\\Microsoft\\Windows\\Start Menu\\Programs\\Startup\\AirPods Service.lnk"))
                {
                    System.IO.File.Delete(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) + "\\Microsoft\\Windows\\Start Menu\\Programs\\Startup\\AirPods Service.lnk");
                    MessageBox.Show("Deleted shortcut", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    CreateShortcut("AirPods Service", Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) + "\\Microsoft\\Windows\\Start Menu\\Programs\\Startup\\", Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Service.exe"));
                    MessageBox.Show("Created shortcut", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception err)
            {
                MessageBox.Show("Unable to create shortcut, try running the program as administrator.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void startStopServiceButton_Click_1(object sender, EventArgs e)
        {
            System.Diagnostics.Process[] p = System.Diagnostics.Process.GetProcessesByName("Service");
            if (p.Length < 1)
            {
                System.Diagnostics.Process.Start("Service.exe");
                MessageBox.Show("Started process!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                foreach (var i in p)
                    i.Kill();
                MessageBox.Show("Killed process!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}