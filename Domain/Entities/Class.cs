using Domain.Entities.Common;

namespace Domain.Entities;

public class Class: EntityBase
{
    public string? Name { get; set; }
    public string? SchoolYearId { get; set; }
    public virtual SchoolYear? SchoolYear { get; set; }
}