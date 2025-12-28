using Newtonsoft.Json;
using System;

namespace Test.DTOs
{
        public class MenuItemDTO
        {
            [JsonProperty("id")]
            public int id { get; set; }

            [JsonProperty("name")]
            public string name { get; set; }

            [JsonProperty("description")]
            public string description { get; set; }

            [JsonProperty("price")]
            public decimal price { get; set; }

            [JsonProperty("image_url")]
            public string image_url { get; set; }

            [JsonProperty("category_id")]
            public int category_id { get; set; }

            [JsonProperty("is_available")]
            public bool is_available { get; set; }

    }
}