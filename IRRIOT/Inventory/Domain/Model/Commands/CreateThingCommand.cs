namespace API.Inventory.Domain.Model.Commands;


public record CreateThingCommand(
    string SerialNumber, 
    string Model, 
    decimal MaximumTemperatureThreshold, 
    decimal MinimumTemperatureThreshold);