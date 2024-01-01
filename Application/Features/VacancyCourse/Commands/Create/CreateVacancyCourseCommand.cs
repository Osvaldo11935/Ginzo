
namespace Application.Features.VacancyCourse.Commands.Create;

public class CreateVacancyCourseCommand
{
    public string? CourseId { get; set; }
    public int TotalVacancy { get; set; }

    public CreateVacancyCourseCommand(string? courseId, int totalVacancy)
    {
        CourseId = courseId;
        TotalVacancy = totalVacancy;
    }

    public static implicit operator CreateVacancyCourseCommand((string? courseId, int totalVacancy) value)
        => new(value.courseId, value.totalVacancy);
}