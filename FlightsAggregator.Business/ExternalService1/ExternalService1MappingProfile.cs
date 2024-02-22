using AutoMapper;
using FlightsAggregator.Business.Entities;
using FlightsAggregator.Business.ExternalService1.Entities;

namespace FlightsAggregator.Business.ExternalService1
{
    public class ExternalService1MappingProfile : Profile
    {
        public ExternalService1MappingProfile()
        {
            CreateMap<ExternalService1FlightEntity, Flight>()
                .ForMember(x => x.LuggageIncluded, o => o.Ignore());

            CreateMap<Passenger, ExternalService1PassengerEntity>()
                .ForMember(x => x.PassportNumber,
                o => o.MapFrom(s => s.PassportSeries.Concat(s.PassportNumber)));

            CreateMap<BookingRequest, ExternalService1BookingRequest>();
            CreateMap<ExternalService1BookingResponse, BookingResponse>();
        }
    }
}
