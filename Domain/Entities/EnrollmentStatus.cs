using Domain.Entities.Common;

namespace Domain.Entities;

public class EnrollmentStatus: EntityBase
{
    public string? Status { get; set; }
    public string? Description { get; set; }
    public virtual IList<Enrollment>? Enrollments { get; set; }
}