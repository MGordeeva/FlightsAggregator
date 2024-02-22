using AutoMapper;
using FlightsAggregator.Business.Entities;
using FlightsAggregator.Business.ExternalService2.Entities;

namespace FlightsAggregator.Business.ExternalService2
{
    public class ExternalService2MappingProfile : Profile
    {
        public ExternalService2MappingProfile()
        {
            CreateMap<ExternalService2FlightEntity, Flight>()
                .ForMember(x => x.LuggageIncluded, o => o.MapFrom(s => s.IsLuggageIncluded))
                .ForMember(x => x.LayoversCount, o => o.MapFrom(s => s.Layovers));

            CreateMap<Passenger, ExternalService2PassengerEntity>();

            CreateMap<BookingRequest, ExternalService2BookingRequest>();
            CreateMap<ExternalService2BookingResponse, BookingResponse>();
        }
    }
}
