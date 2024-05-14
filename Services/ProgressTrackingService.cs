using Domain.Models;
using Microsoft.Extensions.Logging;
using Persistance;
using Services.Abstraction;

namespace Services
{
    public class ProgressTrackingService : IProgressTrackingService
    {
        private readonly AppDbContext _appDbContext;
        private readonly ILogger<ProgressTrackingService> _logger;

        public ProgressTrackingService(AppDbContext appDbContext, ILogger<ProgressTrackingService> logger)
        {
            _appDbContext = appDbContext;
            _logger = logger;
        }
        public async Task<List<DailyActivityTrackModel>> GetCurrentTrackDetails(int UserId)
        {
            List<DailyActivityTrackModel> lstDailyActivityTrackModel = new List<DailyActivityTrackModel>();
            try
            {
                var response = _appDbContext.userdailytrack.Where(x => x.userid == UserId)
                                                            .OrderByDescending(a => a.id)
                                                            .Select(p => p).FirstOrDefault();
                DailyActivityTrackModel dailyActivityTrackModel = new DailyActivityTrackModel();

                if (response != null) 
                { 
                    dailyActivityTrackModel.Weight = response.weight;
                    dailyActivityTrackModel.BodyFat = response.bodyfat;
                    dailyActivityTrackModel.MuscleMass = response.musclemass;
                    dailyActivityTrackModel.InfoDate = response.infodate;
                    //dailyActivityTrackModel.WorkoutFrequency = response.;
                    dailyActivityTrackModel.Id=response.id;
                    dailyActivityTrackModel.UserId = response.userid;
                    dailyActivityTrackModel.Status = response.status;
                    lstDailyActivityTrackModel.Add(dailyActivityTrackModel);
                }

            }
            catch(Exception ex) { }

            return await Task.FromResult(lstDailyActivityTrackModel);
        }

        public async Task<List<WeightTrackerModel>> GetWeightTrackDetails(int UserId)
        {
            List<WeightTrackerModel> lstWeightTrackerModel = new List<WeightTrackerModel>();
            try
            {
                var dbResponse = _appDbContext.userdailytrack.Where(x => x.userid ==  UserId)
                                                            .OrderByDescending(a => a.id).Take(10)
                                                            .Select(p => p).ToList(); 
                if (dbResponse != null)
                {
                    foreach (var response in dbResponse) 
                    {
                        WeightTrackerModel weightTrackerModel = new WeightTrackerModel();
                        weightTrackerModel.Weight = response.weight;
                        weightTrackerModel.UserId = response.userid;
                        weightTrackerModel.InfoDate=response.infodate;
                        lstWeightTrackerModel.Add(weightTrackerModel);
                    }
                }

            }
            catch (Exception ex) { }

            return await Task.FromResult(lstWeightTrackerModel);
        }

        public async Task<List<BodyFatTrackerModel>> GetFatTrackDetails(int UserId)
        {
            List<BodyFatTrackerModel> lstBodyFatTrackerModel = new List<BodyFatTrackerModel>();
            try
            {
                var dbResponse = _appDbContext.userdailytrack.Where(x => x.userid == Convert.ToInt32(UserId))
                                                            .OrderByDescending(a => a.id).Take(10)
                                                            .Select(p => p).ToList();


                if (dbResponse != null)
                {
                    foreach (var response in dbResponse)
                    {
                        BodyFatTrackerModel bodyFatTrackerModel = new BodyFatTrackerModel();
                        bodyFatTrackerModel.BodyFat = response.bodyfat;
                        bodyFatTrackerModel.UserId = response.userid;
                        bodyFatTrackerModel.InfoDate = response.infodate;
                        lstBodyFatTrackerModel.Add(bodyFatTrackerModel);
                    }
                }

            }
            catch (Exception ex) { }

            return await Task.FromResult(lstBodyFatTrackerModel);
        }

        public async Task<List<MuscleMassTrackerModel>> GetMuscleMassTrackDetails(int UserId)
        {
            List<MuscleMassTrackerModel> lstMuscleMassTrackerModel = new List<MuscleMassTrackerModel>();
            try
            {
                var dbResponse = _appDbContext.userdailytrack.Where(x => x.userid == Convert.ToInt32(UserId))
                                                            .OrderByDescending(a => a.id).Take(10)
                                                            .Select(p => p).ToList();


                if (dbResponse != null)
                {
                    foreach (var response in dbResponse)
                    {
                        MuscleMassTrackerModel muscleMassTrackerModel = new MuscleMassTrackerModel();
                        muscleMassTrackerModel.MuscleMass = response.musclemass;
                        muscleMassTrackerModel.UserId = response.userid;
                        muscleMassTrackerModel.InfoDate = response.infodate;
                        lstMuscleMassTrackerModel.Add(muscleMassTrackerModel);
                    }
                }

            }
            catch (Exception ex) { }

            return await Task.FromResult(lstMuscleMassTrackerModel);
        }
    }
}
