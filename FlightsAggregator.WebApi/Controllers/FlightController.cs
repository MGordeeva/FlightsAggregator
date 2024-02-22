using FlightsAggregator.Business;
using FlightsAggregator.Business.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OutputCaching;

namespace FlightsAggregator.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FlightController : ControllerBase
    {
        private readonly IFlightAggregatorService _flightAggregatorService;

        public FlightController(IFlightAggregatorService flightAggregatorService)
        {
            _flightAggregatorService = flightAggregatorService;
        }

        [HttpGet]
        [OutputCache(PolicyName = "CacheForTenSeconds")]
        public async Task<IEnumerable<Flight>> GetAsync([FromQuery] SearchFlightRequestFilters request, string sortField, bool acsending)
        {
            return await _flightAggregatorService.GetFlightsAsync(request, sortField, acsending);
        }
    }
}