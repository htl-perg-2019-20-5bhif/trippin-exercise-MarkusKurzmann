using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace TrippinExample.DTO
{
    public class AddressInfoDTO
    {
        [JsonPropertyName("Address")]
        public string address { get; set; }

        [JsonPropertyName("City")]
        public CityDTO addressInfo { get; set; }

        public AddressInfoDTO(string address, CityDTO addressInfo)
        {
            this.address = address;
            this.addressInfo = addressInfo;
        }
    }
}
