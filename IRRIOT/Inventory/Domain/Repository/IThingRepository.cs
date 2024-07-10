
using API.Inventory.Domain.Model.Aggregates;
using API.Shared.Domain.Repositories;

namespace API.Inventory.Domain.Repository;


public interface IThingRepository :IBaseRepository<Thing>
{
    Task<bool> ExistBySerialNumberAsync(Guid serialNumber);
}