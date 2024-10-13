using MediatR;

namespace Application.Features.Enrollment.Commands.Create;

public class CreateEnrollmentParameterCommand : IRequest<string>
{
    public DateTime? EndDate { get; set; }
    public DateTime? StartDate { get; set; }
    public double FinalAverage { get; set; }
    public string? SchoolYearId { get; set; }
    public int MinPriorityAge { get; set; }
    public int MaxPriorityAge { get; set; }

    public CreateEnrollmentParameterCommand(DateTime? endDate, DateTime? startDate, string? schoolYearId, int minPriorityAge, int maxPriorityAge, double finalAverage)
    {
        EndDate = endDate;
        StartDate = startDate;
        SchoolYearId = schoolYearId;
        FinalAverage = finalAverage;
        MinPriorityAge = minPriorityAge;
        MaxPriorityAge = maxPriorityAge;
    }

    public static implicit operator CreateEnrollmentParameterCommand(
        (DateTime? endDate, DateTime? startDate, string? schoolYearId, int minPriorityAge, int maxPriorityAge, double finalAverage) value)
        => new(value.endDate, value.startDate, value.schoolYearId, value.minPriorityAge, value.maxPriorityAge, value.finalAverage);
}