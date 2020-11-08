using AutoMapper;
using guard.Api.DTOs;
using guard.Core.Models;

namespace guard.Api.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //Domain to Resource
            CreateMap<User, UserDto>();

            // Resource to Domain
            CreateMap<UserDto, User>();

            CreateMap<UserProfile, UserProfileDto>();

            CreateMap<UserProfileDto, UserProfile>();
        }

    }
}