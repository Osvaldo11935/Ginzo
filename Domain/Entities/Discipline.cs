using Domain.Entities.Common;

namespace Domain.Entities;

public class Discipline: EntityBase
{
    public string? Name { get; set; }
    public virtual IList<DisciplineCourse>? DisciplineCourses { get; set; }
    public virtual IList<EnrollmentCourseDiscipline>? EnrollmentCourseDisciplines { get; set; }
}