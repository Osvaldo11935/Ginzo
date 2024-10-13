using Domain.Entities.Common;

namespace Domain.Entities;

public class EnrollmentParameter: EntityBase
{
    public DateTime? EndDate { get; set; }
    public DateTime? StartDate { get; set; }
    public double FinalAverage { get; set; }
    public int MinPriorityAge { get; set; }
    public int MaxPriorityAge { get; set; }
    public string? SchoolYearId { get; set; }
    public virtual SchoolYear? SchoolYear { get; set; }
    public virtual IList<Enrollment>? Enrollments { get; set; }
    public virtual IList<VacancyCourse>? VacancyCourses { get; set; }
}