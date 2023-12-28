using Domain.Entities.Common;

namespace Domain.Entities;

public class Enrollment: EntityBase
{
    public string? StudentId { get; set; }
    public double FinalAverage { get; set; }
    public virtual User? Student { get; set; }
}