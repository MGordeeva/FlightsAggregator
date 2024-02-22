namespace FlightsAggregator.Business.ExternalService2.Entities
{
    public class ExternalService2BookingRequest
    {
        public required IEnumerable<ExternalService2PassengerEntity> Passengers { get; set; }
        public required string FlightId { get; set; }
    }
}