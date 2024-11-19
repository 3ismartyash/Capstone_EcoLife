namespace EcoLife.AQIApi.Service
{
    public interface IAirQualityService
    {
        Task<string> GetAirQualityAsync(string city);
    }
}
