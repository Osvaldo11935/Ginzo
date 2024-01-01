using Application.Features.Schedule.Commands.Create;

namespace WebApi.Common.Models.Requests;

public class CreateScheduleRequest
{
    public string? DayWeek { get; set; }
    public DateTime ExitDate { get; set; }
    public DateTime EntryDate { get; set; }
    public string? SchoolYearId { get; set; }
    
    public static List<CreateScheduleCommand> Parsing(List<CreateScheduleRequest> requests)
        => requests.Select(request => (CreateScheduleCommand)(request.DayWeek, request.ExitDate, request.EntryDate, request.SchoolYearId)).ToList();
}