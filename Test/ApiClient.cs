using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Test.DTOs;

namespace Test
{
    // Model Máy Tính (Đã thêm JsonProperty)
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

    public class ApiResponse
    {
        [JsonProperty("message")]
        public string message { get; set; }

        [JsonProperty("new_balance")]
        public int? new_balance { get; set; }
    }

    public static class ApiClient
    {
        public static string BaseUrl = "https://internet-coffee-manager.onrender.com/api";
        private static readonly HttpClient client = new HttpClient();

        public static string Token { get; set; } = "";
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
                try
                {
                    dynamic errorObj = JsonConvert.DeserializeObject(responseString);
                    throw new Exception(errorObj.message.ToString());
                }
                catch
                {
                    throw new Exception($"Lỗi {response.StatusCode}: {responseString}");
                }
            }

            if (typeof(T) == typeof(object)) return default(T);
            return JsonConvert.DeserializeObject<T>(responseString);
        }

        public static async Task<List<Computer>> GetComputersAsync()
        {
            try
            {
                if (!string.IsNullOrEmpty(Token))
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Token);

                var response = await client.GetAsync($"{BaseUrl}/computers");
                if (response.IsSuccessStatusCode)
                {
                    string json = await response.Content.ReadAsStringAsync();
                    var settings = new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore };
                    return JsonConvert.DeserializeObject<List<Computer>>(json, settings);
                }
            }
            catch { }
            return new List<Computer>();
        }

        public static async Task<List<MenuItemDTO>> GetMenu()
        {
            try
            {
                var response = await client.GetAsync($"{BaseUrl}/menu");
                if (response.IsSuccessStatusCode)
                {
                    return JsonConvert.DeserializeObject<List<MenuItemDTO>>(await response.Content.ReadAsStringAsync());
                }
            }
            catch { }
            return new List<MenuItemDTO>();
        }
    }
}