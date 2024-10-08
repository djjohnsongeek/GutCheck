using GutCheck.Core.Entities;
using GutCheck.Core.Interfaces;
using GutCheck.Core.Types;

namespace GutCheck.Infrastructure.Services
{
    public class TrackingService : ITrackingService
    {
        private IWeightRecordRepository _weightRepo;
        private IUserRepository _userRepo;

        public TrackingService(IWeightRecordRepository weightRecordRepository, IUserRepository userRepo)
        {
            _weightRepo = weightRecordRepository;
            _userRepo = userRepo;
        }

        public async Task<bool> TrackWeight(RecordWeightData data)
        {
            User? currentUser = await _userRepo.GetUserById(data.UserId);
            if (currentUser != null)
            {
                WeightRecord newRecord = new WeightRecord
                {
                    Date = data.Date,
                    Weight = data.Weight,
                    UserId = data.UserId,
                };

                return await _weightRepo.InsertRecord(newRecord);
            }
            else
            {
                return false;
            }
        }
    }
}
