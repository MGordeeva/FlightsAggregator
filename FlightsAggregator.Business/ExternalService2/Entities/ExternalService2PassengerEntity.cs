namespace FlightsAggregator.Business.ExternalService2.Entities
{
    public class ExternalService2PassengerEntity
    {
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string PassportSeries { get; set; }
        public required string PassportNumber { get; set; }
        public required string Citizenship { get; set; }
    }
}