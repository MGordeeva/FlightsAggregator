namespace FlightsAggregator.Business.ExternalService1.Entities
{
    public class ExternalService1FlightEntity
    {
        public required string DepartureCity { get; set; }
        public required string DestinationCity { get; set; }
        public DateTime DepartureTime { get; set; }
        public DateTime ArrivalTime { get; set; }
        public double Price { get; set; }
        public int LayoversCount { get; set; }
    }
}