namespace EcoLife.HouseHoldApi.Models.Dto
{
    public class HouseHoldDto
    {
        public int UserId { get; set; }
        public double ElectricityUsage { get; set; }
        public double LPGUsage { get; set; }
        public double CoalUsage { get; set; }
        public DateOnly RecordedDate { get; set; }

    }
}
