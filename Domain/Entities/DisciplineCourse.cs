using Domain.Entities.Common;

namespace Domain.Entities;

public class DisciplineCourse: EntityBase
{
    public bool? IsKey { get; set; }
    public string? CourseId { get; set; }
    public string? DisciplineId { get; set; }
}