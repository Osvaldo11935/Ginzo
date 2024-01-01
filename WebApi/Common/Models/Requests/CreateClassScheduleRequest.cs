using Application.Features.Class.Commands.Create;

namespace WebApi.Common.Models.Requests;

public class CreateClassScheduleRequest
{
    public string? ClassId { get; set; }
    public List<string>? ScheduleIds { get; set; }
    
    public static List<CreateClassScheduleCommand> Parsing(List<CreateClassScheduleRequest> requests)
        => requests.Select(request => (CreateClassScheduleCommand) (request.ClassId, request.ScheduleIds)).ToList();

}