namespace Domain.Entities;

public class ScheduleClass
{
    public string? ClassId { get; set; }
    public string? ScheduleId { get; set; }
    public virtual Class? Class { get; set; }
    public virtual Schedule? Schedule { get; set; }
}