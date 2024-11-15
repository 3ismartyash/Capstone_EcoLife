using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EcoLife.HouseHoldApi.Models
{
    public class HouseHoldEntity
    {
        [Key]
        public int HouseHoldId { get; set; }

        [Required]
        public int UserId { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "Electricity usage must be a non-negative value.")]
        public double ElectricityUsage { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "LPG usage must be a non-negative value.")]
        public double LPGUsage { get; set; } 

        [Range(0, double.MaxValue, ErrorMessage = "Coal usage must be a non-negative value.")]
        public double CoalUsage { get; set; }

        [Required]
        public DateTime RecordedDate { get; set; }
        public double HouseHoldEmission { get; set; }
        
    }
}
