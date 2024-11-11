namespace EcoLife.HouseHoldApi.Models.Dto
{
    public class HouseHoldDto
    {
        public double ElectricityUsage { get; set; }
        public double LPGUsage { get; set; }
        public double CoalUsage { get; set; }
        public DateTime RecordedDate { get; set; }
    }
}
