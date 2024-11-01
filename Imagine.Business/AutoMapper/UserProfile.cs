using AutoMapper;
using Imagine.DataAccess.Entities.Dtos;
using Imagine.DataAccess.Entities;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<UserDtoForLogin, User>();
        CreateMap<UserDtoForRegister, User>();
        CreateMap<UserDtoForUpdate, User>().ForMember(dest => dest.Password, opt => opt.Ignore()).ReverseMap();
        CreateMap<UserDtoForInsertion, User>();

    }
}
