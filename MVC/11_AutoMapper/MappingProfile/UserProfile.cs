using _11_AutoMapper.Dto;
using _11_AutoMapper.Models;
using AutoMapper;

namespace _11_AutoMapper.MappingProfile
{
    public class UserProfile : Profile
    {
        //User => UserDto dönüşümü için burada yapı oluşturuluyor
        //FirstBame ve LastName birleştirilip FullName olarak atanıyor

        public UserProfile()
        {
            //User 'dan UserDto'ya dönüşüm kuralı tanımlanıyor Userdaki
            //firstName ve LastName birleştirilip UserDto'daki FullName'e atanıyor
            CreateMap<User, UserDto>()
                .ForMember(abc => abc.FullName,
                           opt => opt.MapFrom(src => $"{src.FirstName} {src.LastName}"));
            //UserDto'dan User'a dönüşüm kuralı tanımlanıyor
            //iki taraflı dönüşüm için
            CreateMap<UserDto, User>();
        }
    }
}
