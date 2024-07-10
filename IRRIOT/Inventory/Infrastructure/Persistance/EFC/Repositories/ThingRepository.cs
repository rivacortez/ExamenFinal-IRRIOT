

using API.Inventory.Domain.Model.Aggregates;
using API.Inventory.Domain.Repository;
using API.Shared.Infrastructure.Persistance.EFC.Configuration;
using API.Shared.Infrastructure.Persistance.EFC.Repositories;
using Microsoft.EntityFrameworkCore;

namespace API.Inventory.Infrastructure.Persistance.EFC.Repositories;


public class ThingRepository (AppDbContext context): BaseRepository<Thing>(context), IThingRepository
{
    public async Task<bool> ExistBySerialNumberAsync(Guid serialNumber)
    {
        return await context.Set<Thing>().AnyAsync(c => c.SerialNumberValObj.Value == serialNumber);
    }
}