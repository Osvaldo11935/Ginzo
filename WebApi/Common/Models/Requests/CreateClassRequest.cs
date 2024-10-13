using Application.Features.Class.Commands.Create;

namespace WebApi.Common.Models.Requests;

public class CreateClassRequest
{
    public string? Name { get; set; }
    public string? CourseId { get; set; }
    public string? SchoolYearId { get; set; }
    public string? AcademicLevelId { get; set; }
    
    public static List<CreateClassCommand> Parsing(List<CreateClassRequest> requests)
        => requests.Select(request => (CreateClassCommand)(request.Name, request.SchoolYearId, request.AcademicLevelId, request.CourseId)!).ToList();
}