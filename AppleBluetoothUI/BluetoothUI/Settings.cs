using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Timers;
using Microsoft.Win32;
using System.Threading;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace BluetoothUI
{
    class Settings
    {
        public static string GetTemplateName() => Registry.CurrentUser.OpenSubKey("SOFTWARE\\AppleBluetoothUI").GetValue("TemplateName", "AirPods Generation 1").ToString();
        public static bool CheckIfUsingImage() => bool.Parse((Registry.CurrentUser.OpenSubKey("SOFTWARE\\AppleBluetoothUI").GetValue("UsingImage", 0).ToString() == "0") ? "false" : "true");
        public static string GetAssetSource() => Registry.CurrentUser.OpenSubKey("SOFTWARE\\AppleBluetoothUI").GetValue("AssetLocation", "./Templates/Assets/ag1.mp4").ToString();
        public static bool CheckIfUsingStaticText() => bool.Parse((Registry.CurrentUser.OpenSubKey("SOFTWARE\\AppleBluetoothUI").GetValue("UsingStaticText", 0).ToString() == "0") ? "false" : "true");
        public static string GetStaticText() => Registry.CurrentUser.OpenSubKey("SOFTWARE\\AppleBluetoothUI").GetValue("StaticText", "AirPods").ToString();
        public static string GetButtonText() => Registry.CurrentUser.OpenSubKey("SOFTWARE\\AppleBluetoothUI").GetValue("ButtonText", "Done").ToString();
        public static string GetDeviceName() => Registry.CurrentUser.OpenSubKey("SOFTWARE\\AppleBluetoothUI").GetValue("DeviceName", "AirPods").ToString();
    }
}
