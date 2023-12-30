using MediatR;

namespace Application.Features.PersonalData.Commands.Create;

public class CreatePersonalDataCommand : IRequest<string>
{
    public string? Mother { get; set; }
    public string? Father { get; set; }
    public string? Natural { get; set; }
    public DateTime? DocumentIssuanceDate { get; set; }
    public DateTime? DocumentExpirationDate { get; set; }
    public string? PlaceIssuanceDocument { get; set; }
    public string? UserId { get; set; }

    public CreatePersonalDataCommand(string? mother, string? father, string? natural, DateTime? documentIssuanceDate,
        DateTime? documentExpirationDate, string? placeIssuanceDocument, string? userId)
    {
        Mother = mother;
        Father = father;
        Natural = natural;
        DocumentIssuanceDate = documentIssuanceDate;
        DocumentExpirationDate = documentExpirationDate;
        PlaceIssuanceDocument = placeIssuanceDocument;
        UserId = userId;
    }

    public static implicit operator CreatePersonalDataCommand(
        (string? mother, string? father, string? natural, DateTime? documentIssuanceDate,
            DateTime? documentExpirationDate, string? placeIssuanceDocument, string? userId) value)
        => new(value.mother, value.father, value.natural, value.documentIssuanceDate, value.documentExpirationDate,
            value.placeIssuanceDocument, value.userId);
}