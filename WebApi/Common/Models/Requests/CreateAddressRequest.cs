namespace WebApi.Common.Models.Requests;

public class CreateAddressRequest
{
    public string? Country { get; set; }
    public string? County { get; set; }
    public string? Province { get; set; }
    public string? Number { get; set; }
    public string? Street { get; set; }
    public string? Complement { get; set; }
    public string? District { get; set; }
    public string? Neighborhood { get; set; }
}