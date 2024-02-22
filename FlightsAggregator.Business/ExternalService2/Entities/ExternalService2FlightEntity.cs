namespace FlightsAggregator.Business.ExternalService2.Entities
{
    public class ExternalService2FlightEntity
    {
        public required string Id { get; set; }
        public required string DepartureCity { get; set; }
        public required string DepartureAirport { get; set; }
        public required string DestinationCity { get; set; }
        public required string DestinationAirport { get; set; }
        public DateTime DepartureTime { get; set; }
        public DateTime ArrivalTime { get; set; }
        public double Price { get; set; }
        public int Layovers { get; set; }
        public required string AirLine { get; set; }
        public bool? IsLuggageIncluded { get; set; }
    }
}