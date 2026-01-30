using AutoMapper;
using KairaCQRSMediator.DataAccess.Entities;
using KairaCQRSMediator.Features.Mediator.Results.SocialMediaResults;

namespace KairaCQRSMediator.Mappings
{
    public class SocialMediaMapping : Profile
    {
        public SocialMediaMapping()
        {
            CreateMap<SocialMedia, GetSocialMediaQueryResult>().ReverseMap();
        }
    }
}
