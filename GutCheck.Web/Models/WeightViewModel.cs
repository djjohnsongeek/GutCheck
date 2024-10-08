using GutCheck.Web.Models.Data;
using GutCheck.Core.Types;

namespace GutCheck.Web.Models
{
    public class WeightViewModel : BaseViewModel
    {
        public WeightRecordData Data { get; set; }

        public RecordWeightData ToDTO(int userId)
        {
            return new RecordWeightData
            {
                Date = Data.Date,
                Weight = Data.Weight,
                UserId = userId
            };
        }
    }
}
