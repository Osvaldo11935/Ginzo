using MediatR;

namespace Application.Features.Class.Commands.Create;

public class CreateClassCommand: IRequest<string>
{
    public string? Name { get; set; }
    public string? CourseId { get; set; }
    public string? SchoolYearId { get; set; }
    public string? AcademicLevelId { get; set; }

    public CreateClassCommand(string? name, string? schoolYearId, string academicLevelId, string? courseId)
    {
        Name = name;
        SchoolYearId = schoolYearId;
        CourseId = courseId;
        AcademicLevelId = academicLevelId;
    }
    public static implicit operator CreateClassCommand((string? name, string? schoolYearId, string academicLevelId, string? courseId) value)
        => new(value.name, value.schoolYearId, value.academicLevelId, value.courseId);
}