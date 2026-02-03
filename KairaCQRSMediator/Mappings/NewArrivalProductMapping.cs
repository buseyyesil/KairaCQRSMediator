using AutoMapper;
using KairaCQRSMediator.DataAccess.Entities;
using KairaCQRSMediator.Features.Mediator.Command.NewarrivalproductCommands;
using KairaCQRSMediator.Features.Mediator.Commands.NewarrivalproductCommands;
using KairaCQRSMediator.Features.Mediator.Results.NewarrivalproductResults;


namespace KairaCQRSMediator.Mappings
{
    public class NewArrivalProductMapping : Profile
    {
        public NewArrivalProductMapping()
        {
            CreateMap<Newarrivalproduct, GetNewarrivalproductQueryResult>().ReverseMap();
            CreateMap<Newarrivalproduct, CreateNewarrivalproductCommand>().ReverseMap();
            CreateMap<Newarrivalproduct, GetNewarrivalproductByIdQueryResult>().ReverseMap();
            CreateMap<Newarrivalproduct, UpdateNewarrivalproductCommand>().ReverseMap();
        }
    }
}