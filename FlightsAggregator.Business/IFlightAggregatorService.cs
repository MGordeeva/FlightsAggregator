using FlightsAggregator.Business.Entities;

namespace FlightsAggregator.Business
{
    public interface IFlightAggregatorService
    {
        Task<IEnumerable<Flight>> GetFlightsAsync(SearchFlightRequestFilters filters, string sortingField, bool acsending);
        Task<BookingResponse> BookFlightAsync(BookingRequest bookingRequest);
    }
}
