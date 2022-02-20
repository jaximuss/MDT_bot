using System;
using System.Collections.Generic;
using System.Text;

namespace Gamers_Hub_Butler__Code.yugiohapis
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class Yugioh
    {
        [JsonProperty("data")]
        public Data[] Data { get; set; }
    }

    public partial class Data
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("desc")]
        public string Desc { get; set; }

        [JsonProperty("atk")]
        public long Atk { get; set; }

        [JsonProperty("def")]
        public long Def { get; set; }

        [JsonProperty("level")]
        public long Level { get; set; }

        [JsonProperty("race")]
        public string Race { get; set; }

        [JsonProperty("attribute")]
        public string Attribute { get; set; }

        [JsonProperty("archetype")]
        public string Archetype { get; set; }
    }

    public partial class Yugioh
    {
        public static Yugioh FromJson(string json) => JsonConvert.DeserializeObject<Yugioh>(json, Converter.Settings);
    }

    public static class Serialize
    {
        public static string ToJson(this Yugioh self) => JsonConvert.SerializeObject(self, Converter.Settings);
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
