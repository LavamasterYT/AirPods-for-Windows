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
    class CustomTemplate
    {
        public string templatename { get; set; } = "AirPods Generation 1";
        public int usingimage { get; set; } = 0;
        public string iconlocation { get; set; } = "Templates/Assets/ag1.mp4";
        public int statictext { get; set; } = 0;
        public string staticname { get; set; } = "AirPods";
        public string buttontext { get; set; } = "Done";
    }
}
