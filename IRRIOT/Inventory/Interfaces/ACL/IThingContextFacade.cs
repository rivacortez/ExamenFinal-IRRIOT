namespace API.Inventory.Interfaces.ACL.Services;


public interface IThingContextFacade
{
    Task<bool> ExistsThingAsync(Guid thingSerialNumber);
}