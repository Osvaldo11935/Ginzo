using Domain.Entities.Common;

namespace Domain.Entities;

public class EnrollmentCourse: EntityBase
{
    public string? CourseId { get; set; }
    public string? EnrollmentId { get; set; }
    public virtual Course? Course { get; set; }
    public virtual Enrollment? Enrollment { get; set; }
    public virtual IList<EnrollmentCourseDiscipline>? EnrollmentCourseDisciplines { get; set; }
}