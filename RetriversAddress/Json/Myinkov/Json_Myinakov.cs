using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace BSRetriever.RetriversAddress.Json.Myinkov
{
    internal partial class Json_Myinakov
    {
        [JsonProperty("result")]
        public long Result { get; set; }

        [JsonProperty("data")]
        public Data Data { get; set; }
    }

    internal partial class Data
    {
        [JsonProperty("lon")]
        public double Lon { get; set; }

        [JsonProperty("range")]
        public long Range { get; set; }

        [JsonProperty("time")]
        public long Time { get; set; }

        [JsonProperty("lat")]
        public double Lat { get; set; }
    }

    internal partial class JsonResponseMyinakov
    {
        public static Json_Myinakov FromJson(string json) => JsonConvert.DeserializeObject<Json_Myinakov>(json, Converter.Settings);
    }

    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters = {
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }
}