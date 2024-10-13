using Domain.Entities.Common;

namespace Domain.Entities;

public class Enrollment: EntityBase
{
    public string? StudentId { get; set; }
    public double FinalAverage { get; set; }
    public string? EnrollmentStatusId { get; set; }
    public string? EnrollmentParameterId { get; set; }
    public virtual User? Student { get; set; }
    public virtual EnrollmentStatus? EnrollmentStatus { get; set; }
    public virtual EnrollmentParameter? EnrollmentParameter { get; set; }
    public virtual IList<EnrollmentCourse>? EnrollmentCourses { get; set; }
}