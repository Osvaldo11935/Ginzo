using Domain.Entities.Common;

namespace Domain.Entities;

public class VacancyCourse: EntityBase
{
    public string? CourseId { get; set; }
    public int TotalVacancy { get; set; }
    public string? EnrollmentParameterId { get; set; }
    public virtual Course? Course { get; set; }
    public virtual EnrollmentParameter? EnrollmentParameter { get; set; }
}