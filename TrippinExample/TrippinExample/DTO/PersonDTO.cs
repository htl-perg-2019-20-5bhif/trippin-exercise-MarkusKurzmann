using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace TrippinExample.DTO
{
    public class PersonDTO
    {
        [JsonPropertyName("UserName")]
        public string username { get; set; }

        [JsonPropertyName("FirstName")]
        public string firstname { get; set; }

        [JsonPropertyName("LastName")]
        public string lastname { get; set; }

        [JsonPropertyName("Emails")]
        public IEnumerable<string> emails { get; set; }

        [JsonPropertyName("AddressInfo")]
        public IEnumerable<AddressInfoDTO> addressInfo { get; set; }

        public PersonDTO(string username, string firstname, string lastname, IEnumerable<string> emails, IEnumerable<AddressInfoDTO> addressInfo)
        {
            this.username = username;
            this.firstname = firstname;
            this.lastname = lastname;
            this.emails = emails;
            this.addressInfo = addressInfo;
        }

        public PersonDTO(NewPersonDTO user)
        {
            this.username = user.UserName;
            this.firstname = user.FirstName;
            this.lastname = user.LastName;

            this.emails = new List<string>() { user.Email };

            this.addressInfo = new List<AddressInfoDTO>()
                { new AddressInfoDTO(user.Address, new CityDTO(user.CityName, user.Country, "")) };
        }
    }
}
