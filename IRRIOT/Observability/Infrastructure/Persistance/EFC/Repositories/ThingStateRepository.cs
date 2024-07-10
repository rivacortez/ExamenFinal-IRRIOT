
using API.Observability.Domain.Model.Aggregates;
using API.Observability.Domain.Repository;
using API.Shared.Infrastructure.Persistance.EFC.Configuration;
using API.Shared.Infrastructure.Persistance.EFC.Repositories;
using Microsoft.EntityFrameworkCore;

namespace API.Observability.Infrastructure.Persistance.EFC.Repositories;


public class ThingStateRepository (AppDbContext context): BaseRepository<ThingState>(context), IThingStateRepository
{
    public async Task<ThingState?> GetBySerialNumberAndCollectedAt(Guid serialNumber, DateTime collectedAt)
    {
        return await context.ThingStates
            .SingleOrDefaultAsync(c => c.ThingSerialNumber.Value == serialNumber && c.CollectedAt.Date == collectedAt.Date);
    }
}