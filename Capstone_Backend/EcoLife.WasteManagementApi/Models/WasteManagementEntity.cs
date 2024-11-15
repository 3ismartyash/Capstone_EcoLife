using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EcoLife.WasteManagementApi.Models
{
    public class WasteManagementEntity
    {
        [Key]
        public int WasteManagementId { get; set; }

        [Required]
        public int UserId { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "Recycled waste must be a non-negative value.")]
        public double RecycledWaste { get; set; } 

        [Range(0, double.MaxValue, ErrorMessage = "Compost waste must be a non-negative value.")]
        public double CompostWaste { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "Landfill waste must be a non-negative value.")]
        public double LandfillWaste { get; set; } 

        [Required]
       
        public DateTime RecordedDate { get; set; }

        public double WasteEmission { get; set; } 


    }
}
