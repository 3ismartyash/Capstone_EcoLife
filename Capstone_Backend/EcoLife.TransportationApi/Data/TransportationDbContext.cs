using EcoLife.TransportationApi.Models;
using Microsoft.EntityFrameworkCore;

namespace EcoLife.TransportationApi.Data
{
    public class TransportationDbContext : DbContext
    {

        public TransportationDbContext(DbContextOptions<TransportationDbContext> options) : base(options)
        {
        }

        public DbSet<TransportationEntity> transportationEntities { get; set; }
    }
}
