using Domain.Entities.Common;

namespace Domain.Entities;

public class Student: EntityBase
{
    public string? UserId { get; set; }
    public string? ClassId { get; set; }
    public string? CourseId { get; set; }
}