using FlightsAggregator.Business;
using FlightsAggregator.Business.Entities;
using Microsoft.AspNetCore.Mvc;

namespace FlightsAggregator.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookingController : ControllerBase
    {
        private readonly IFlightAggregatorService _flightAggregatorService;

        public BookingController(IFlightAggregatorService flightAggregatorService)
        {
            _flightAggregatorService = flightAggregatorService;
        }

        [HttpPost]
        public async Task<BookingResponse> BookFlight(BookingRequest request)
        {
            return await _flightAggregatorService.BookFlightAsync(request);
        }
    }
}