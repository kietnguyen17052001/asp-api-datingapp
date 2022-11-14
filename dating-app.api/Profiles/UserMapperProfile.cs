using AutoMapper;
using dating_app.api.Data.Entity;
using dating_app.api.DTOs;
using dating_app.api.Extensions;
namespace dating_app.api.Profiles
{
    public class UserMapperProfile : Profile
    {
        public UserMapperProfile()
        {
            CreateMap<UserEntity, MemberDto>()
            .ForMember(dest => dest.age,
            options => options.MapFrom(src => src.dateOfBirth.HasValue
            ? src.dateOfBirth.Value.calculateAge() : 0));

            CreateMap<RegisterUserDto, UserEntity>();
        }
    }
}