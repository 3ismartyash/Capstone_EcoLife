using System.ComponentModel.DataAnnotations;

namespace EcoLife.TransportationApi.Models
{
    public class TransportationEntity
    {
        [Key]
        public int TransportationId { get; set; }
        public int UserId { get; set; }
        public double PetrolUsage { get; set; } = 0;
        public double DieselUsage { get; set; } = 0;
        public double CNGUsage { get; set; } = 0;
        public DateTime RecordedDate { get; set; }
        public double TranportEmmision { get; set; } = 0;

    }
}
