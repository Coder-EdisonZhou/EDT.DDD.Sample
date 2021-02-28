namespace EDT.DDD.Sample.API.Domain.Core.SeedWork
{
    public interface IRepository<T>
        where T : class
    {
        IUnitOfWork UnitOfWork { get; }
    }
}
