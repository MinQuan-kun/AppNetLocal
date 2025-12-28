using Newtonsoft.Json;

namespace Test.DTOs
{
    public class Computer
    {
        [JsonProperty("computer_id")]
        public int computer_id { get; set; }

        [JsonProperty("computer_name")]
        public string computer_name { get; set; }

        [JsonProperty("x")]
        public int x { get; set; }

        [JsonProperty("y")]
        public int y { get; set; }

        [JsonProperty("status")]
        public string status { get; set; }

        [JsonProperty("current_user_id")]
        public int? current_user_id { get; set; }
    }
}