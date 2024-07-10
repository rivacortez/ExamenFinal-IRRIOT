namespace API.Observability.Interfaces.REST.Resources;

public record ThingStateResource(
    int Id,
    string SerialNumber,
    int CurrentOperationMode,
    decimal CurrentTemperature,
    decimal CurrentHumidity,
    DateTime CollectedAt);
