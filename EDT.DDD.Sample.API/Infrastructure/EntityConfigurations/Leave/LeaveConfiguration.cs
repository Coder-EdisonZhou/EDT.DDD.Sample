using EDT.DDD.Sample.API.Infrastructure.Context;
using EDT.DDD.Sample.API.Infrastructure.POs.Leave;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EDT.DDD.Sample.API.Infrastructure.EntityConfigurations.Leave
{
    public class LeaveConfiguration :
        IEntityTypeConfiguration<LeavePO>
    {
        public void Configure(EntityTypeBuilder<LeavePO> builder)
        {
            builder.ToTable(@"t_leave", SampleDbContext.DEFAULT_SCHEMA);

            // todo
        }
    }
}
