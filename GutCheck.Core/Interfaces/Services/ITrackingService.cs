using GutCheck.Core.Types;

namespace GutCheck.Core.Interfaces
{
    public interface ITrackingService
    {
        Task<bool> TrackWeight(RecordWeightData data);
    }
}
