using EcoLife.RecommendationApi.Models;
using EcoLife.RecommendationApi.Models.Dto;
using EcoLife.RecommendationApi.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EcoLife.RecommendationApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecommendationController : ControllerBase
    {
        private readonly IRecommendationRepository _recommendationrepository;
        public RecommendationController(IRecommendationRepository recommendationrepository)
        {
            _recommendationrepository = recommendationrepository;
        }
        [HttpGet("{userid}")]
        public async Task<ActionResult<IEnumerable<RecomendationEntity>>> GetRecommenationsbyUserIdAsync(int userid)
        {
            var entities = await _recommendationrepository.GetRecomendations(userid);
            return Ok(entities);
        }
        [HttpPost]
        public async Task<ActionResult<RecomendationEntity>> PostRecommenations(RecommendationDto entity)
        {
            if (entity != null)
            {
                var ent = await _recommendationrepository.PostRecommendations(entity);
                return Ok(ent);
            }
            return BadRequest();
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<RecomendationEntity>> PutRecommendationsAsync(int id, RecommendationDto entity)
        {

            var ent = await _recommendationrepository.PutRecommendation(id, entity);
            if (ent != null)
                return Ok(ent);
            return BadRequest();
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> DeleteRecommendationsAsync(int id)
        {

            var ent = await _recommendationrepository.DeleteRecommendations(id);
            if (ent == true)
                return Ok(new
                {
                    message = "Record Deleted"
                });
            return BadRequest();
        }
    }
}
