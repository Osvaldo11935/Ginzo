using MediatR;

namespace Application.Features.Enrollment.Commands.Create;

public class CreateEnrollmentCommand : IRequest<string>
{
    public string? StudentId { get; set; }
    public double FinalAverage { get; set; }
    public Dictionary<string, Dictionary<string, double>> DataEnrolledCourses { get; set; }

    public CreateEnrollmentCommand(string? studentId, double finalAverage,
        Dictionary<string, Dictionary<string, double>> dataEnrolledCourses)
    {
        StudentId = studentId;
        FinalAverage = finalAverage;
        DataEnrolledCourses = dataEnrolledCourses;
    }

    public static implicit operator CreateEnrollmentCommand((string? studentId, double finalAverage,
        Dictionary<string, Dictionary<string, double>> dataEnrolledCourses) value)
        => new(value.studentId, value.finalAverage, value.dataEnrolledCourses);
}