using MediatR;

namespace Application.Features.Enrollment.Commands.Create;

public class CreateEnrollmentStatusCommand: IRequest<string>
{
    public string? Status { get; set; }
    public string? Description { get; set; }

    public CreateEnrollmentStatusCommand(string? status, string? description)
    {
        Status = status;
        Description = description;
    }

    public static implicit operator CreateEnrollmentStatusCommand((string? status, string? description) value)
        => new(value.status, value.description);
}