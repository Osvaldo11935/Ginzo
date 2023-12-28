using Domain.Entities.Common;

namespace Domain.Entities;

public class PersonalData: EntityBase
{
    public string? Mother { get; set; }
    public string? Father { get; set; }
}