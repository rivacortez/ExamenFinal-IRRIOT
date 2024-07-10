

using API.Observability.Domain.Model.Aggregates;
using API.Observability.Domain.Model.Commands;

namespace API.Observability.Domain.Service;


public interface IThingStateCommandService
{
    Task<ThingState?> Handle(CreateThingStateCommand command);
}