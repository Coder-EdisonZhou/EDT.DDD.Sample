using EDT.DDD.Sample.API.Domain.RuleAggregate.Entities;
using EDT.DDD.Sample.API.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EDT.DDD.Sample.API.Infrastructure.Mappings
{
    public class ApprovalRuleConfiguration :
        IEntityTypeConfiguration<ApprovalRule>
    {
        public void Configure(EntityTypeBuilder<ApprovalRule> builder)
        {
            builder.ToTable(@"t_approvalrule", SampleDbContext.DEFAULT_SCHEMA);

            // todo
        }
    }
}
