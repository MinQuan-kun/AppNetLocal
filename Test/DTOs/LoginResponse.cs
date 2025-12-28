using Newtonsoft.Json;

namespace Test.DTOs
{
    public class LoginResponse
    {
        [JsonProperty("token")]
        public string token { get; set; }

        [JsonProperty("user")]
        public UserDTO user { get; set; }
    }
}