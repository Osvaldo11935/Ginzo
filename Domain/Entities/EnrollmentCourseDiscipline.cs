using Domain.Entities.Common;

namespace Domain.Entities;

public class EnrollmentCourseDiscipline: EntityBase
{
    public double FinalAverage { get; set; }
    public string? DisciplineId { get; set; }
    public string? EnrollmentCourseId { get; set; }
    public virtual Discipline? Discipline { get; set; }
    public virtual EnrollmentCourse? EnrollmentCourse { get; set; }
}