using EcoLife.RecommendationApi.Models;
using Microsoft.EntityFrameworkCore;

namespace EcoLife.RecommendationApi.Data
{
    public class RecommendationDbContext : DbContext
    {
        public RecommendationDbContext(DbContextOptions<RecommendationDbContext> options) : base(options)
        {
        }
        public DbSet<RecomendationEntity> RecomendationEntities { get; set; }
    }
}
