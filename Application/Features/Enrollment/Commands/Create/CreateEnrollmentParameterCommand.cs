using MediatR;

namespace Application.Features.Enrollment.Commands.Create;

public class CreateEnrollmentParameterCommand : IRequest<string>
{
    public DateTime? EndDate { get; set; }
    public DateTime? StartDate { get; set; }
    public string? SchoolYearId { get; set; }

    public CreateEnrollmentParameterCommand(DateTime? endDate, DateTime? startDate, string? schoolYearId)
    {
        EndDate = endDate;
        StartDate = startDate;
        SchoolYearId = schoolYearId;
    }

    public static implicit operator CreateEnrollmentParameterCommand(
        (DateTime? endDate, DateTime? startDate, string? schoolYearId) value)
        => new(value.endDate, value.startDate, value.schoolYearId);
}