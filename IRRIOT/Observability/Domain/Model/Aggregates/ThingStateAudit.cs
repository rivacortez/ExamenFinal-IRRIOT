using EntityFrameworkCore.CreatedUpdatedDate.Contracts;

namespace API.Observability.Domain.Model.Aggregates;

public partial class ThingState:IEntityWithCreatedUpdatedDate
{
    public DateTimeOffset? CreatedDate { get; set; }
    public DateTimeOffset? UpdatedDate { get; set; }
}
