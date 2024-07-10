
using API.Inventory.Domain.Model.Aggregates;
using API.Inventory.Domain.Model.Queries;
using API.Inventory.Domain.Repository;
using API.Inventory.Domain.Service;

namespace API.Inventory.Application.Internal.QueryService;


public class ThingQueryService (IThingRepository thingRepository): IThingQueryService
{

    public async Task<Thing?> Handle(GetAllThingById query)
    {
        return await thingRepository.FindByIdAsync(query.Id) 
               ?? throw new Exception($"Thing with ID {query.Id} not found.");
    }
}
