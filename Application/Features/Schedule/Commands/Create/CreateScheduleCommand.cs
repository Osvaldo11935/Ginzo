using Application.Features.Discipline.Commands.Create;
using MediatR;

namespace Application.Features.Schedule.Commands.Create;

public class CreateScheduleCommand : IRequest<string>
{
    public string? DayWeek { get; set; }
    public DateTime ExitDate { get; set; }
    public DateTime EntryDate { get; set; }
    public string? SchoolYearId { get; set; }

    public CreateScheduleCommand(string? dayWeek, DateTime exitDate, DateTime entryDate, string? schoolYearId)
    {
        DayWeek = dayWeek;
        ExitDate = exitDate;
        EntryDate = entryDate;
        SchoolYearId = schoolYearId;
    }

    public static implicit operator CreateScheduleCommand(
        (string? dayWeek, DateTime exitDate, DateTime entryDate, string? schoolYearId) value)
        => new(value.dayWeek, value.exitDate, value.entryDate, value.schoolYearId);
}