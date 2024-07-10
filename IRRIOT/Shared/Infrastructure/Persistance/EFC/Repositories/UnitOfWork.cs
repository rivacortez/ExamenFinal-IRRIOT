
using API.Shared.Domain.Repositories;
using API.Shared.Infrastructure.Persistance.EFC.Configuration;

namespace API.Shared.Infrastructure.Persistance.EFC.Repositories;

public class UnitOfWork(AppDbContext context) : IUnitOfWork
{

    public async Task CompleteAsync() => await context.SaveChangesAsync();
    
}