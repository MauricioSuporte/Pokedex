using Business.Core;

namespace Infra.Core;
public class RepositoryBase : IRepositoryBase
{
    protected readonly EFDbContext _efContext;

    public RepositoryBase(EFDbContext efContext)
    {
        _efContext = efContext;
    }

    public Task CommitAsync()
    {
        return _efContext.SaveChangesAsync();
    }

    public void Dispose()
    {
        _efContext?.Dispose();
    }
}
