using AutoMapper;
using FlightsAggregator.Business.Entities;
using FlightsAggregator.Business.ExternalService2.Entities;
using Microsoft.Extensions.Configuration;

namespace FlightsAggregator.Business.ExternalService2
{
    public class ExternalService2Mock : IExternalService2
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;
        private string serviceUrl;

        public ExternalService2Mock(IHttpClientFactory httpClientFactory, IConfiguration configuration, IMapper mapper)
        {
            _httpClientFactory = httpClientFactory;
            _configuration = configuration;
            _mapper = mapper;
            serviceUrl = configuration.GetSection("Service2Url")?.Value;
        }

        public Task<ExternalService2BookingResponse> BookFlightAsync(ExternalService2BookingRequest request)
        {
            var task = Task.Run(() =>
            {
                Thread.Sleep(3000);
                return GenerateTestBookingResponse();
            });

            return task;
        }

        public Task<IEnumerable<ExternalService2FlightEntity>> GetFlightsAsync(SearchFlightRequestFilters filters, string sortingField, bool acsending)
        {
            var task = Task.Run(() =>
            {
                Thread.Sleep(3000);
                return GenerateTestFlights();
            });

            return task;
        }

        private static ExternalService2BookingResponse GenerateTestBookingResponse()
        {
            return new ExternalService2BookingResponse
            {
                PaymentLink = "some url"
            };
        }

        private IEnumerable<ExternalService2FlightEntity> GenerateTestFlights()
        {
            return new List<ExternalService2FlightEntity>()
            {
                new ExternalService2FlightEntity
                {
                    Id = "1",
                    ArrivalTime = DateTime.Now.AddDays(1),
                    DepartureTime = DateTime.Now,
                    DepartureCity = "DepartureCity",
                    DestinationCity = "DestinationCity",
                    Layovers = 0,
                    Price = 100,
                    AirLine = "AirLine",
                    DepartureAirport = "DepAirport",
                    DestinationAirport = "DestAirport",
                    IsLuggageIncluded = false
                },
                new ExternalService2FlightEntity
                {
                    Id = "2",
                    ArrivalTime = DateTime.Now.AddDays(1),
                    DepartureTime = DateTime.Now,
                    DepartureCity = "DepartureCity2",
                    DestinationCity = "DestinationCity2",
                    Layovers = 0,
                    Price = 80,
                    AirLine = "AirLine",
                    DepartureAirport = "DepAirport",
                    DestinationAirport = "DestAirport",
                    IsLuggageIncluded = false
                },
                new ExternalService2FlightEntity
                {
                    Id = "3",
                    ArrivalTime = DateTime.Now.AddDays(1),
                    DepartureTime = DateTime.Now,
                    DepartureCity = "DepartureCity3",
                    DestinationCity = "DestinationCity3",
                    Layovers = 0,
                    Price = 1000,
                    AirLine = "AirLine",
                    DepartureAirport = "DepAirport",
                    DestinationAirport = "DestAirport",
                    IsLuggageIncluded = true
                },
            };
        }
    }
}
