using Domain.Entities.Common;

namespace Domain.Entities;

public class Student: EntityBase
{
    public string? UserId { get; set; }
    public string? ClassId { get; set; }
    public string? ProcessNumber { get; set; }
    public virtual User? User { get; set; }
    public virtual Class? Class { get; set; }
}