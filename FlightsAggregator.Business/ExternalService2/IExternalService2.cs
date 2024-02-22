using FlightsAggregator.Business.Entities;
using FlightsAggregator.Business.ExternalService2.Entities;

namespace FlightsAggregator.Business
{
    public interface IExternalService2
    {
        Task<IEnumerable<ExternalService2FlightEntity>> GetFlightsAsync(SearchFlightRequestFilters filters, string sortingField, bool acsending);
        Task<ExternalService2BookingResponse> BookFlightAsync(ExternalService2BookingRequest request);
    }
}
