using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfigutatorUI
{
    class DefaultTemplate
    {
        public static string TemplateName { get { return "Default Template"; } }

        public static bool UsingImage { get { return false; } }

        public static string AssetLocation { get { return "$docs$\\AirPodsUI\\Assets\\ag1.mp4"; } }

        public static bool UseDeviceName { get { return true; } }

        public static string DefaultDeviceName { get { return "AirPods"; } }

        public static string ButtonText { get { return "Done"; } }

        public static bool LoopAnimation { get { return true; } }

        public static string WindowBackground { get { return "#FFFFFF"; } }

        public static string WindowForeground { get { return "#000000"; } }

        public static string ButtonBackground { get { return "#C2C2C2"; } }

        public static string ButtonForeground { get { return "#000000"; } }

        public static string Tint { get { return "#151515"; } }
    }
}
