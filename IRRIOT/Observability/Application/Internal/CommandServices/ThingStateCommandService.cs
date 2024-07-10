

using API.Observability.Application.Internal.OutboundServices.ACL;
using API.Observability.Domain.Model.Aggregates;
using API.Observability.Domain.Model.Commands;
using API.Observability.Domain.Repository;
using API.Observability.Domain.Service;
using API.Shared.Domain.Repositories;

namespace API.Observability.Application.Internal.CommandServices;


public class ThingStateCommandService : IThingStateCommandService
{
    private readonly IThingStateRepository _thingStateRepository;
    private readonly ExternalThingService _externalThingService;
    private readonly IUnitOfWork _unitOfWork;

    public ThingStateCommandService(
        IThingStateRepository thingStateRepository,
        ExternalThingService externalThingService,
        IUnitOfWork unitOfWork)
    {
        _thingStateRepository = thingStateRepository;
        _externalThingService = externalThingService;
        _unitOfWork = unitOfWork;
    }

    public async Task<ThingState?> Handle(CreateThingStateCommand command)
    {
        Guid thingSerialNumberGuid = Guid.Parse(command.SerialNumber);
        
        
        var thing = await _externalThingService.FetchThingBySerialNumber(thingSerialNumberGuid)
                    ?? throw new Exception("There's no Thing with the provided Serial Number");

        ValidateCommand(command);

        var existingThingState = await _thingStateRepository.GetBySerialNumberAndCollectedAt(thingSerialNumberGuid, command.CollectedAt.Date);
        if (existingThingState != null)
        {
            throw new Exception("A ThingState with the same Serial Number and CollectedAt already exists");
        }

        var thingState = new ThingState(command);
        await _thingStateRepository.AddAsync(thingState);
        await _unitOfWork.CompleteAsync();
        return thingState;
    }

    private void ValidateCommand(CreateThingStateCommand command)
    {
        if (command.CollectedAt.Date > DateTime.Now.Date)
        {
            throw new Exception("State Date cannot be in the future");
        }

        if (command.CurrentOperationMode < 0 || command.CurrentOperationMode > 2)
        {
            throw new Exception("CurrentOperationMode must be an integer between 0 and 2");
        }
    }
}
