namespace WebApi.Common.Models.Requests;

public class CreateScheduleRequest
{
    public string? DayWeek { get; set; }
    public DateTime ExitDate { get; set; }
    public DateTime EntryDate { get; set; }
    public string? SchoolYearId { get; set; }
}