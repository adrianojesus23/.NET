using API.Entities;
using AutoMapper;

namespace API.Services
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<UserDto, User>().ForMember(x => x.Address, op => op.MapFrom(x => x.Local));
            CreateMap<User, UserDto>().ForMember(x => x.Local, op => op.MapFrom(x => x.Address));
        }
    }
}
