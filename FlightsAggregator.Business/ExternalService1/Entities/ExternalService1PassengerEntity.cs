namespace FlightsAggregator.Business.ExternalService1.Entities
{
    public class ExternalService1PassengerEntity
    {
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string PassportNumber { get; set; }
        public required string Citizenship { get; set; }
    }
}