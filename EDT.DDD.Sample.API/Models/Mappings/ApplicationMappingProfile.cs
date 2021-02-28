using AutoMapper;
using EDT.DDD.Sample.API.Models.DTOs;

namespace EDT.DDD.Sample.API.Models.Mappings
{
    public class ApplicationMappingProfile : Profile
    {
        public ApplicationMappingProfile()
        {
            // todo: Create Map and ReverseMap between DTO, VO and DO
            CreateMap<PersonDTO, UserDTO>();
        }
    }
}
