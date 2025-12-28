using Newtonsoft.Json;

namespace Test.DTOs
{
    public class ApiResponse
    {
        [JsonProperty("message")]
        public string message { get; set; }

        [JsonProperty("new_balance")]
        public int? new_balance { get; set; }
    }
}