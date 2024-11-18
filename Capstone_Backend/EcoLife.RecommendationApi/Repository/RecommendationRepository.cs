using EcoLife.RecommendationApi.Data;
using EcoLife.RecommendationApi.Models;
using EcoLife.RecommendationApi.Models.Dto;
using Microsoft.EntityFrameworkCore;
using System;

namespace EcoLife.RecommendationApi.Repository
{
    public class RecommendationRepository : IRecommendationRepository
    {
        private readonly RecommendationDbContext _db;
        public RecommendationRepository(RecommendationDbContext db)
        {
            _db = db;
        }

        public async Task<string> Categorize(double totalEmission)
        {
            if (totalEmission <= 150)
                return "Good";

            else if (totalEmission > 150 && totalEmission <= 400)
                return "Satisfactory";

            else if (totalEmission > 400 && totalEmission <= 900)
                return "Moderate";

            else if (totalEmission > 900 && totalEmission <= 1400)
                return "Poor";

            else if (totalEmission > 1400 && totalEmission <= 1999)
                return "Very Poor";

            else
                return "Severe";
        }

        public async Task<bool> DeleteRecommendations(int id)
        {
            var ent = await _db.RecomendationEntities.FindAsync(id);
            if (ent != null)
            {
                _db.RecomendationEntities.Remove(ent);
                await _db.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<IEnumerable<RecomendationEntity>> GetRecomendations(int userid)
        {
            return await _db.RecomendationEntities.Where(en => en.UserId == userid).ToListAsync();
        }

        public async Task<string> Message(string category)
        {
            await Task.Delay(1);
            switch (category)
            {
                case "Good":
                    return GetRandomMessage(new[]
                    {
                        "Excellent work! Your carbon footprint is impressively low, showcasing your strong commitment to the environment.",
                        "You are truly making a difference! Your lifestyle choices reflect a deep care for the planet.",
                        "Hats off to you! Your efforts to minimize your carbon impact are an inspiration.",
                        "Amazing! Your low carbon footprint shows you’re leading by example in sustainable living.",
                        "Congratulations! You are among the few making a meaningful effort to protect our planet for future generations."
                    });

                case "Satisfactory":
                    return GetRandomMessage(new[]
                    {
                        "Good job! Your carbon footprint is satisfactory, but there’s always room for improvement.",
                        "Not bad! You’re doing reasonably well, though small changes could further reduce your impact.",
                        "Keep it up! Your footprint is acceptable, but some tweaks here and there could make a big difference.",
                        "Well done! You’re maintaining a decent footprint. Let’s aim for greatness now!",
                        "You’re on the right track! With a little extra effort, you could significantly reduce your footprint."
                    });

                case "Moderate":
                    return GetRandomMessage(new[]
                    {
                        "Your carbon footprint is moderate. It’s a good time to explore ways to reduce it further.",
                        "Not too bad, but there’s work to be done! Start with small, impactful changes to lower your footprint.",
                        "You’re in the middle ground. Why not aim higher? The planet will thank you for it.",
                        "A moderate impact is better than high, but let’s take steps to minimize it further.",
                        "Your current footprint is manageable but could benefit from proactive efforts to reduce emissions."
                    });

                case "Poor":
                    return GetRandomMessage(new[]
                    {
                        "Your carbon footprint is poor. This is a wake-up call to rethink your habits and make positive changes.",
                        "It’s time to take action! Your footprint is harming the environment more than you may realize.",
                        "Urgent improvements are needed. Small but consistent steps can help lower your impact.",
                        "Your footprint indicates excessive carbon emissions. Let’s start reducing them today.",
                        "This level of carbon impact is unsustainable. Begin your journey toward eco-friendliness now."
                    });

                case "Very Poor":
                    return GetRandomMessage(new[]{
                        "Your carbon footprint is off the charts! It’s time to make drastic changes before it’s too late.",
                        "Whoa! Your footprint is dangerously high. Start making green choices now, or the planet will be in serious trouble.",
                        "Your carbon impact is severe! It's high time to rethink your lifestyle and reduce emissions drastically.",
                        "Yikes! Your footprint is alarmingly large. It's time to make big changes for the planet’s future.",
                        "The environment is calling for help! Your carbon footprint needs urgent attention before it spirals out of control.",
                        "This is bad. Your footprint is shockingly high, and it’s up to you to fix it before it’s too late.",
                        "You’re running out of time! Start making eco-friendly choices now or face the consequences later.",
                        "The Earth is begging you for help. Your carbon footprint is far too high, and immediate action is needed.",
                        "It’s a race against time. Your footprint is unsustainable, and we need to make changes now to secure the future.",
                        "Urgent action is required! Your footprint is like a ticking time bomb – let’s defuse it before it's too late!"
                    });

                case "Severe":
                    return "🌍 There's no place for you here with that carbon footprint! Time to leave Earth ASAP. For more details, contact @SpaceX or Elon Musk 🚀";

                default:
                    return "Error: Invalid category. Please provide a valid category.";
            }
        }

        private string GetRandomMessage(string[] messages)
        {
            var random = new Random();
            return messages[random.Next(messages.Length)];
        }

        public async Task<RecomendationEntity> PostRecommendations(RecommendationDto entity)
        {
            var category = await Categorize(entity.TotalEmissions);
            var message = await Message(category);
            var ent = new RecomendationEntity()
            {
                UserId = entity.UserId,
                TotalEmissions = entity.TotalEmissions,
                Category = category,
                Message = message,
                RecordedDate = entity.RecordedDate,

            };
            _db.RecomendationEntities.Add(ent);
            await _db.SaveChangesAsync();
            return ent;
        }

        public async Task<RecomendationEntity> PutRecommendation(int id, RecommendationDto entity)
        {
            var category = await Categorize(entity.TotalEmissions);
            var message = await Message(category);
            var ent = await _db.RecomendationEntities.FindAsync(id);
            if (ent != null)
            {
                ent.TotalEmissions = entity.TotalEmissions;
                ent.Category = category;
                ent.Message = message;
                await _db.SaveChangesAsync();
            }
            return ent;
        }
    }
}
