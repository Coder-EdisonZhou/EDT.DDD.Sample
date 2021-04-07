using EDT.DDD.Sample.API.Domain.LeaveAggregate.Entities;
using EDT.DDD.Sample.API.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EDT.DDD.Sample.API.Infrastructure.Mappings
{
    public class LeaveConfiguration :
        IEntityTypeConfiguration<Leave>
    {
        public void Configure(EntityTypeBuilder<Leave> builder)
        {
            builder.ToTable(@"t_leave", SampleDbContext.DEFAULT_SCHEMA);

            // todo
        }
    }
}
