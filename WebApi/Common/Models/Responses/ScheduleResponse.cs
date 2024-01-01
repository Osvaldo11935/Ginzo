using Domain.Entities;

namespace WebApi.Common.Models.Responses;

public class ScheduleResponse
{
    public string? Id { get; set; }
    public string? DayWeek { get; set; }
    public DateTime? ExitDate { get; set; }
    public DateTime? EntryDate { get; set; }

    public static List<ScheduleResponse> ScheduleToScheduleResponse(List<Schedule> schedules)
        => schedules.Select(e => new ScheduleResponse
        {
            Id = e.Id,
            DayWeek = e.DayWeek,
            EntryDate = e.EntryDate,
            ExitDate = e.ExitDate
        }).ToList();
    
    public static ScheduleResponse ScheduleToScheduleResponse(Schedule schedule)
        => new ScheduleResponse
        {
            Id = schedule.Id,
            DayWeek = schedule.DayWeek,
            EntryDate = schedule.EntryDate,
            ExitDate = schedule.ExitDate
        };
}