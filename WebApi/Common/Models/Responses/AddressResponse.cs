using Domain.Entities;

namespace WebApi.Common.Models.Responses;

public class AddressResponse
{
    public string? Country { get; set; }
    public string? County { get; set; }
    public string? Province { get; set; }
    public string? Number { get; set; }
    public string? Street { get; set; }
    public string? Complement { get; set; }
    public string? District { get; set; }
    public string? Neighborhood { get; set; }
    
    public static AddressResponse AddressToAddressResponse(Address address)
        =>  new AddressResponse() {
            Country = address.Country,
            Province = address.Province,
            County = address.County,
            District = address.District,
            Neighborhood = address.Neighborhood,
            Complement = address.Complement,
            Number = address.Number,
            Street = address.Street
        };
}