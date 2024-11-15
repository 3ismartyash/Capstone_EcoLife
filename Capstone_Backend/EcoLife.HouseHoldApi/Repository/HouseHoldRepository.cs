using EcoLife.HouseHoldApi.Data;
using EcoLife.HouseHoldApi.Models;
using EcoLife.HouseHoldApi.Models.Dto;
using Microsoft.EntityFrameworkCore;

namespace EcoLife.HouseHoldApi.Repository
{
    public class HouseHoldRepository : IHouseHoldRepository
    {
        private readonly HouseHoldDbContext _db;
        public HouseHoldRepository(HouseHoldDbContext db)
        {
            _db = db;
        }
        public async Task<bool> DeleteHouseHoldEntity(int id)
        {
            var ent = await _db.HouseHoldEntities.FindAsync(id);
            if (ent != null)
            {
                _db.HouseHoldEntities.Remove(ent);
                await _db.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<IEnumerable<HouseHoldEntity>> GetHouseHoldEntities()
        {
            return await _db.HouseHoldEntities.ToListAsync();
        }

        public async Task<IEnumerable<HouseHoldEntity>> GetHouseHoldEntityById(int userid)
        {
            return await _db.HouseHoldEntities.Where(en => en.UserId == userid).ToListAsync();
        }



        
        public async Task<HouseHoldEntity> PostHouseHoldEntity(HouseHoldDto entity)
        {
            var ent = new HouseHoldEntity()
            {
                UserId = entity.UserId,
                ElectricityUsage = entity.ElectricityUsage,
                LPGUsage = entity.LPGUsage,
                CoalUsage = entity.CoalUsage,
                RecordedDate = DateTime.UtcNow,
                HouseHoldEmission = entity.LPGUsage + entity.CoalUsage + entity.ElectricityUsage
            };
            _db.HouseHoldEntities.Add(ent);
            await _db.SaveChangesAsync();   
            return ent;
            
        }

        public async Task<HouseHoldEntity> PutHouseHoldEntity(int id, HouseHoldDto entity)
        {
            var ent = await _db.HouseHoldEntities.FindAsync(id);
            if(ent != null)
            {
                ent.ElectricityUsage = entity.ElectricityUsage;
                ent.CoalUsage = entity.CoalUsage;
                ent.LPGUsage = entity.LPGUsage;
                await _db.SaveChangesAsync();
            }
            return ent;

        }
    }
}
