namespace Domain.Entities.Common;

public class EntityBase
{
    public string? Id { get; set; }
    public bool IsActive { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }

    public EntityBase()
    {
        Id = Guid.NewGuid().ToString();
        IsActive = true;
        CreatedAt = DateTime.Now;
        UpdatedAt = DateTime.Now;
    }
}