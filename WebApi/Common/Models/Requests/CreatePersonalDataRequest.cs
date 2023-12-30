namespace WebApi.Common.Models.Requests;

public class CreatePersonalDataRequest
{
    public string? Mother { get; set; }
    public string? Father { get; set; }
    public string? Natural { get; set; }
    public DateTime? DocumentIssuanceDate { get; set; }
    public DateTime? DocumentExpirationDate { get; set; }
    public string? PlaceIssuanceDocument { get; set; }
}