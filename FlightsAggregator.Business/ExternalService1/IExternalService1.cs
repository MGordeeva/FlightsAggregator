using FlightsAggregator.Business.Entities;
using FlightsAggregator.Business.ExternalService1.Entities;

namespace FlightsAggregator.Business.ExternalService1
{
    public interface IExternalService1
    {
        Task<IEnumerable<ExternalService1FlightEntity>> GetFlightsAsync(SearchFlightRequestFilters filters, string sortingField, bool acsending);
        Task<ExternalService1BookingResponse> BookFlightAsync(ExternalService1BookingRequest request);
    }
}
