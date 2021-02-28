using AutoMapper;
using EDT.DDD.Sample.API.Domain.PersonAggregate.Entities;
using EDT.DDD.Sample.API.Infrastructure.POs.Person;

namespace EDT.DDD.Sample.API.Domain.PersonAggregate.Services
{
    public class PersonMappingProfile : Profile
    {
        public PersonMappingProfile()
        {
            // todo: Create Map and ReverseMap between DO and PO for Leave Aggregate
            CreateMap<Person, PersonPO>();
            CreateMap<Relationship, RelationshipPO>();
        }
    }
}
