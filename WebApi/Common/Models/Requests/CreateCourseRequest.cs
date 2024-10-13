using Application.Features.Course.Commands.Create;

namespace WebApi.Common.Models.Requests;

public class CreateCourseRequest
{
    public string? Name { get; set; }
    
    public static List<CreateCourseCommand> Parsing(List<CreateCourseRequest> requests)
        => requests.Select(request => (CreateCourseCommand) request.Name!).ToList();
}