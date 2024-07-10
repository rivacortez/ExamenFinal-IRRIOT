using EntityFrameworkCore.CreatedUpdatedDate.Contracts;

namespace API.Inventory.Domain.Model.Aggregates;


public partial class Thing:IEntityWithCreatedUpdatedDate
{
    public DateTimeOffset? CreatedDate { get; set; }
    public DateTimeOffset? UpdatedDate { get; set; }
}