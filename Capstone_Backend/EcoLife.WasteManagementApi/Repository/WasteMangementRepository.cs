﻿using EcoLife.WasteManagementApi.Data;
using EcoLife.WasteManagementApi.Models;
using EcoLife.WasteManagementApi.Models.Dto;
using Microsoft.EntityFrameworkCore;

namespace EcoLife.WasteManagementApi.Repository
{
    public class WasteMangementRepository : IWasteManagementRepository
    {
        private readonly WasteManagementDbContext _db;

        public WasteMangementRepository(WasteManagementDbContext db)
        {
            _db = db;
        }

        public async Task<bool> DeleteWasteMangementEntity(int id)
        {
            var ent = await _db.WasteManagementEntities.FindAsync(id);
            if (ent != null)
            {
                _db.WasteManagementEntities.Remove(ent);
                await _db.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<IEnumerable<WasteManagementEntity>> GetWasteManagementEntities()
        {
            return await _db.WasteManagementEntities.ToListAsync();
        }

        public async Task<IEnumerable<WasteManagementEntity>> GetWasteMangementEntityById(int userid)
        {
            return await _db.WasteManagementEntities.Where(en => en.UserId == userid).ToListAsync();
        }

      

        public async Task<WasteManagementEntity> postWasteMangementEntity( WasteManagementDto entity)
        {
            double? calculate = (entity.RecycledWaste + entity.CompostWaste + entity.LandfillWaste);
            var ent = new WasteManagementEntity()
            {
                RecycledWaste = entity.RecycledWaste,
                CompostWaste = entity.CompostWaste,
                LandfillWaste = entity.LandfillWaste,
                RecordedDate = entity.RecordedDate,
                WasteEmmision = (double)calculate
            };
            _db.WasteManagementEntities.Add(ent);
            await _db.SaveChangesAsync();
            return ent;
        }

        public async Task<WasteManagementEntity> putWasteMangementEntity(int id, WasteManagementDto entity)
        {
            var ent = await _db.WasteManagementEntities.FindAsync(id);
            if (ent != null)
            {
                ent.RecycledWaste = entity.RecycledWaste;
                ent.CompostWaste = entity.CompostWaste;
                ent.LandfillWaste = entity.LandfillWaste;
                await _db.SaveChangesAsync();
            }
            return ent;
        }
    }
}