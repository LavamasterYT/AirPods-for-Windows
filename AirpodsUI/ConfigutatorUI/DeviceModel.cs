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
    public partial class PairedDevices
    {
        [JsonProperty("Devices")]
        public List<Device> Devices { get; set; }

        public PairedDevices()
        {
            Devices = new List<Device>();
        }
    }

    public partial class Device
    {
        [JsonProperty("DeviceType")]
        public string DeviceType { get; set; }

        [JsonProperty("DeviceName")]
        public string DeviceName { get; set; }

        [JsonProperty("DeviceAddress")]
        public string DeviceAddress { get; set; }

        [JsonProperty("TemplateLocation")]
        public string TemplateLocation { get; set; }
    }

    public partial class PairedDevices
    {
        public static PairedDevices FromJson(string json) => JsonConvert.DeserializeObject<PairedDevices>(json, ConfigutatorUI.Converter.Settings);
    }

    public static class Serialize
    {
        public static string ToJson(this PairedDevices self) => JsonConvert.SerializeObject(self, ConfigutatorUI.Converter.Settings);
    }

    internal static class Converter
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

    internal class ParseStringConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(long) || t == typeof(long?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            long l;
            if (Int64.TryParse(value, out l))
            {
                return l;
            }
            throw new Exception("Cannot unmarshal type long");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (long)untypedValue;
            serializer.Serialize(writer, value.ToString());
            return;
        }

        public static readonly ParseStringConverter Singleton = new ParseStringConverter();
    }
}
