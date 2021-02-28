using EDT.DDD.Sample.API.Infrastructure.Context;
using EDT.DDD.Sample.API.Infrastructure.POs.Person;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EDT.DDD.Sample.API.Infrastructure.EntityConfigurations.Person
{
    public class PersonConfiguration :
        IEntityTypeConfiguration<PersonPO>
    {
        public void Configure(EntityTypeBuilder<PersonPO> builder)
        {
            builder.ToTable(@"t_person", SampleDbContext.DEFAULT_SCHEMA);

            // todo
        }
    }
}
