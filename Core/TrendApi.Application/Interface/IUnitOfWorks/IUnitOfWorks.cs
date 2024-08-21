using TrendApi.Application.Interface.Repositories;
using TrendApi.Domain.Common;
using YoutubeApi.Application.Interfaces.Repositories;

namespace TrendApi.Application.Interface.IUnitOfWorks;

public interface IUnitOfWork : IAsyncDisposable
{
    IReadRepository<T> GetReadRepository<T>() where T : class, IEntityBase, new();

    IWriteRepository<T> GetWriteRepository<T>() where T : class, IEntityBase, new();
    Task<int> SaveAsync();
    int Save();
}
