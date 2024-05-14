using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Abstraction;
using System.Collections.Generic;
using System.Text.Json;
using Domain.Entities;

namespace ProgressTracking.Controllers
{
    [Route("api/[progress]")]
    [ApiController]
    public class ProgressTrackingController : ControllerBase
    {
        public readonly IProgressTrackingService _progressTrackingService ;
        public readonly ILogger<ProgressTrackingController> _logger;

        public ProgressTrackingController(IProgressTrackingService progressTrackingService, ILogger<ProgressTrackingController> logger)
        {
            _progressTrackingService = progressTrackingService;
            _logger = logger;
        }

        [HttpGet]
        [Route("/getcurrentprogress/{iUserID}")]
        public async Task<string?> GetCurrentTrackDetails(int iUserID)
        {
            string sResponse = string.Empty;
            ApiResultFormat response = new ApiResultFormat();
            try 
            {
                var dResponse = await _progressTrackingService.GetCurrentTrackDetails(iUserID);
                if (dResponse != null)
                {
                    response.data = dResponse.Cast<dynamic>().ToList();
                    response.totalData = dResponse.Count;
                    sResponse = JsonSerializer.Serialize(response).ToString();
                    return await Task.FromResult(sResponse);
                }

            }
            catch (Exception ex) { }
            return await Task.FromResult(sResponse);
        }

        [HttpGet]
        [Route("/getweightprogress/{strUserID}")]
        public async Task<string?> GetWeightTrackDetails(int strUserID)
        {
            string sResponse = string.Empty;
            ApiResultFormat response = new ApiResultFormat();
            try
            {
                var dResponse = await _progressTrackingService.GetWeightTrackDetails(strUserID);
                if (dResponse != null)
                {
                    response.data = dResponse.Cast<dynamic>().OrderBy(x => x.InfoDate).ToList();
                    response.totalData = dResponse.Count;
                    sResponse = JsonSerializer.Serialize(response).ToString();
                    return await Task.FromResult(sResponse);
                }

            }
            catch (Exception ex) { }
            return await Task.FromResult(sResponse);
        }

        [HttpGet]
        [Route("/getfatprogress/{strUserID}")]
        public async Task<string?> GetFatTrackDetails(int strUserID)
        {
            string sResponse = string.Empty;
            ApiResultFormat response = new ApiResultFormat();
            try
            {
                var dResponse = await _progressTrackingService.GetFatTrackDetails(strUserID);
                if (dResponse != null)
                {
                    response.data = dResponse.Cast<dynamic>().OrderBy(x => x.InfoDate).ToList();
                    response.totalData = dResponse.Count;
                    sResponse = JsonSerializer.Serialize(response).ToString();
                    return await Task.FromResult(sResponse);
                }

            }
            catch (Exception ex) { }
            return await Task.FromResult(sResponse);
        }

        [HttpGet]
        [Route("/getmusclemassprogress/{strUserID}")]
        public async Task<string?> GetMuscleMassTrackDetails(int strUserID)
        {
            string sResponse = string.Empty;
            ApiResultFormat response = new ApiResultFormat();
            try
            {
                var dResponse = await _progressTrackingService.GetMuscleMassTrackDetails(strUserID);
                if (dResponse != null)
                {
                    response.data = dResponse.Cast<dynamic>().OrderBy(x => x.InfoDate).ToList();
                    response.totalData = dResponse.Count;
                    sResponse = JsonSerializer.Serialize(response).ToString();
                    return await Task.FromResult(sResponse);
                }

            }
            catch (Exception ex) { }
            return await Task.FromResult(sResponse);
        }
    }
}
