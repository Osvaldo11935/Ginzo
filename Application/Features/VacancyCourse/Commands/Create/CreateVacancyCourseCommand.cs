
namespace Application.Features.VacancyCourse.Commands.Create;

public class CreateVacancyCourseCommand
{
    public string? CourseId { get; set; }
    public int TotalVacancy { get; set; }
    public string EnrollmentParameterId { get; set; }

    public CreateVacancyCourseCommand(string? courseId, int totalVacancy, string enrollmentParameterId)
    {
        CourseId = courseId;
        TotalVacancy = totalVacancy;
        EnrollmentParameterId = enrollmentParameterId;
    }

    public static implicit operator CreateVacancyCourseCommand((string? courseId, int totalVacancy, string enrollmentParameterId) value)
        => new(value.courseId, value.totalVacancy, value.enrollmentParameterId);
}