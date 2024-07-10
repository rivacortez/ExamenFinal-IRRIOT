namespace API.Inventory.Domain.Model.ValueObjects;


public record SerialNumber (Guid Value)
{
    public SerialNumber(string value) : this(Guid.Parse(value))
    {
    }
}
