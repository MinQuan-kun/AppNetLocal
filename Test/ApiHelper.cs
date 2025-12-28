using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Test.DTOs;

namespace Test
{
    // --- MODELS ---
    public class LoginResponse
    {
        public string token { get; set; }
        public Test.DTOs.UserDTO user { get; set; } 
    }

    public class User
    {
        public int user_id { get; set; }
        public string user_name { get; set; }
        public int role_id { get; set; }
        public int balance { get; set; }
    }

    public class Computer
    {
        public int computer_id { get; set; }
        public string computer_name { get; set; }
        public int x { get; set; }
        public int y { get; set; }
        public string status { get; set; } // "trong", "co nguoi", "dat truoc", "bao tri"
        public int? current_user_id { get; set; }
    }

    public class ApiResponse
    {
        public string message { get; set; }
        public int? new_balance { get; set; }
    }

    // --- API CLIENT ---
    public static class ApiClient
    {
        // Thay đường dẫn này bằng URL Render của bạn
        public static string BaseUrl = "https://cyberops-api.onrender.com/api";
        private static HttpClient client = new HttpClient();
        public static string Token { get; set; }
        public static UserDTO CurrentUser { get; set; }
        public static async Task<T> PostAsync<T>(string endpoint, object data)
        {
            var json = JsonConvert.SerializeObject(data);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            if (!string.IsNullOrEmpty(Token))
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Token);

            var response = await client.PostAsync($"{BaseUrl}{endpoint}", content);
            var responseString = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                // Parse lỗi từ server trả về
                dynamic error = JsonConvert.DeserializeObject(responseString);
                throw new Exception(error.message.ToString());
            }

            return JsonConvert.DeserializeObject<T>(responseString);
        }

        public static async Task<List<Computer>> GetComputersAsync()
        {
            if (!string.IsNullOrEmpty(Token))
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Token);

            var response = await client.GetAsync($"{BaseUrl}/computers");
            var responseString = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<Computer>>(responseString);
        }
    }
}