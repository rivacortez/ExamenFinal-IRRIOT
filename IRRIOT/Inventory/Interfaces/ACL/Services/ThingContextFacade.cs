
using API.Inventory.Domain.Repository;

namespace API.Inventory.Interfaces.ACL.Services.Services;


public class ThingContextFacade (IThingRepository thingRepository) : IThingContextFacade
{

    public async Task<bool> ExistsThingAsync(Guid serialNumber)
    {
        return await thingRepository.ExistBySerialNumberAsync(serialNumber);
    }
}
