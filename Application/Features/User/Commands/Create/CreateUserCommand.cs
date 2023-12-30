using MediatR;

namespace Application.Features.User.Commands.Create;

public class CreateUserCommand : IRequest<string>
{
    public string? Email { get; set; }
    public string? Name { get; set; }
    public DateTime BirthDate { get; set; }
    public string? DocumentNumber { get; set; }
    public string? PhoneNumber { get; set; }
    public string? RoleName { get; set; }
    public string? Password { get; set; }
    public string? UserName { get; set; }

    public CreateUserCommand(string? userName, string? password, string? roleName, string? phoneNumber,
        string? documentNumber, DateTime birthDate, string? name, string? email)
    {
        UserName = userName;
        Password = password;
        RoleName = roleName;
        PhoneNumber = phoneNumber;
        DocumentNumber = documentNumber;
        BirthDate = birthDate;
        Name = name;
        Email = email;
    }

    public static implicit operator CreateUserCommand(
        (string? userName, string? password, string? roleName, string? phoneNumber, string? documentNumber, DateTime
            birthDate, string? name, string? email) value)
        => new(value.userName, value.password, value.roleName, value.phoneNumber, value.documentNumber, value.birthDate, value.name, value.email);
}