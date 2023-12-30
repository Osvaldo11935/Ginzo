using Domain.Entities.Common;

namespace Domain.Entities;

public class EnrollmentParameter: EntityBase
{
    public DateTime? EndDate { get; set; }
    public DateTime? StartDate { get; set; }
    public string? SchoolYearId { get; set; }
    public virtual SchoolYear? SchoolYear { get; set; }
    public virtual IList<Enrollment>? Enrollments { get; set; }
}