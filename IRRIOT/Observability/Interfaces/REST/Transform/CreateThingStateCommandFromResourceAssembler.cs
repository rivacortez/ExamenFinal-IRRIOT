

using API.Observability.Domain.Model.Commands;
using API.Observability.Interfaces.REST.Resources;

namespace API.Observability.Interfaces.REST.Transform;

public class CreateThingStateCommandFromResourceAssembler
{
    public static CreateThingStateCommand ToCommandFromResource(CreateThingStateResource resource)
    {
        return new CreateThingStateCommand(resource.SerialNumber, resource.CurrentOperationMode, resource.CurrentTemperature, resource.CurrentHumidity, resource.CollectedAt);
    }
}