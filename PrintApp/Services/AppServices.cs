using Common.DTOs;
using Common.Enums;
using Common.Models;
using System.Configuration;
using System.Text.Json;
using Microsoft.Extensions.Configuration;

namespace PrintApp.Services
{
    public class ApiResponse<T>
    {
        public bool Success => Code == ResponseCode.OK;
        public ResponseCode Code { get; set; }
        public string? Message { get; set; }
        public T? Data { get; set; }
    }

    internal class AppServices
    {
        public string? ApiUrl { get; }

        public AppServices()
        {
            var config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();


            ApiUrl = config["ApiUrl"];
        }
        internal async Task<List<UserPrintDto>> GetUsers(int userTypeId, int printed, string code)
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

                    var result = JsonSerializer.Deserialize<ApiResponse<List<UserPrintDto>>>(json, options);
                    return result?.Data ?? new List<UserPrintDto>();
                }

            }
            catch (Exception e)
            {
                return new List<UserPrintDto>();
            }
        }
    }
}
