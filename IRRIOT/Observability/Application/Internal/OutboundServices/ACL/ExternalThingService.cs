
using API.Inventory.Domain.Model.ValueObjects;
using API.Inventory.Interfaces.ACL.Services;

namespace API.Observability.Application.Internal.OutboundServices.ACL;


public class ExternalThingService
{
    private readonly IThingContextFacade _thingContextFacade;

    public ExternalThingService(IThingContextFacade thingContextFacade)
    {
        _thingContextFacade = thingContextFacade;
    }

    public async Task<SerialNumber?> FetchThingBySerialNumber(Guid serialNumber)
    {
        return await _thingContextFacade.ExistsThingAsync(serialNumber)
            ? new SerialNumber(serialNumber)
            : null;
    }
}
