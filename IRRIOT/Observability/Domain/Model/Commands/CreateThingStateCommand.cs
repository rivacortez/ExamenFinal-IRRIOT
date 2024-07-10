namespace API.Observability.Domain.Model.Commands;


public record CreateThingStateCommand(
    string SerialNumber,
    int CurrentOperationMode,
    decimal CurrentTemperature,
    decimal CurrentHumidity,
    DateTime CollectedAt);