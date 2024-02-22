using AutoMapper;
using FlightsAggregator.Business.Entities;
using FlightsAggregator.Business.ExternalService1.Entities;
using Microsoft.Extensions.Configuration;

namespace FlightsAggregator.Business.ExternalService1
{
    public class ExternalService1Mock : IExternalService1
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;
        private string serviceUrl;

        public ExternalService1Mock(IHttpClientFactory httpClientFactory, IConfiguration configuration, IMapper mapper)
        {
            _httpClientFactory = httpClientFactory;
            _configuration = configuration;
            _mapper = mapper;
            serviceUrl = configuration.GetSection("Service1Url")?.Value;
        }

        public Task<ExternalService1BookingResponse> BookFlightAsync(ExternalService1BookingRequest request)
        {
            var task = Task.Run(() =>
            {
                Thread.Sleep(3000);
                return GenerateTestBookingResponse();
            });

            return task;
        }

        public Task<IEnumerable<ExternalService1FlightEntity>> GetFlightsAsync(SearchFlightRequestFilters filters, string sortingField, bool acsending)
        {
            var task = Task.Run(() =>
            {
                Thread.Sleep(3000);
                return GenerateTestFlights();
            });

            return task;
        }

        private static ExternalService1BookingResponse GenerateTestBookingResponse()
        {
            return new ExternalService1BookingResponse
            {
                PaymentLink = "some url"
            };
        }

        private IEnumerable<ExternalService1FlightEntity> GenerateTestFlights()
        {
            return new List<ExternalService1FlightEntity>()
            {
                new ExternalService1FlightEntity
                {
                    ArrivalTime = DateTime.Now.AddDays(1),
                    DepartureTime = DateTime.Now,
                    DepartureCity = "DepartureCity",
                    DestinationCity = "DestinationCity",
                    LayoversCount = 0,
                    Price = 100,
                },
                new ExternalService1FlightEntity
                {
                    ArrivalTime = DateTime.Now.AddDays(1),
                    DepartureTime = DateTime.Now,
                    DepartureCity = "DepartureCity2",
                    DestinationCity = "DestinationCity2",
                    LayoversCount = 0,
                    Price = 80,
                },
                new ExternalService1FlightEntity
                {
                    ArrivalTime = DateTime.Now.AddDays(1),
                    DepartureTime = DateTime.Now,
                    DepartureCity = "DepartureCity3",
                    DestinationCity = "DestinationCity3",
                    LayoversCount = 0,
                    Price = 1000,
                },
            };
        }
    }
}
