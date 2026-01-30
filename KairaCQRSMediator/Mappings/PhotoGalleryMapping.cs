using AutoMapper;
using KairaCQRSMediator.DataAccess.Entities;
using KairaCQRSMediator.Features.Mediator.Commands.PhotoGalleryCommands;
using KairaCQRSMediator.Features.Mediator.Results.PhotoGalleryResults;

namespace KairaCQRSMediator.Mappings
{
    public class PhotoGalleryMapping : Profile
    {
        public PhotoGalleryMapping()
        {
            CreateMap<PhotoGallery, GetPhotoGalleryQueryResult>().ReverseMap();
            CreateMap<PhotoGallery, GetPhotoGalleryByIdQueryResult>().ReverseMap();
            CreateMap<PhotoGallery, CreatePhotoGalleryCommand>().ReverseMap();
            CreateMap<PhotoGallery, UpdatePhotoGalleryCommand>().ReverseMap();
        }
    }
}