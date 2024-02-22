namespace FlightsAggregator.Business.Entities
{
    public class BookingRequest
    {
        public required IEnumerable<Passenger> PassengersInfo { get; set; }
        public required int ExternalServiceId { get; set; }
        public required string FlightId { get; set; }
    }
}
