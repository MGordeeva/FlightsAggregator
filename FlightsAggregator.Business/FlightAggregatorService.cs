using AutoMapper;
using FlightsAggregator.Business.Entities;
using FlightsAggregator.Business.ExternalService1;
using FlightsAggregator.Business.ExternalService1.Entities;
using FlightsAggregator.Business.ExternalService2.Entities;
using Microsoft.Extensions.Logging;
using System.Reflection;

namespace FlightsAggregator.Business
{
    public class FlightAggregatorService : IFlightAggregatorService
    {
        private readonly ILogger<FlightAggregatorService> _logger;
        private readonly IExternalService1 _externalService1;
        private readonly IExternalService2 _externalService2;
        private readonly IMapper _mapper;

        public FlightAggregatorService(ILogger<FlightAggregatorService> logger,
                                       IExternalService1 externalService1,
                                       IExternalService2 externalService2,
                                       IMapper mapper)
        {
            _logger = logger;
            _externalService1 = externalService1;
            _externalService2 = externalService2;
            _mapper = mapper;
        }

        public async Task<BookingResponse> BookFlightAsync(BookingRequest request)
        {
            if (!request.PassengersInfo.Any())
            {
                throw new ArgumentException($"Passengers list cannot be empty");
            }

            switch (request.ExternalServiceId)
            {
                case 1:
                    var service1Request = _mapper.Map<ExternalService1BookingRequest>(request);
                    var serviec1Response = await _externalService1.BookFlightAsync(service1Request);
                    return _mapper.Map<BookingResponse>(serviec1Response);
                case 2:
                    var service2Request = _mapper.Map<ExternalService2BookingRequest>(request);
                    var serviec2Response = await _externalService2.BookFlightAsync(service2Request);
                    return _mapper.Map<BookingResponse>(serviec2Response);
                default:
                    throw new ArgumentException($"Invalid external service id: {request.ExternalServiceId}");
            }
        }

        public async Task<IEnumerable<Flight>> GetFlightsAsync(SearchFlightRequestFilters filters, string sortingField, bool ascending)
        {
            try
            {
                var resultsFromService1Task = _externalService1.GetFlightsAsync(filters, sortingField, ascending);
                var resultsFromService2Task = _externalService2.GetFlightsAsync(filters, sortingField, ascending);

                await Task.WhenAll(resultsFromService1Task, resultsFromService2Task);

                var resultsFromService1 = await resultsFromService1Task;
                var resultsFromService2 = await resultsFromService2Task;

                var allResults = _mapper.Map<IEnumerable<Flight>>(resultsFromService1)
                         .Concat(_mapper.Map<IEnumerable<Flight>>(resultsFromService2));
                return SortResults(allResults, sortingField, ascending);
            }
            //TODO: catch specific exceptions related to the services responces/connection failures
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }
        }

        private static IEnumerable<Flight> SortResults(IEnumerable<Flight> flights, string sortingField, bool ascending)
        {
            PropertyInfo[] flightProperties = typeof(Flight).GetProperties();

            var sortingFieldProperty = flightProperties.Where(p => String.Equals(p.Name, sortingField, StringComparison.OrdinalIgnoreCase)).FirstOrDefault()
                ?? throw new ArgumentException($"Invalid sorting field name: {sortingField}");

            return ascending
                    ? flights.OrderBy(sortingFieldProperty.GetValue)
                    : flights.OrderByDescending(sortingFieldProperty.GetValue);
        }
    }
}
