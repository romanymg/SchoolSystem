using Common.DTOs;
using Common.Enums;
using Common.Models;
using System.Configuration;
using System.Text.Json;

namespace PrintApp.Services
{
    public class ApiResponse<T>
    {
        public bool Success => Code == ResponseCode.OK;
        public ResponseCode Code { get; set; }
        public string? Message { get; set; }
        public T? Data { get; set; }
    }

    internal class AppServices()
    {
        string ApiUrl = ConfigurationManager.AppSettings["ApiUrl"];

        internal async Task<List<UserEntity>> GetUsers(int userTypeId, int printed, string code)
        {
            try
            {
                string url = $"{ApiUrl}Api/General/GetUsers?userTypeId={userTypeId}&printed={printed}&code={Uri.EscapeDataString(code)}";

                using (HttpClient client = new HttpClient())
                {
                    HttpResponseMessage response = await client.GetAsync(url);
                    response.EnsureSuccessStatusCode();

                    string json = await response.Content.ReadAsStringAsync();

                    var options = new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    };

                    var result = JsonSerializer.Deserialize<ApiResponse<List<UserEntity>>>(json, options);
                    return result?.Data ?? new List<UserEntity>();
                }

            }
            catch (Exception e)
            {
                return new List<UserEntity>();
            }
        }

    }
}
