using AutoMapper;
using MercuryAp.Models.Dtos;
using MercuryApi.Models.Dtos;

namespace MercuryApi.Models.MercuryMapper
{
    public class MercuryMappings : Profile
    {
        public MercuryMappings()
        {
            CreateMap<BitstampExchange, BitstampExchangeDto>().ReverseMap();
            CreateMap<ExchangeRate, ExchangeRateDto>().ReverseMap();
            CreateMap<JsonResponse, JsonResponseDto>().ReverseMap();
            CreateMap<ValrExchange, ValrExchangeDto>().ReverseMap();
        }
    }
}
