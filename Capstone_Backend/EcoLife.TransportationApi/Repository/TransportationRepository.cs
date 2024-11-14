using EcoLife.TransportationApi.Data;
using EcoLife.TransportationApi.Models;
using EcoLife.TransportationApi.Models.Dto;
using Microsoft.EntityFrameworkCore;

namespace EcoLife.TransportationApi.Repository
{
    public class TransportationRepository : ITransportationRepository
    {
        private readonly TransportationDbContext _db;

        public TransportationRepository(TransportationDbContext db)
        {
            _db = db;
        }

        public async Task<bool> DeleteTransportationEntity(int id)
        {
            var ent = await _db.transportationEntities.FindAsync(id);
            if(ent != null)
            {
                _db.transportationEntities.Remove(ent);
                await _db.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<IEnumerable<TransportationEntity>> GetTransportationById(int userid)
        {
            return await _db.transportationEntities.Where(en => en.UserId == userid).ToListAsync();
        }

        public async Task<IEnumerable<TransportationEntity>> GetTransportationEntities()
        {
            return await _db.transportationEntities.ToListAsync();
        }

        //public async Task<TransportationEntity> postTransportationEntity(int userid, TransportationDto entity)
        public async Task<TransportationEntity> postTransportationEntity(TransportationDto entity)
        {
            double? calculate = (entity.PetrolUsage + entity.DieselUsage + entity.CNGUsage);
            var ent = new TransportationEntity()
            {
                //UserId = userid
                PetrolUsage = entity.PetrolUsage,
                DieselUsage = entity.DieselUsage,
                CNGUsage = entity.CNGUsage,
                RecordedDate = entity.RecordedDate,
                TranportEmmision = (double)calculate
            };
            _db.transportationEntities.Add(ent);
            await _db.SaveChangesAsync();
            return ent;
        }

        public async Task<TransportationEntity> putTransportationEntity(int id, TransportationDto entity)
        {
            var ent = await _db.transportationEntities.FindAsync(id);
            if (ent != null)
            {
                ent.PetrolUsage = entity.PetrolUsage;
                ent.DieselUsage = entity.DieselUsage;
                ent.CNGUsage = entity.CNGUsage;
                await _db.SaveChangesAsync();
            }
            return ent;
        }

    }
}
