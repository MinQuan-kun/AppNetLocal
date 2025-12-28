using System;
using Newtonsoft.Json;

namespace Test.DTOs
{
    public class UserDTO
    {
        [JsonProperty("user_id")]
        public int user_id { get; set; }

        [JsonProperty("user_name")]
        public string user_name { get; set; }

        [JsonProperty("role_id")]
        public int role_id { get; set; }

        [JsonProperty("balance")]
        public int balance { get; set; }

        [JsonProperty("avatar")]
        public string avatar { get; set; }
    }
}