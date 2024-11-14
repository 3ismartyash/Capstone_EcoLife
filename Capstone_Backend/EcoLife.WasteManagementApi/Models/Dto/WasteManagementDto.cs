namespace EcoLife.WasteManagementApi.Models.Dto
{
    public class WasteManagementDto
    {
        public double RecycledWaste { get; set; }
        public double CompostWaste { get; set; }
        public double LandfillWaste { get; set; }
        public DateTime RecordedDate { get; set; }
        
    }
}
