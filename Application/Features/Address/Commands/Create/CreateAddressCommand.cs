using MediatR;

namespace Application.Features.Address.Commands.Create;

public class CreateAddressCommand : IRequest<string>
{
    public string? Country { get; set; }
    public string? County { get; set; }
    public string? Province { get; set; }
    public string? Number { get; set; }
    public string? Street { get; set; }
    public string? Complement { get; set; }
    public string? District { get; set; }
    public string? Neighborhood { get; set; }
    public string? UserId { get; set; }

    public CreateAddressCommand(string? country, string? county, string? province, string? number, string? street,
        string? complement, string? district, string? neighborhood, string? userId)
    {
        Country = country;
        County = county;
        Province = province;
        Number = number;
        Street = street;
        Complement = complement;
        District = district;
        Neighborhood = neighborhood;
        UserId = userId;
    }

    public static implicit operator CreateAddressCommand(
        (string? country, string? county, string? province, string? number, string? street,
            string? complement, string? district, string? neighborhood, string? userId) value)
        => new(value.country, value.county, value.province, value.number, value.street, value.complement,
            value.district, value.neighborhood, value.userId);
}