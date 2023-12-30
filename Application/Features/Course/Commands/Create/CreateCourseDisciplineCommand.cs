using MediatR;

namespace Application.Features.Course.Commands.Create;

public class CreateCourseDisciplineCommand: IRequest<bool>
{
    public string? CourseId { get; set; }
    public Dictionary<string, bool>? Disciplines { get; set; }

    public CreateCourseDisciplineCommand(string? courseId, Dictionary<string, bool>? disciplines)
    {
        CourseId = courseId;
        Disciplines = disciplines;
    }

    public static implicit operator CreateCourseDisciplineCommand(
        (string? courseId, Dictionary<string, bool>? disciplines) value)
        => new (value.courseId, value.disciplines);
}