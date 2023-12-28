using MediatR;

namespace Application.Features.Schedule.Commands.Create;

public class CreateScheduleCommand: IRequest<string>
{
    public string? DayWeek { get; set; }
    public DateTime ExitDate { get; set; }
    public DateTime EntryDate { get; set; }
    public string? SchoolYearId { get; set; }
}