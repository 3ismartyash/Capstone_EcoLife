using System.ComponentModel.DataAnnotations;

namespace EcoLife.HouseHoldApi.Models
{
    public class HouseHoldEntity
    {
        [Key]
        public int HouseHoldId{ get; set; }
        public int UserId { get; set; }
        public double ElectricityUsage { get; set; } = 0;
        public double LPGUsage { get; set; } = 0;
        public double CoalUsage { get; set; } = 0;
        public DateTime RecordedDate { get; set; }
        public double HouseHoldEmisssion { get; set; }
        
    }
}
