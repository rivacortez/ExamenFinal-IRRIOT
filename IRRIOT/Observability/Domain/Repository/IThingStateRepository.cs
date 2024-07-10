
using API.Observability.Domain.Model.Aggregates;
using API.Shared.Domain.Repositories;

namespace API.Observability.Domain.Repository;

public interface IThingStateRepository :IBaseRepository<ThingState>
{
    Task<ThingState?> GetBySerialNumberAndCollectedAt(Guid serialNumber, DateTime collectedAt);
}