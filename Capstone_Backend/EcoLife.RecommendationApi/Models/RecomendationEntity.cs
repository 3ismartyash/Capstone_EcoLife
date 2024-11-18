using System.ComponentModel.DataAnnotations;

namespace EcoLife.RecommendationApi.Models
{
    public class RecomendationEntity
    {
        [Key] 
        public int RecommendationId { get; set; }
        public int UserId { get; set; }
        public double TotalEmissions { get; set; }
        public string Category { get; set; }
        public string Message { get; set; }
        public DateOnly RecordedDate { get; set; }
        
    }
}
