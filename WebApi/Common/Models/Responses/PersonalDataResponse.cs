using Domain.Entities;

namespace WebApi.Common.Models.Responses;

public class PersonalDataResponse
{
    public string? Id { get; set; }
    public string? Mother { get; set; }
    public string? Father { get; set; }
    public string? Natural { get; set; }
    public DateTime? DocumentIssuanceDate { get; set; }
    public DateTime? DocumentExpirationDate { get; set; }
    public string? PlaceIssuanceDocument { get; set; }

    public static List<PersonalDataResponse> PersonalDataToPersonalDataResponse(List<PersonalData> personalDatas)
        => personalDatas.Select(e => new PersonalDataResponse()
        {
            Id = e.Id,
            Mother = e.Mother,
            Father = e.Father,
            Natural = e.Natural,
            DocumentIssuanceDate = e.DocumentIssuanceDate,
            DocumentExpirationDate = e.DocumentExpirationDate,
            PlaceIssuanceDocument = e.PlaceIssuanceDocument
        }).ToList();

    public static PersonalDataResponse PersonalDataToPersonalDataResponse(PersonalData personalData)
        => new PersonalDataResponse()
        {
            Id = personalData.Id,
            Mother = personalData.Mother,
            Father = personalData.Father,
            Natural = personalData.Natural,
            DocumentIssuanceDate = personalData.DocumentIssuanceDate,
            DocumentExpirationDate = personalData.DocumentExpirationDate,
            PlaceIssuanceDocument = personalData.PlaceIssuanceDocument
        };
}