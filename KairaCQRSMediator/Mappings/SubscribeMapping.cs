using AutoMapper;
using KairaCQRSMediator.DataAccess.Entities;
using KairaCQRSMediator.Features.Mediator.Results.SubscribeResults;

namespace KairaCQRSMediator.Mappings
{
    public class SubscribeMapping : Profile
    {
        public SubscribeMapping()
        {
            CreateMap<Subscribe, GetSubscribeQueryResult>().ReverseMap();
        }
    }
}