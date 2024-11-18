namespace EcoLife.RecommendationApi.Models.Dto
{
    public class RecommendationDto
    {
        public int UserId { get; set; }
        public double TotalEmissions { get; set; }
        public DateOnly RecordedDate { get; set; }
    }
}
