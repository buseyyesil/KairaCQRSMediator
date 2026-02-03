using AutoMapper;
using KairaCQRSMediator.DataAccess.Entities;
using KairaCQRSMediator.Features.Mediator.Commands.RelatedProductCommands;
using KairaCQRSMediator.Features.Mediator.Results.RelatedProductResults;

namespace KairaCQRSMediator.Mappings
{
    public class RelatedProductMapping : Profile
    {
        public RelatedProductMapping()
        {
            CreateMap<RelatedProduct, GetRelatedProductQueryResult>().ReverseMap();
            CreateMap<RelatedProduct, CreateRelatedProductCommand>().ReverseMap();
            CreateMap<RelatedProduct, GetRelatedProductByIdQueryResult>().ReverseMap();
            CreateMap<RelatedProduct, UpdateRelatedProductCommand>().ReverseMap();
        }
    }
}