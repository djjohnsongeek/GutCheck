namespace GutCheck.Core.Entities
{
    public class FoodRecord
    {
        public int FoodRecordId { get; set; }
        public int UserId { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public UInt16 HealthScore { get; set; }
        public UInt16 PortionSize { get; set; }
        
    }
}
