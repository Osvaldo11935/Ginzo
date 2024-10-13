using Domain.Entities.Common;

namespace Domain.Entities;

public class PersonalData: EntityBase
{
    public string? Mother { get; set; }
    public string? Father { get; set; }
    public string? Natural { get; set; }
    public DateTime? DocumentIssuanceDate { get; set; }
    public DateTime? DocumentExpirationDate { get; set; }
    public string? PlaceIssuanceDocument { get; set; }
    public string? UserId { get; set; }
    public virtual User? User { get; set; }
}