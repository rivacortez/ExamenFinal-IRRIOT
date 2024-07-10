
using API.Inventory.Domain.Model.Commands;

namespace API.Inventory.Interfaces.REST.Transform;

public class CreateThingCommandFromResourceAssembler
{
    public static CreateThingCommand ToCommandFromResource(CreateThingResource resource)
    {
        return new CreateThingCommand(resource.SerialNumber, resource.Model,resource.MaximumTemperatureThreshold, resource.MinimumTemperatureThreshold);
    }
}