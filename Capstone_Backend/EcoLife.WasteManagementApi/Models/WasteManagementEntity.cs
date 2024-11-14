using System.ComponentModel.DataAnnotations;

namespace EcoLife.WasteManagementApi.Models
{
    public class WasteManagementEntity
    {
        [Key]
        public int WateManagementId { get; set; }
        public int UserId { get; set; }
        public double RecycledWaste { get; set; } = 0;
        public double CompostWaste { get; set; } = 0;
        public double LandfillWaste { get; set; } = 0;
        public DateTime RecordedDate { get; set; }
        public double WasteEmmision { get; set; } = 0;

    }
}
