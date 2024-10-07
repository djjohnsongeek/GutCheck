namespace GutCheck.Core.Entities
{
    public class WeightRecord
    {
        public int WeightRecordId { get; set; }
        public int UserId { get; set; }
        public decimal Weight { get; set; }
        public DateTime Date { get; set; }
    }
}
