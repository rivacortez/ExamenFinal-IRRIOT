using System.ComponentModel.DataAnnotations;
using API.Inventory.Domain.Model.ValueObjects;
using API.Observability.Domain.Model.Commands;


namespace API.Observability.Domain.Model.Aggregates;


public partial class ThingState
{
    [Required]
    public int Id { get; set; }
    
    [Required]
    public SerialNumber ThingSerialNumber { get; set; }
    
    public string SerialNumber => ThingSerialNumber.Value.ToString();
    
    [Required]
    [Range(0,2)]
    public int CurrentOperationMode { get; set; }
    
    [Required]
    public decimal CurrentTemperature { get; set; }
    
    [Required]
    public decimal CurrentHumidity { get; set; }
    
    [Required]
    public DateTime CollectedAt { get; set; }
    
    public ThingState(){}
  
    public ThingState(CreateThingStateCommand command)
    {
        ThingSerialNumber = new SerialNumber(command.SerialNumber);
        CurrentOperationMode = command.CurrentOperationMode;
        CurrentTemperature = command.CurrentTemperature;
        CurrentHumidity = command.CurrentHumidity;
        CollectedAt = command.CollectedAt;
    }
}