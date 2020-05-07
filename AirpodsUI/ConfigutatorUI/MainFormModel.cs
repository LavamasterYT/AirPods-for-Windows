using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConfigutatorUI
{
    class MainFormModel
    {
        public PairedDevices devices;
        public List<Template> templates;
        public List<string> TemplateLocations;
        public int openedTemplate;
        public string appDocs;

        public MainFormModel()
        {
            devices = new PairedDevices();
            templates = new List<Template>();
            openedTemplate = 0;
            appDocs = CombinePaths(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "\\AirPodsUI");
            TemplateLocations = new List<string>();

            #region Directory Creation
            if (!Directory.Exists(appDocs))
            {
                Directory.CreateDirectory(appDocs);
            }

            if (!Directory.Exists(CombinePaths(appDocs, "Logs")))
            {
                Directory.CreateDirectory(CombinePaths(appDocs, "Logs"));
            }

            if (!Directory.Exists(CombinePaths(appDocs, "Assets")))
            {
                Directory.CreateDirectory(CombinePaths(appDocs, "Assets"));
            }

            if (!Directory.Exists(CombinePaths(appDocs, "Templates")))
            {
                Directory.CreateDirectory(CombinePaths(appDocs, "Templates"));
            }
            #endregion

            foreach (var i in Directory.GetFiles(CombinePaths(appDocs, "Templates")))
            {
                if (Path.GetExtension(i.ToLower()) == ".json")
                {
                    try { templates.Add(Template.FromJson(File.ReadAllText(i))); TemplateLocations.Add(i); }
                    catch (Exception e) { continue; }
                }
            }

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
                if (File.Exists(CombinePaths(appDocs, "PairedDevices.json")))
                    File.Delete(CombinePaths(appDocs, "PairedDevices.json"));
                File.WriteAllText(CombinePaths(appDocs, "PairedDevices.json"), devices.ToJson());
            }
        }

        public async void AddTemplate(string file)
        {
            string contents;
            Template template = new Template();

            using (StreamReader sr = new StreamReader(file))
            {
                contents = await sr.ReadToEndAsync();
            }

            template = Template.FromJson(contents);

            templates.Add(template);
            TemplateLocations.Add(file);
        }

        public void RefreshDevices()
        {
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
                if (File.Exists(CombinePaths(appDocs, "PairedDevices.json")))
                    File.Delete(CombinePaths(appDocs, "PairedDevices.json"));
                File.WriteAllText(CombinePaths(appDocs, "PairedDevices.json"), devices.ToJson());
            }
        }

        public void RemoveDeviceAt(int index)
        {
            devices.Devices.RemoveAt(index);
            string result = Serialize.ToJson(devices);
            using (StreamWriter sw = new StreamWriter(CombinePaths(appDocs, "\\PairedDevices.json")))
            {
                sw.WriteLine(result);
            }
            string newResult = "";
            using (StreamReader sr = new StreamReader(CombinePaths(appDocs, "\\PairedDevices.json")))
            {
                string line = "";
                while ((line = sr.ReadLine()) != null)
                    newResult += line;
            }
            devices = PairedDevices.FromJson(newResult);
        }

        public void RemoveTemplateAt(int index)
        {
            templates.RemoveAt(index);
            File.Delete(TemplateLocations[index]);
        }

        public void RefreshTemplates()
        {
            TemplateLocations.Clear();
            foreach (var i in Directory.GetFiles(CombinePaths(appDocs, "Templates")))
            {
                if (Path.GetExtension(i.ToLower()) == ".json")
                {
                    try { templates.Add(Template.FromJson(File.ReadAllText(i))); TemplateLocations.Add(i); }
                    catch (Exception e) { continue; }
                }
            }
        }

        public Color FromHex(string hexValue)
        {
            try
            {
                return ColorTranslator.FromHtml(hexValue);
            }
            catch (Exception e)
            {
                MessageBox.Show("A color value was in a incorrect syntax.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return Color.White;
            }
        }

        public string CombinePaths(string path1, string path2)
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

        public static string CombinePathsStatic(string path1, string path2)
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
}
