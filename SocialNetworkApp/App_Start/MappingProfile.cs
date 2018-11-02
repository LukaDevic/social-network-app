using AutoMapper;
using SocialNetworkApp.Core.Dtos;
using SocialNetworkApp.Core.Models;

namespace SocialNetworkApp.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ApplicationUser, UserDto>();
            CreateMap<Genre, GenreDto>();
            CreateMap<Concert, ConcertDto>();
            CreateMap<Notification, NotificationDto>();
        }
    }
}