using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;

namespace Services.Abstraction
{
    public interface IProgressTrackingService
    {
        Task<List<DailyActivityTrackModel>> GetCurrentTrackDetails(int UserId);
        Task<List<WeightTrackerModel>> GetWeightTrackDetails(int UserId);
        Task<List<MuscleMassTrackerModel>> GetMuscleMassTrackDetails(int UserId);
        Task<List<BodyFatTrackerModel>> GetFatTrackDetails(int UserId);
    }
}
