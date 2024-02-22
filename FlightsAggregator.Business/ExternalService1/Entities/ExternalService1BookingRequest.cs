namespace FlightsAggregator.Business.ExternalService1.Entities
{
    public class ExternalService1BookingRequest
    {
        public required IEnumerable<ExternalService1PassengerEntity> Passengers { get; set; }
        public required string FlightId { get; set; }
    }
}