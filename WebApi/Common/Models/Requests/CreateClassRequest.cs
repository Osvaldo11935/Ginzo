namespace WebApi.Common.Models.Requests;

public class CreateClassRequest
{
    public string? Name { get; set; }
    public string? CourseId { get; set; }
    public string? SchoolYearId { get; set; }
    public string? AcademicLevelId { get; set; }
}