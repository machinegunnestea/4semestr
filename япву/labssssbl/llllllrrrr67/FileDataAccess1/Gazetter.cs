using System;
using Newtonsoft.Json;

namespace lab6.FileDataAccess
{
    public class Gazetter
    {
        [JsonProperty("Country")]
        public string Country { get; set; }

        [JsonProperty("Square")]
        public double Square { get; set; }

        [JsonProperty("Population")]
        public double Population { get; set; }

        [JsonProperty("Continent")]
        public string Continent { get; set; }

        [JsonProperty("Capital")]
        public string Capital { get; set; }
    }
}
