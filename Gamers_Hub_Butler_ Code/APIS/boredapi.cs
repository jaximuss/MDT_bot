
namespace Gamers_Hub_Butler__Code.APIS
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    /// <summary>
    /// activity of bored api
    /// </summary>
    public partial class Boredapi
    {
        [JsonProperty("activity")]
        public string Activity { get; set; }

        [JsonProperty("accessibility")]
        public double Accessibility { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("participants")]
        public long Participants { get; set; }

        [JsonProperty("price")]
        public double Price { get; set; }

        [JsonProperty("link")]
        public Uri Link { get; set; }

        [JsonProperty("key")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long Key { get; set; }
    }
    public partial class Boredapi
    {
        public static Boredapi FromJson(string json) => JsonConvert.DeserializeObject<Boredapi>(json, Converter.Settings);
    }

    public static class Serialize2
    {
        public static string ToJson(this Boredapi self) => JsonConvert.SerializeObject(self, Converter.Settings);
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
}


