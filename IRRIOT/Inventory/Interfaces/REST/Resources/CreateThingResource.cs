
public record CreateThingResource(
    string SerialNumber,
    string Model,
    decimal MaximumTemperatureThreshold,
    decimal MinimumTemperatureThreshold);
