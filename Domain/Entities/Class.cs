using Domain.Entities.Common;

namespace Domain.Entities;

public class Class: EntityBase
{
    public string? Name { get; set; }
    public string? CourseId { get; set; }
    public string? SchoolYearId { get; set; }
    public string? AcademicLevelId { get; set; }
    public virtual Course? Course { get; set; }
    public virtual SchoolYear? SchoolYear { get; set; }
    public virtual AcademicLevel? AcademicLevel { get; set; }
    public virtual IList<Student>? Students { get; set; }
    public virtual IList<Schedule>? Schedules { get; set; }
}