using AutoMapper;
using b3digitas.Application.DTOs;
using b3digitas.Domain.Entities;




namespace b3digitas.Application.Mappings
{
    public class DomainMapDtoProfile : Profile
    {
        public DomainMapDtoProfile()
        {
           CreateMap<Order, OrderDTO>().ReverseMap();
           CreateMap<Quote, QuoteDTO>().ReverseMap();
           CreateMap<QuoteOrdes, QuoteOrdesDTO>().ReverseMap();
        }
    }
}
