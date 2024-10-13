namespace WebApi.Common.Models.Requests;

public class CreateUserRequest
{
    public string? Email { get; set; }
    public string? Name { get; set; }
    public DateTime BirthDate { get; set; }
    public string? DocumentNumber { get; set; }
    public string? PhoneNumber { get; set; }
    public string? Password { get; set; }
    public string? UserName { get; set; }
    
    public CreateAddressRequest? Address { get; set; }
    public CreatePersonalDataRequest? PersonalData { get; set; }
}