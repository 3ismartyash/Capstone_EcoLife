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

        public async Task<TransportationEntity> postTransportationEntity(TransportationDto entity)
        {
            var userId = entity.UserId;

            var currentMonth = entity.RecordedDate.Month;
            var currentYear = entity.RecordedDate.Year;

            var existingRecord = await _db.transportationEntities
                .FirstOrDefaultAsync(h => h.UserId == userId &&
                                     h.RecordedDate.Month == currentMonth &&
                                     h.RecordedDate.Year == currentYear);
            if (existingRecord != null)
            {
                existingRecord.PetrolUsage = entity.PetrolUsage;
                existingRecord.DieselUsage = entity.DieselUsage;
                existingRecord.CNGUsage = entity.CNGUsage;
                existingRecord.TransportEmission = (entity.PetrolUsage * 2.3 + entity.DieselUsage * 2.68 + entity.CNGUsage * 2.75);
                existingRecord.RecordedDate = entity.RecordedDate;
                await _db.SaveChangesAsync();
                return existingRecord;
            }
            var ent = new TransportationEntity()
            {
                UserId = entity.UserId,
                PetrolUsage = entity.PetrolUsage,
                DieselUsage = entity.DieselUsage,
                CNGUsage = entity.CNGUsage,
                RecordedDate = entity.RecordedDate,
                TransportEmission = (entity.PetrolUsage * 2.3 + entity.DieselUsage * 2.68 + entity.CNGUsage * 2.75)
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
