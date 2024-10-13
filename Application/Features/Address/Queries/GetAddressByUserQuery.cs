using MediatR;

namespace Application.Features.Address.Queries;

public class GetAddressByUserQuery: IRequest<Domain.Entities.Address>
{
    public string UserId { get; set; }

    public GetAddressByUserQuery(string userId)
    {
        UserId = userId;
    }

    public static implicit operator GetAddressByUserQuery(string userId)
        => new(userId);
}