namespace WebApi.Common.Models.Requests;

public class DataEnrolledCourseRequest
{
    public string? CourseId { get; set; }
    public List<KeySubjectGradeRequest>? KeySubjectGrade { get; set; }
}