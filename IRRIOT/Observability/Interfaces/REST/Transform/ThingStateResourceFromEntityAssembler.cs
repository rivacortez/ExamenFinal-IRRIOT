
using API.Observability.Domain.Model.Aggregates;
using API.Observability.Interfaces.REST.Resources;

namespace API.Observability.Interfaces.REST.Transform;

public class ThingStateResourceFromEntityAssembler
{
    public static ThingStateResource ToResourceFromEntity(ThingState thingState)
    {
        return new ThingStateResource(thingState.Id, thingState.SerialNumber, thingState.CurrentOperationMode,
            thingState.CurrentTemperature, thingState.CurrentHumidity, thingState.CollectedAt);
    }
}