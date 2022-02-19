
namespace Gamers_Hub_Butler__Code.APIS
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class YGOhub 
    {
        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("card")]
        public Card Card { get; set; }
    }

    public partial class Card
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("image_path")]
        public Uri ImagePath { get; set; }

        [JsonProperty("thumbnail_path")]
        public Uri ThumbnailPath { get; set; }

        [JsonProperty("text")]
        public string Text { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("number")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long Number { get; set; }
    }

    public partial class YGOhub
    {
        public static YGOhub FromJson(string json) => JsonConvert.DeserializeObject<YGOhub>(json, Converter.Settings);
    }
}
