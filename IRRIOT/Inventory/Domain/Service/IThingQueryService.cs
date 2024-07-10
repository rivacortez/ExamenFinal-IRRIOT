

using API.Inventory.Domain.Model.Aggregates;
using API.Inventory.Domain.Model.Queries;

namespace API.Inventory.Domain.Service;



public interface IThingQueryService
{
    Task<Thing> Handle(GetAllThingById query);
}