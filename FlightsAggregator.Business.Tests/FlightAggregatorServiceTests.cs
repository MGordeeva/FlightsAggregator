using AutoFixture;
using AutoMapper;
using FlightsAggregator.Business.Entities;
using FlightsAggregator.Business.ExternalService1;
using FlightsAggregator.Business.ExternalService1.Entities;
using FlightsAggregator.Business.ExternalService2.Entities;
using Microsoft.Extensions.Logging;
using Moq;

namespace FlightsAggregator.Business.Tests
{
    public class FlightAggregatorServiceTests
    {
        private readonly FlightAggregatorService _flightAggregatorService;
        private readonly Mock<IExternalService1> _externalService1Mock;
        private readonly Mock<IExternalService2> _externalService2Mock;
        private readonly Mock<IMapper> _mapperMock;
        private readonly Mock<ILogger<FlightAggregatorService>> _loggerMock;
        private readonly IFixture _fixture;

        public FlightAggregatorServiceTests()
        {
            _externalService1Mock = new Mock<IExternalService1>();
            _externalService2Mock = new Mock<IExternalService2>();
            _mapperMock = new Mock<IMapper>();
            _loggerMock = new Mock<ILogger<FlightAggregatorService>>();

            _flightAggregatorService = new FlightAggregatorService(
                _loggerMock.Object,
                _externalService1Mock.Object,
                _externalService2Mock.Object,
                _mapperMock.Object
            );
            _fixture = new Fixture();
        }

        [Fact]
        public async Task BookFlightAsync_WithEmptyPassengerList_ThrowsArgumentException()
        {
            // Arrange
            var request = new BookingRequest { ExternalServiceId = 1, PassengersInfo = new List<Passenger>(), FlightId = "FlightId" };

            // Act & Assert
            await Assert.ThrowsAsync<ArgumentException>(() => _flightAggregatorService.BookFlightAsync(request));
        }

        [Fact]
        public async Task BookFlightAsync_WithValidRequest_CallsCorrectExternalService()
        {
            // Arrange
            var passengersInfo = _fixture.Create<List<Passenger>>();
            var request = new BookingRequest { ExternalServiceId = 1, PassengersInfo = passengersInfo, FlightId = "1" };
            var expectedServiceRequest = It.IsAny<ExternalService1BookingRequest>();
            var expectedServiceResponse = It.IsAny<ExternalService1BookingResponse>();
            _mapperMock.Setup(m => m.Map<ExternalService1BookingRequest>(request)).Returns(expectedServiceRequest);
            _externalService1Mock.Setup(s => s.BookFlightAsync(expectedServiceRequest)).ReturnsAsync(expectedServiceResponse);

            // Act
            var result = await _flightAggregatorService.BookFlightAsync(request);

            // Assert
            _externalService1Mock.Verify(s => s.BookFlightAsync(It.IsAny<ExternalService1BookingRequest>()), Times.Once);
            _externalService2Mock.Verify(s => s.BookFlightAsync(It.IsAny<ExternalService2BookingRequest>()), Times.Never);
        }

        [Fact]
        public async Task GetFlightsAsync_SortByDepartureCityDesc_ReturnsSortedResults()
        {
            // Arrange
            var filters = _fixture.Create<SearchFlightRequestFilters>();
            var sortingField = "DepartureCity";
            var ascending = false;
            var service1Results = _fixture.CreateMany<ExternalService1FlightEntity>(5);
            var service2Results = _fixture.CreateMany<ExternalService2FlightEntity>(2);
            _externalService1Mock.Setup(s => s.GetFlightsAsync(filters, sortingField, ascending)).ReturnsAsync(service1Results);
            _externalService2Mock.Setup(s => s.GetFlightsAsync(filters, sortingField, ascending)).ReturnsAsync(service2Results);
            var service1ResultsMapped = _fixture.CreateMany<Flight>(5);
            var service2ResultsMapped = _fixture.CreateMany<Flight>(2);

            _mapperMock.Setup(m => m.Map<IEnumerable<Flight>>(service1Results)).Returns(service1ResultsMapped);
            _mapperMock.Setup(m => m.Map<IEnumerable<Flight>>(service2Results)).Returns(service2ResultsMapped);

            // Act
            var result = await _flightAggregatorService.GetFlightsAsync(filters, sortingField, ascending);

            // Assert
            var expectedResult = service1ResultsMapped
                .Concat(service2ResultsMapped)
                .OrderByDescending(x => x.DepartureCity)
                .ToList();
            Assert.Equal(expectedResult.Count, result.Count());
            Assert.Equal(expectedResult, result);
        }
    }
}