using TrendApi.Application.Interface.Repositories;
using TrendApi.Persistence.Context;
using YoutubeApi.Application.Interfaces.Repositories;
using YoutubeApi.Persistence.Repositories;

namespace TrendApi.Persistence.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _dbContext;

        public UnitOfWork(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        //Tek satırda return işlemleri yapılabiliiyor.
        public async ValueTask DisposeAsync() => await _dbContext.DisposeAsync();


        public int Save() => _dbContext.SaveChanges();

        public async Task<int> SaveAsync() => await _dbContext.SaveChangesAsync();

        IReadRepository<T> IUnitOfWork.GetReadRepository<T>() => new ReadRepository<T>(_dbContext);

        IWriteRepository<T> IUnitOfWork.GetWriteRepository<T>() => new WriteRepository<T>(_dbContext);
    }
}
