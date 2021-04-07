using EDT.DDD.Sample.API.Domain.SeedWork;

namespace EDT.DDD.Sample.API.Domain.Core.SeedWork
{
    public interface IRepository<T>
        where T : IAggregateRoot
    {
        IUnitOfWork UnitOfWork { get; }
    }
}
