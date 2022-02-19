
namespace Gamers_Hub_Butler__Code.APIS
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;


    public static class Serialize
    {
        public static string ToJson(this YGOhub self) => JsonConvert.SerializeObject(self, Converter.Settings);
    }
}
