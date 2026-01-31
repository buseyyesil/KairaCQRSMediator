using AutoMapper;
using KairaCQRSMediator.DataAccess.Entities;

using KairaCQRSMediator.Features.Mediator.Commands.CollectionCommands;
using KairaCQRSMediator.Features.Mediator.Results.CollectionResults;

namespace KairaCQRSMediator.Mapping
{
    public class CollectionProfile : Profile
    {
        public CollectionProfile()
        {
            CreateMap<Collection, GetCollectionQueryResult>().ReverseMap();
            CreateMap<Collection, GetCollectionByIdQueryResult>().ReverseMap();
            CreateMap<CreateCollectionCommand, Collection>();
            CreateMap<UpdateCollectionCommand, Collection>();
        }
    }
}