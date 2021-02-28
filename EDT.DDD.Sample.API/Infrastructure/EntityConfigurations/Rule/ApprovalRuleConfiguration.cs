using EDT.DDD.Sample.API.Infrastructure.Context;
using EDT.DDD.Sample.API.Infrastructure.POs.Rule;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EDT.DDD.Sample.API.Infrastructure.EntityConfigurations.Rule
{
    public class ApprovalRuleConfiguration :
        IEntityTypeConfiguration<ApprovalRulePO>
    {
        public void Configure(EntityTypeBuilder<ApprovalRulePO> builder)
        {
            builder.ToTable(@"t_approvalrule", SampleDbContext.DEFAULT_SCHEMA);

            // todo
        }
    }
}
