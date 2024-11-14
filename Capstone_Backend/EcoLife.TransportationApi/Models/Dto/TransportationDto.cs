namespace EcoLife.TransportationApi.Models.Dto
{
    public class TransportationDto
    {
        public double PetrolUsage { get; set; }
        public double DieselUsage { get; set; }
        public double CNGUsage { get; set; }
        public DateTime RecordedDate { get; set; }
    }
}
