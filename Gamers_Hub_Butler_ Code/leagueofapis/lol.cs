
namespace Gamers_Hub_Butler__Code.leagueofapis
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class Lol
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("format")]
        public string Format { get; set; }

        [JsonProperty("version")]
        public string Version { get; set; }

        [JsonProperty("data")]
        public Data Data { get; set; }
    }

    public partial class Data
    {
        [JsonProperty("Aatrox")]
        public Aatrox Aatrox { get; set; }
    }

    public partial class Aatrox
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("image")]
        public Image Image { get; set; }
    }

    public partial class Image
    {
        [JsonProperty("full")]
        public string Full { get; set; }
    }

    public partial class Lol
    {
        public static Lol FromJson(string json) => JsonConvert.DeserializeObject<Lol>(json,Converter.Settings);
    }
   
    public static class Serialize
    {
        public static string ToJson(this Lol self) => JsonConvert.SerializeObject(self, Converter.Settings);
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


