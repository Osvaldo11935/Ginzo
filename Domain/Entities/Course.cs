using Domain.Entities.Common;

namespace Domain.Entities;

public class Course: EntityBase
{
    public string? Name { get; set; }
    public virtual IList<Class>? Classes { get; set; }
    public virtual IList<DisciplineCourse>? DisciplineCourses { get; set; }
    public virtual IList<EnrollmentCourse>? EnrollmentCourses { get; set; }
    
    public virtual VacancyCourse? VacancyCourse { get; set; }
}