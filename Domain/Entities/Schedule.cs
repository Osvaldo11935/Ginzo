using Domain.Entities.Common;

namespace Domain.Entities;

public class Schedule: EntityBase
{
    public string? DayWeek { get; set; }
    public DateTime? ExitDate { get; set; }
    public DateTime? EntryDate { get; set; }
    public string? SchoolYearId { get; set; }
    public virtual SchoolYear? SchoolYear { get; set; }
    public virtual IList<ScheduleClass>? ScheduleClasses { get; set; }
}