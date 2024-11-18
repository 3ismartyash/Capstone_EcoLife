using EcoLife.RecommendationApi.Models;
using EcoLife.RecommendationApi.Models.Dto;

namespace EcoLife.RecommendationApi.Repository
{
    public interface IRecommendationRepository
    {
        Task<IEnumerable<RecomendationEntity>> GetRecomendations(int userid);
        Task<RecomendationEntity> PostRecommendations(RecommendationDto recommendation);
        Task<RecomendationEntity> PutRecommendation(int id,RecommendationDto recommendation);
        Task<bool> DeleteRecommendations(int id);
        Task<string> Categorize(double totalemissions);
        Task<string> Message(string category);   
    }
}
