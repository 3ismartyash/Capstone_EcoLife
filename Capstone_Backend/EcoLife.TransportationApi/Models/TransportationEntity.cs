using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EcoLife.TransportationApi.Models
{
    public class TransportationEntity
    {
        [Key]
        public int TransportationId { get; set; }

        [Required]
        public int UserId { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "Petrol usage must be a non-negative value.")]
        public double PetrolUsage { get; set; } 

        [Range(0, double.MaxValue, ErrorMessage = "Diesel usage must be a non-negative value.")]
        public double DieselUsage { get; set; } 

        [Range(0, double.MaxValue, ErrorMessage = "CNG usage must be a non-negative value.")]
        public double CNGUsage { get; set; } 

        [Required]
       
        public DateOnly RecordedDate { get; set; }

        public double TransportEmission { get; set; }

    }
}
