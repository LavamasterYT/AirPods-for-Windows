using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfigutatorUI
{
    public partial class Template
    {
        [JsonProperty("TemplateName")]
        public string TemplateName { get; set; }

        [JsonProperty("UsingImage")]
        public bool UsingImage { get; set; }

        [JsonProperty("AssetLocation")]
        public string AssetLocation { get; set; }

        [JsonProperty("UseDeviceName")]
        public bool UseDeviceName { get; set; }

        [JsonProperty("DefaultDeviceName")]
        public string DefaultDeviceName { get; set; }

        [JsonProperty("ButtonText")]
        public string ButtonText { get; set; }

        [JsonProperty("LoopAnimation")]
        public bool LoopAnimation { get; set; }

        [JsonProperty("WindowBackground")]
        public string WindowBackground { get; set; }

        [JsonProperty("WindowForeground")]
        public string WindowForeground { get; set; }

        [JsonProperty("ButtonBackground")]
        public string ButtonBackground { get; set; }

        [JsonProperty("ButtonForeground")]
        public string ButtonForeground { get; set; }

        [JsonProperty("Tint")]
        public string Tint { get; set; }
    }

    public partial class Template
    {
        public static Template FromJson(string json) => JsonConvert.DeserializeObject<Template>(json, ConfigutatorUI.Converter1.Settings);
    }

    public static class Serialize1
    {
        public static string ToJson(this Template self) => JsonConvert.SerializeObject(self, ConfigutatorUI.Converter1.Settings);
    }

    internal static class Converter1
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }
}
