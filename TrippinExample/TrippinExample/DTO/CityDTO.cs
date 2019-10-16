using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace TrippinExample.DTO
{
    public class CityDTO
    {
        [JsonPropertyName("Name")]
        public string cityName { get; set; }

        [JsonPropertyName("CountryRegion")]
        public string cityCountryRegion { get; set; }

        [JsonPropertyName("Region")]
        public string cityRegion { get; set; }

        public CityDTO(string cityname, string cityCountryRegion, string cityRegion)
        {
            this.cityName = cityname;
            this.cityCountryRegion = cityCountryRegion;
            this.cityRegion = cityRegion;
        }
    }
}
