using System;

namespace Test.DTOs
{
    public class LoginResponse
    {
        public string token { get; set; }
        public UserDTO user { get; set; }
        public string message { get; set; }
    }
}