using AutoMapper;
using CoffeeShop.Core;
using CoffeeShop.Core.DTOs;

namespace CoffeeShop.Core.AutoMapperProfiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserDTO>();
            CreateMap<UserDTO, User>();
        }
    }
}
