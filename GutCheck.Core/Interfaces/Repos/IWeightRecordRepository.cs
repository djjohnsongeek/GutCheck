using GutCheck.Core.Entities;

namespace GutCheck.Core.Interfaces
{
    public interface IWeightRecordRepository
    {
        Task<bool> InsertRecord(WeightRecord record);
    }
}
