using MediatR;

namespace Application.Features.User.Commands.Create;

public class CreateUserCommand: IRequest<string>
{
    public string? Email { get; set; }
    public string? Name { get; set; }
    public DateTime BirthDate { get; set; }
    public string? DocumentNumber { get; set; }
    public string? PhoneNumber { get; set; }
    public string? RoleName {get; set;}
    public string? Password {get; set;}
    public string? UserName {get; set;}
}