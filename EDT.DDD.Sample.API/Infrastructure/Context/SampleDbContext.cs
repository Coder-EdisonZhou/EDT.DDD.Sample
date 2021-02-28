using EDT.DDD.Sample.API.Domain.Core.SeedWork;
using EDT.DDD.Sample.API.Infrastructure.POs.Person;
using EDT.DDD.Sample.API.Infrastructure.POs.Rule;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace EDT.DDD.Sample.API.Infrastructure.Context
{
    public class SampleDbContext : DbContext, IUnitOfWork
    {
        public const string DEFAULT_SCHEMA = "ddd_sample_db";

        public SampleDbContext(DbContextOptions<SampleDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ApprovalRulePO> ApprovalRules
        {
            get;
            set;
        }

        public virtual DbSet<PersonPO> Person
        {
            get;
            set;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // modelBuilder.ApplyConfiguration(new ActionConfiguration());
        }

        public async Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default)
        {
            var result = await SaveChangesAsync(cancellationToken);

            return true;
        }
    }
}
