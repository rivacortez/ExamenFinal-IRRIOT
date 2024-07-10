
using API.Inventory.Domain.Model.Aggregates;
using API.Inventory.Domain.Model.Commands;
using API.Inventory.Domain.Repository;
using API.Inventory.Domain.Service;
using API.Shared.Domain.Repositories;

namespace API.Inventory.Application.Internal.CommandService;


public class ThingCommandService : IThingCommandService
{
    private readonly IThingRepository _thingRepository;
    private readonly IUnitOfWork _unitOfWork;

    public ThingCommandService(IThingRepository thingRepository, IUnitOfWork unitOfWork)
    {
        _thingRepository = thingRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Thing?> Handle(CreateThingCommand command)
    {
     
        ValidateTemperatureThresholds(command);

       
        bool thingExists = await _thingRepository.ExistBySerialNumberAsync(Guid.Parse(command.SerialNumber));
        if (thingExists)
        {
            throw new Exception("Thing already exists. Code must be unique.");
        }

       
        var thing = new Thing(command);
        await _thingRepository.AddAsync(thing);
        await _unitOfWork.CompleteAsync();
        return thing;
    }

    private void ValidateTemperatureThresholds(CreateThingCommand command)
    {
        if (command.MaximumTemperatureThreshold < -40.00m || command.MaximumTemperatureThreshold > 85.00m)
        {
            throw new Exception("MaximumTemperatureThreshold must be a decimal between -40.00 and 85.00.");
        }

        if (command.MinimumTemperatureThreshold < 0.00m || command.MinimumTemperatureThreshold > 100.00m)
        {
            throw new Exception("MinimumTemperatureThreshold must be a decimal between 0.00 and 100.00.");
        }
    }
}
