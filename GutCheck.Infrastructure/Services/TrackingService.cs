using GutCheck.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GutCheck.Infrastructure.Services
{
    public class TrackingService
    {
        private IWeightRecordRepository _weightRepo;

        public TrackingService(IWeightRecordRepository weightRecordRepository)
        {
            _weightRepo = weightRecordRepository;
        }

    }
}
