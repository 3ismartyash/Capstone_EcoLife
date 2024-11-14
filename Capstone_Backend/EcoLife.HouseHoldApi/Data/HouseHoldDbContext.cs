using EcoLife.HouseHoldApi.Models;
using Microsoft.EntityFrameworkCore;

namespace EcoLife.HouseHoldApi.Data
{
    public class HouseHoldDbContext : DbContext
    {
        public HouseHoldDbContext(DbContextOptions<HouseHoldDbContext> options): base(options)
        {
            
        }
        public DbSet<HouseHoldEntity> HouseHoldEntities { get; set; }
    }
}
