using Domain.Entities.Common;

namespace Domain.Entities;

public class EnrollmentTerm: EntityBase
{
    public string? Term { get; set; }
    public string? CodeTerm { get; set; }
}