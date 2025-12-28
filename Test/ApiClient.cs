using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Windows.Forms;
using Test.DTOs;

namespace Test
{
    public static class ApiService
    {
        private static readonly string BaseUrl = "http://localhost:3636/api";
        private static readonly HttpClient client = new HttpClient();

        public static string CurrentToken = "";
        public static UserDTO CurrentUser { get; set; }
        public static async Task<bool> Login(string username, string password)
        {
            try
            {
                var loginData = new { user_name = username, password = password };
                var json = JsonConvert.SerializeObject(loginData);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await client.PostAsync($"{BaseUrl}/auth/login", content);
                string responseString = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    var result = JsonConvert.DeserializeObject<LoginResponse>(responseString);

                    CurrentToken = result.token;
                    CurrentUser = result.user;

                    client.DefaultRequestHeaders.Authorization =
                        new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", CurrentToken);

                    return true;
                }
                else
                {
                    MessageBox.Show("Lỗi: " + responseString);
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối: " + ex.Message);
                return false;
            }
        }

        public static async Task<List<MenuItemDTO>> GetMenu()
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync($"{BaseUrl}/menu");
                if (response.IsSuccessStatusCode)
                {
                    string json = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<List<MenuItemDTO>>(json);
                }
            }
            catch { }
            return new List<MenuItemDTO>();
        }
    }
}