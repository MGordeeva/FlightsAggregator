namespace FlightsAggregator.Business.Entities
{
    public class Flight
    {
        public required string DepartureCity { get; set; }
        public required string DestinationCity { get; set; }
        public DateTime DepartureTime { get; set; }
        public DateTime ArrivalTime { get; set; }
        public double Price { get; set; }
        public int LayoversCount { get; set; }
        public required string AirLine { get; set; }
        public bool? LuggageIncluded { get; set; }
    }
}