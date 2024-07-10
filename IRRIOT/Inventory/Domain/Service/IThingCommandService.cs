
using API.Inventory.Domain.Model.Aggregates;
using API.Inventory.Domain.Model.Commands;

namespace API.Inventory.Domain.Service;


public interface IThingCommandService
{
    Task<Thing?> Handle(CreateThingCommand command);
}