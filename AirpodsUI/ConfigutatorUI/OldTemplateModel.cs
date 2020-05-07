using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Globalization;

namespace ConfigutatorUI
{
    public partial class OldTemplate
    {
        [JsonProperty("templatename")]
        public string Templatename { get; set; }

        [JsonProperty("usingimage")]
        public long Usingimage { get; set; }

        [JsonProperty("iconlocation")]
        public string Iconlocation { get; set; }

        [JsonProperty("statictext")]
        public long Statictext { get; set; }

        [JsonProperty("staticname")]
        public string Staticname { get; set; }

        [JsonProperty("buttontext")]
        public string Buttontext { get; set; }
    }

    public partial class OldTemplate
    {
        public static OldTemplate FromJson(string json) => JsonConvert.DeserializeObject<OldTemplate>(json, ConfigutatorUI.Converter2.Settings);
    }

    internal static class Converter2
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
