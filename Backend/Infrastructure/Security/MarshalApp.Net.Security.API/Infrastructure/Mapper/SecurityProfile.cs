using AutoMapper;
using MarshalApp.Net.Security.API.Infrastructure.Data.Entities;
using MarshalApp.Net.Security.API.Infrastructure.Dtos;

namespace MarshalApp.Net.Security.API.Infrastructure.Mapper
{
    public class SecurityProfile : Profile
    {
        public SecurityProfile()
        {
            CreateMap<User, UserDto>();
        }
    }
}
