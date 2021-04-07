using EDT.DDD.Sample.API.Domain.PersonAggregate.Entities;
using EDT.DDD.Sample.API.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EDT.DDD.Sample.API.Infrastructure.Mappings
{
    public class PersonConfiguration :
        IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.ToTable(@"t_person", SampleDbContext.DEFAULT_SCHEMA);

            // todo
        }
    }
}
