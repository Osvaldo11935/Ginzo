using MediatR;

namespace Application.Features.PersonalData.Queries;

public class GetPersonalDataByUserQuery: IRequest<Domain.Entities.PersonalData>
{
    public string UserId { get; set; }

    public GetPersonalDataByUserQuery(string userId)
    {
        UserId = userId;
    }

    public static implicit operator GetPersonalDataByUserQuery(string userId)
        => new(userId);
}