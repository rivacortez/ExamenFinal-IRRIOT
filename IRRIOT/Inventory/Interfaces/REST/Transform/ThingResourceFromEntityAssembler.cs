

using API.Inventory.Domain.Model.Aggregates;

namespace API.Inventory.Interfaces.REST.Transform;

public class ThingResourceFromEntityAssembler
{
    public static ThingResource ToResourceFromEntity(Thing entity)
    {
        return new ThingResource(entity.Id, entity.SerialNumber, entity.Model, entity.OperationMode, entity.MaximumTemperatureThreshold, entity.MinimumTemperatureThreshold);
    }
}