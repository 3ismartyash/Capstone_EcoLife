namespace EcoLife.AQIApi.Service
{
    public class AirQualityService:IAirQualityService
    {
        private readonly HttpClient _httpClient;
        private const string ApiKey = "4168897aab1422e35cea8d583f7602ac5b7d4289";
        private const string BaseUrl = "https://api.waqi.info/feed/";

        public AirQualityService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<string> GetAirQualityAsync(string city)
        {
            var url = $"{BaseUrl}{city}/?token={ApiKey}";
            var response = await _httpClient.GetStringAsync(url);
            return response;
        }
    }
}
